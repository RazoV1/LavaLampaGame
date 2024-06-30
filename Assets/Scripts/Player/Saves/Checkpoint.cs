using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Checkpoint : MonoBehaviour
{
    public Light2D playerLight;
    public float radius;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerPrefs.HasKey("checkpoint"))
            {
                if (PlayerPrefs.GetInt("checkpoint") < int.Parse(gameObject.name))
                {
                    PlayerPrefs.SetInt("checkpoint", int.Parse(gameObject.name));
                    playerLight.shapeLightFalloffSize = radius;
                }
            }
            else
            {
                PlayerPrefs.SetInt("checkpoint", 0);
            }
        }
    }

    public void UpdateRadius()
    {
        playerLight.shapeLightFalloffSize = radius;
    }
}
