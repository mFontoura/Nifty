using UnityEngine;
using UnityEngine.SceneManagement;

namespace ObjectPool.Scripts {
    public class SceneSwitcher : MonoBehaviour {

        public void SwitchScene(){
            SceneManager.LoadScene("ObjectPool2");
        }
    }
}
