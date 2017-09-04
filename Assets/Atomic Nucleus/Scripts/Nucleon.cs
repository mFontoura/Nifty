using UnityEngine;

namespace Atomic_Nucleus.Scripts {
    [RequireComponent(typeof(Rigidbody))]
    public class Nucleon : MonoBehaviour
    {

        public float attractionForce;

        private Rigidbody _body;

        private void Awake(){
            _body = GetComponent<Rigidbody>();
        }

        private void FixedUpdate(){
            _body.AddForce(transform.localPosition * -attractionForce);
        }
    }
}
