using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private float lifetime;
    [SerializeField] private int damage;

    private IEnumerator Countdown()
    {
        yield return new WaitForSeconds(lifetime);
        Destroy(gameObject);
    }

    private void Start()
    {
        StartCoroutine(Countdown());
    }
}
