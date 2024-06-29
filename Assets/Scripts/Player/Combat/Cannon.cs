using System;
using platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private bool isInPlayersRange = false;


    private PlayerController playerController;
    
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject hidePlatformsParent;


    private void Start()
    {
        playerController = GameManager.Instance.player.GetComponent<PlayerController>();
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
            isActive = !isActive;
            playerController.enabled = !isActive;
            playerController.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            for(int i = 0; i < hidePlatformsParent.transform.childCount; i++)
            {
                Transform localPlatformParent = hidePlatformsParent.transform.GetChild(i);
                for (int j = 0; j < localPlatformParent.childCount; j++)
                {
                    if(isActive) {
                        localPlatformParent.GetChild(j).GetComponent<SpriteRenderer>().color =
                            new Color(1, 1,1, 0.3f);
                        
                    }
                    else
                    {
                        localPlatformParent.GetChild(j).GetComponent<SpriteRenderer>().color =
                            new Color(1, 1,1, 1);
                    }
                }
            }
        }

        if (isActive)
        {
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (Input.GetMouseButtonDown(0))
            {
                var bulletInPlayerInv = playerController.currentAmmunition.gameObject;
                if (bulletInPlayerInv != null)
                {
                    var bulletInstance = Instantiate(bulletInPlayerInv,transform.position,Quaternion.identity);
                    bulletInstance.GetComponent<Rigidbody2D>().velocity=((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position)*bulletSpeed);
                    playerController.currentAmmunition = null;
                }
            }
        }
    }
}
