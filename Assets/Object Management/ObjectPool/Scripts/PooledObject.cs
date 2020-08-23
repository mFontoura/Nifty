using UnityEngine;

namespace ObjectPool.Scripts {
    public class PooledObject : MonoBehaviour {

        public ObjectPool Pool{ get; set; }
        
        [System.NonSerialized]
        private ObjectPool _poolInstanceForPrefab;

        public T GetPooledInstance<T>() where T : PooledObject{
            if (!_poolInstanceForPrefab){
                _poolInstanceForPrefab = ObjectPool.GetPool(this);
            }
            return (T) _poolInstanceForPrefab.GetObject();
        }
    
        public void ReturnToPool(){
            if (Pool){
                Pool.AddObject(this);
            }else{
                Destroy(gameObject);
            }
        }

    }
}
