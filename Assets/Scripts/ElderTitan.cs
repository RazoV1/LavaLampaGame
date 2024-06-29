using System.Collections;
using System.Collections.Generic;
using platformer;
using UnityEngine;

public class ElderTitan : MonoBehaviour
{
    [SerializeField] private GameObject test;

    private bool canOpen = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GetComponent<Animator>().SetTrigger("On");
            transform.GetChild(0).gameObject.SetActive(true);
            canOpen = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canOpen)
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
            GetComponent<Animator>().SetTrigger("Off");
            canOpen = false;
            CloseWard();
        }
    }

    public void CloseWard()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        test.SetActive(false);
        GameManager.Instance.player.GetComponent<PlayerController>().enabled = true;
    }
}
