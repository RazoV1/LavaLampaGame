using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerPrefs.HasKey("checkpoint"))
            {
                if (PlayerPrefs.GetInt("checkpoint") < int.Parse(gameObject.name))
                {
                    PlayerPrefs.SetInt("checkpoint", int.Parse(gameObject.name));
                }
            }
            else
            {
                PlayerPrefs.SetInt("checkpoint", 0);
            }
        }
    }
}
