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
    [SerializeField] private float turnSpeed;


    public bool isMoving = false;
    public bool isIncubating = false;

    public float timeToSpawn;
    public TextMeshPro timeToSpawnText;

    public void StartDeathMarch()
    {
        isMoving = true;
        GetComponent<Animator>().SetTrigger("Bug");
        GetComponent<Animator>().SetInteger("num",number);
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
        timeToSpawn = 10f;
        timeToSpawnText = timeToSpawnText.gameObject.GetComponent<TextMeshPro>();

        playerPos = GameManager.Instance.player.transform;
        gameObject.tag = number.ToString();
        text.text = number.ToString() + "\n���";
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
            transform.Translate(Vector2.down * speed * Time.deltaTime);
            var direction = playerPos.position - transform.position;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
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
