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
            Spawns[PlayerPrefs.GetInt("checkpoint")].GetComponent<Checkpoint>().playerLight.shapeLightFalloffSize = Spawns[PlayerPrefs.GetInt("checkpoint")].GetComponent<Checkpoint>().radius;
        }
        
    }
}
