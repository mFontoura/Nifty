using System.Collections;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Fractal : MonoBehaviour
{

    public Mesh mesh;
    public Material material;
    public int maxDepth;
    public float childScale;
    public float speed;

    private static Vector3[] childDirections = {
        Vector3.up, 
        Vector3.right, 
        Vector3.left,
        Vector3.forward, 
        Vector3.back,
        Vector3.down
    };

    private static Quaternion[] childOrientations = {
        Quaternion.identity, 
        Quaternion.Euler(0,0,-90),
        Quaternion.Euler(0,0,90),
        Quaternion.Euler(90,0,0),
        Quaternion.Euler(-90,0,0),
        Quaternion.Euler(0,0,180) 
        
    };
    
    private Material[] materials;
    private int depth;

    private void Start(){
        if (materials == null){
            InitializeMaterials();
        }
        gameObject.AddComponent<MeshFilter>().mesh = mesh;
        gameObject.AddComponent<MeshRenderer>().material = materials[depth];
        
        if (depth < maxDepth){
            StartCoroutine(CreateChild());
        }
    }

    private void Initialize(Fractal parent, int childIndex){
        mesh = parent.mesh;
        material = parent.material;
        childScale = parent.childScale;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        speed = parent.speed;
        materials = parent.materials;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localRotation = childOrientations[childIndex];
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
    }

    private void InitializeMaterials(){
        materials = new Material[maxDepth + 1];
        for (int i = 0; i <= maxDepth; i++){
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i] = new Material(material);
            materials[i].color = Color.Lerp(Color.white, Color.yellow, t);
        }
        materials[maxDepth].color = Color.magenta;
    }

    private IEnumerator CreateChild(){

        for(int i = 0; i < childDirections.Length;i++){
            yield return new WaitForSeconds(Random.Range(0.1f,speed));
            new GameObject("Fractal Child")
                .AddComponent<Fractal>().Initialize(this, i);
        }
    }
}
