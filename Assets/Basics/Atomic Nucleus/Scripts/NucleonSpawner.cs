using UnityEngine;

namespace Atomic_Nucleus.Scripts {
    public class NucleonSpawner : MonoBehaviour
    {

        public float timeBetweenSpawns;
        public float spawnDistance;
        public Nucleon[] nucleonPrefabs;

        private float _timeSinceLastSpawn;
    
        private void FixedUpdate(){
            _timeSinceLastSpawn += Time.deltaTime;
            if (_timeSinceLastSpawn >= timeBetweenSpawns){
                _timeSinceLastSpawn -= timeBetweenSpawns;
                SpawnNucleon();
            }
        }

        private void SpawnNucleon(){
            Nucleon prefab = nucleonPrefabs[Random.Range(0, nucleonPrefabs.Length)];
            Nucleon spawn = Instantiate(prefab);
            spawn.transform.localPosition = Random.onUnitSphere * spawnDistance;
        }
    }
}
