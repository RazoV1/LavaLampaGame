using System.Collections;
using TMPro;
using UnityEngine;

namespace Assets.Scripts.Player.Combat
{
    public class BulletBehaviour : MonoBehaviour
    {
        [SerializeField] private float lifetime;
        public int damage;
        [SerializeField] private bool Byte=false;

        [SerializeField] private TMP_Text text;

        private IEnumerator Countdown()
        {
            yield return new WaitForSeconds(lifetime);
            Destroy(gameObject);
        }

        private void Start()
        {
            if (!Byte) text.text = damage.ToString() + "Бит";
            else text.text = (damage / 8).ToString() + "Байт";
            StartCoroutine(Countdown());
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == (int.Parse(gameObject.tag)*8).ToString())
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }
}
