using UnityEngine;

namespace ObjectPool.Scripts {
	[RequireComponent(typeof(Rigidbody))]
	public class Stuff : MonoBehaviour
	{

		public Rigidbody Body{ get; private set; }

		private void Awake(){
			Body = GetComponent<Rigidbody>();
		}
	}
}
