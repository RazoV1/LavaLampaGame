using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    public List<Transform> Spawns;

    public void Start()
    {
        if (PlayerPrefs.HasKey("checkpoint"))
        {
            GameManager.Instance.player.transform.position = Spawns[PlayerPrefs.GetInt("checkpoint")].position;
        }
        else
        {
            PlayerPrefs.SetInt("checkpoint", 0);
        }
    }
}
