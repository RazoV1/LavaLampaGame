using TMPro;
using UnityEngine;

namespace Assets.Scripts.Environment.Door
{
    public class DoorByCorrectInput : MonoBehaviour
    {
        [SerializeField] private string key;
        [SerializeField] private float openingSpeed;

        [SerializeField] private GameObject doorUI;

        [SerializeField] private ParticleSystem desintegrationParticles;

        public void CheckInput()
        {

            var input = doorUI.GetComponentInChildren<TMP_InputField>().text;
            if (input == key)
            {
                Instantiate(desintegrationParticles,transform.position,Quaternion.identity).Play();
                doorUI.SetActive(false);
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                doorUI.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                doorUI.SetActive(false);
            }
        }
    }
}
