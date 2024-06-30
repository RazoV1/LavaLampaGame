using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
