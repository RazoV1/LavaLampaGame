using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class MenuUI : MonoBehaviour
    {

        [SerializeField] private GameObject splashScreen;

        //[SerializeField] private Rigidbody2D western_a;
        //[SerializeField] private Rigidbody2D western_b;
    
        public void ToScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        public void QuitGame()
        {
            Application.Quit();
        }

        private void Start()
        {
            Destroy(splashScreen, 3f);
            //western_a.GetComponent<Rigidbody2D>().AddForce(new Vector2(5f, 4f), ForceMode2D.Impulse);
            //western_b.GetComponent<Rigidbody2D>().AddForce(new Vector2(-7f, -3f), ForceMode2D.Impulse); 
        }
    }
}
