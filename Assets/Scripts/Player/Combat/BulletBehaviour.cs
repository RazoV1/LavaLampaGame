using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private int damage;

    [SerializeField] private TMP_Text text;

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void Start()
    {
        text.text = (int.Parse(gameObject.tag)/8).ToString() + "Á";
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
