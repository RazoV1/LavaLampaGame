using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Environment
{
    public class GeometryDashSpike : MonoBehaviour
    {
        public void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Player")
            {
                SoundsBaseCollection.Instance.revive.Play();
                SceneManager.LoadScene(1);
            }
        }
    }
}
