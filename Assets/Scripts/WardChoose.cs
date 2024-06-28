using System;
using System.Collections;
using System.Collections.Generic;
using platformer;
using Unity.VisualScripting;
using UnityEngine;

public class WardChoose : MonoBehaviour
{
    [SerializeField] private GameObject test;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            test.SetActive(true);
            GameManager.Instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameManager.Instance.player.GetComponent<PlayerController>().enabled = false;
            GameManager.Instance.player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CloseWard();
        }
    }

    public void CloseWard()
    {
        test.SetActive(false);
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = true;
    }
}
