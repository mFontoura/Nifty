using UnityEngine;

namespace ObjectPool.Scripts {
	[RequireComponent(typeof(Rigidbody))]
	public class Stuff : MonoBehaviour
	{
		
		private MeshRenderer[] _meshRenderers;

		public Rigidbody Body{ get; private set; }

		private void Awake(){
			Body = GetComponent<Rigidbody>();
			_meshRenderers = GetComponentsInChildren<MeshRenderer>();
		}

		private void OnTriggerEnter(Collider other){
			if (other.CompareTag("Kill Zone")){
				Destroy(gameObject);
			}
		}
		
		public void SetMaterial (Material m) {
			for (int i = 0; i < _meshRenderers.Length; i++) {
				_meshRenderers[i].material = m;
			}
		}
	}
}
