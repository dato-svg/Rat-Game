using UnityEngine;
using UnityEngine.SceneManagement;

namespace Components
{
    public class SceneControllerComponent : MonoBehaviour
    {
        
        public void ReloadScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void SwitchScene(string name)
        {
            SceneManager.LoadScene(name);
        }
        
        public void ExitGame()
        {
          Application.Quit();
        }
        
    }
}
