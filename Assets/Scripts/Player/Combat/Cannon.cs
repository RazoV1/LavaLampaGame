using platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] private bool isActive = false;
    [SerializeField] private bool isInPlayersRange = false;

    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject bullet;
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
        }

        if (isActive)
        {
            var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}