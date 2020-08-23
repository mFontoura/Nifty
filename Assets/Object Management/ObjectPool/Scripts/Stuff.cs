using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObjectPool.Scripts {
	
	[RequireComponent(typeof(Rigidbody))]
	public class Stuff : PooledObject
	{
		
		private MeshRenderer[] _meshRenderers;

		public Rigidbody Body{ get; private set; }

		private void OnEnable(){
			SceneManager.sceneLoaded += OnLevelWasLoaded;
		}

		private void Awake(){
			Body = GetComponent<Rigidbody>();
			_meshRenderers = GetComponentsInChildren<MeshRenderer>();
		}

		private void OnTriggerEnter(Collider other){
			if (other.CompareTag("Kill Zone")){
				ReturnToPool();
			}
		}
		
		public void SetMaterial (Material m) {
			for (int i = 0; i < _meshRenderers.Length; i++) {
				_meshRenderers[i].material = m;
			}
		}

		private void OnLevelWasLoaded(Scene scene, LoadSceneMode loadSceneMode){
			ReturnToPool();
		}
	}
}
