using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Kukaracha : MonoBehaviour
{
    [SerializeField] private float speed;
    public int number;
    [SerializeField] private Transform playerPos;

    public BugController bugController;
    
    public Transform spawnPos;

    [SerializeField] private TMP_Text text;

    public bool isMoving = false;
    public bool isIncubating = false;

    public float timeToSpawn;
    public TextMeshPro timeToSpawnText;

    public void StartDeathMarch()
    {
        isMoving = true;
        GetComponent<Animator>().SetTrigger("Bug");
        GetComponent<AudioSource>().Play();
        isIncubating = false;
    }

    public void StartIncubating()
    {
        isMoving = false;
        isIncubating = true;
    }
    
    public void Start()
    {
        GetComponent<AudioSource>().Stop();
        timeToSpawn = 1f;
        timeToSpawnText = timeToSpawnText.gameObject.GetComponent<TextMeshPro>();

        playerPos = GameManager.Instance.player.transform;
        gameObject.tag = number.ToString();
        text.text = number.ToString();
    }

    private void Update()
    {
        if (isIncubating)
        {
            timeToSpawn -= Time.deltaTime;
            if (timeToSpawn <= 0)
            {
                timeToSpawnText.gameObject.SetActive(false);
                StartDeathMarch();
            }
            else
            {
                timeToSpawnText.text = ((int)timeToSpawn).ToString();
            }
        }
        
        else if (isMoving)
        {
            transform.Translate((playerPos.position-transform.position).normalized * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(gameObject.tag))
        {
            bugController.emptySpawnPositions.Add(spawnPos);
            bugController.spawnPositions.Remove(spawnPos);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
