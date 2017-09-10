using UnityEngine;

namespace ObjectPool.Scripts {
    public class StuffSpawnerRing : MonoBehaviour
    {

        [SerializeField] private int _numberOfSpawners;
        [SerializeField] private float _radius;
        [SerializeField] private float _tiltAngle;
        [SerializeField] private StuffSpawner _spawnerPrefab;
        [SerializeField] private Material[] _stuffMaterials;

        private void Awake(){
            for (int i = 0; i < _numberOfSpawners; i++){
                CreateSpawner(i);
            }
        }

        private void CreateSpawner(int index){
            Transform rotater = new GameObject("Rotater").transform;
            rotater.SetParent(transform, false);
            rotater.localRotation = Quaternion.Euler(0f, index * 360f / _numberOfSpawners, 0f);
            StuffSpawner spawner = Instantiate(_spawnerPrefab);
            spawner.transform.SetParent(rotater, false);
            spawner.transform.localPosition = new Vector3(0f,0f,_radius);
            spawner.transform.localRotation = Quaternion.Euler(_tiltAngle, 0f, 0f);
            spawner.setStuffMaterial(_stuffMaterials[index % _stuffMaterials.Length]);
        }
    }
}
