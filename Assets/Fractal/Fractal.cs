using System.Collections;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Fractal : MonoBehaviour
{

    public Mesh[] meshs;
    public Material material;
    public int maxDepth;
    public float childScale;
    public float speed;
    public float spawnProbability;
    public float maxRotationSpeed;
    public float maxTwist;

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
    
    private Material[,] materials;
    private int depth;
    private float rotationSpeed;

    private void Start(){
        rotationSpeed = Random.Range(-maxRotationSpeed, maxRotationSpeed);
        transform.Rotate(Random.Range(-maxTwist, maxTwist), 0f, 0f);
        
        if (materials == null){
            InitializeMaterials();
        }
        gameObject.AddComponent<MeshFilter>().mesh = meshs[Random.Range(0, meshs.Length)];
        gameObject.AddComponent<MeshRenderer>().material = materials[depth, Random.Range(0,2)];
        
        if (depth < maxDepth){
            StartCoroutine(CreateChild());
        }
    }

    private void Update(){
        transform.Rotate(0f,rotationSpeed * Time.deltaTime, 0f);
    }

    private void Initialize(Fractal parent, int childIndex){
        meshs = parent.meshs;
        material = parent.material;
        childScale = parent.childScale;
        maxDepth = parent.maxDepth;
        depth = parent.depth + 1;
        speed = parent.speed;
        spawnProbability = parent.spawnProbability;
        maxRotationSpeed = parent.maxRotationSpeed;
        maxTwist = parent.maxTwist;
        materials = parent.materials;
        transform.parent = parent.transform;
        transform.localScale = Vector3.one * childScale;
        transform.localRotation = childOrientations[childIndex];
        transform.localPosition = childDirections[childIndex] * (0.5f + 0.5f * childScale);
    }

    private void InitializeMaterials(){
        materials = new Material[maxDepth + 1,2];
        for (int i = 0; i <= maxDepth; i++){
            float t = i / (maxDepth - 1f);
            t *= t;
            materials[i, 0] = new Material(material);
            materials[i, 0].color = Color.Lerp(Color.white, Color.yellow, t);
            materials[i, 1] = new Material(material);
            materials[i, 1].color = Color.Lerp(Color.white, Color.cyan, t);
        }
        materials[maxDepth, 0].color = Color.magenta;
        materials[maxDepth, 1].color = Color.red;
    }

    private IEnumerator CreateChild(){

        for(int i = 0; i < childDirections.Length;i++){
            if (Random.value < spawnProbability){
                yield return new WaitForSeconds(Random.Range(0.1f, speed));
                new GameObject("Fractal Child")
                    .AddComponent<Fractal>().Initialize(this, i);
            }
        }
    }
}
