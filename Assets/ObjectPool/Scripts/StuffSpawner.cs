
using UnityEngine;

namespace ObjectPool.Scripts {
    public class StuffSpawner : MonoBehaviour
    {

        [SerializeField] private float _timeBetweenSpawns;
        [SerializeField] private float _velocity;
        [SerializeField] private Stuff[] _stuffPrefabs;
        
        
        private float _timeSinceLastSpawn;

        private void FixedUpdate(){
            _timeSinceLastSpawn += Time.deltaTime;
            if (!(_timeSinceLastSpawn >= _timeBetweenSpawns)){
                return;
            }
            _timeSinceLastSpawn -= _timeBetweenSpawns;
            SpawnStuff();
        }

        private void SpawnStuff(){
            Stuff prefab = _stuffPrefabs[Random.Range(0, _stuffPrefabs.Length)];
            Stuff spawn = Instantiate(prefab);
            spawn.transform.localPosition = transform.position;
            spawn.Body.velocity = transform.up * _velocity;

        }
    }
}
