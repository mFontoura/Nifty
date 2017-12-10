using UnityEngine;

namespace ObjectPool.Scripts {
    public class StuffSpawner : MonoBehaviour
    {
        
        [System.Serializable]
        public struct FloatRange {

            public float min, max;
            public float RandomInRange {
                get {
                    return Random.Range(min, max);
                }
            }
        }

        [SerializeField] private FloatRange _timeBetweenSpawns, _scale, _randomVelocity, _angularVelocity;
        [SerializeField] private float _velocity;
        [SerializeField] private Stuff[] _stuffPrefabs;
        
        private Material _stuffMaterial;
        private float _timeSinceLastSpawn;
        private float _currentSpawnDelay;

        private void FixedUpdate(){
            _timeSinceLastSpawn += Time.deltaTime;
            if (!(_timeSinceLastSpawn >= _currentSpawnDelay)){
                return;
            }
            _timeSinceLastSpawn -= _currentSpawnDelay;
            _currentSpawnDelay = _timeBetweenSpawns.RandomInRange;
            SpawnStuff();
        }

        private void SpawnStuff(){
            Stuff prefab = _stuffPrefabs[Random.Range(0, _stuffPrefabs.Length)];
            Stuff spawn = prefab.GetPooledInstance<Stuff>();
            spawn.transform.localPosition = transform.position;
            spawn.transform.localScale = Vector3.one * _scale.RandomInRange;
            spawn.transform.localRotation = Random.rotation;
            spawn.Body.velocity = transform.up * _velocity + Random.onUnitSphere * _randomVelocity.RandomInRange;
            spawn.Body.angularVelocity = Random.onUnitSphere * _angularVelocity.RandomInRange;
            spawn.SetMaterial(_stuffMaterial);
        }

        public void setStuffMaterial(Material newMaterial){
            _stuffMaterial = newMaterial;
        }
    }
}
