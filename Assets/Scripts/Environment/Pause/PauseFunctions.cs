using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Environment.Pause
{
    public class PauseFunctions : MonoBehaviour
    {
        public void ToScene(int ind)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(ind);
        }


    }
}
