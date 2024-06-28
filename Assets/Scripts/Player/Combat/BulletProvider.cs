using platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProvider : MonoBehaviour
{
    public PlayerController playerController;
    public bool isInPlayersRange = false;

    [SerializeField] private GameObject providedBullet;

    public void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInPlayersRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isInPlayersRange = false;
        }
    }

    public void Update()
    {
        if (isInPlayersRange && Input.GetKeyDown(KeyCode.E))
        {
            playerController.currentAmmunition = providedBullet;
            Destroy(gameObject);
        }
    }
}
