using platformer;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFire : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private PlayerController playerController;

    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed;

    private void Fire()
    {
        var bulletInstance = Instantiate(bulletPrefab, bulletSpawn.position,Quaternion.identity);
        bulletInstance.GetComponent<Rigidbody2D>().velocity = new Vector2(playerController.horisontalInputValue * bulletSpeed,0);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }
}