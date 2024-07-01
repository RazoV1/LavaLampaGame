using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;


public class KukarachaWord : Kukaracha
{
    
    
    [SerializeField] private TextMeshPro nameTextMesh;
    public string nameStr;
    public char[] nameArray;
    public int HP;

    private int counter;
    
    public void Start()
    {
        GetComponent<AudioSource>().Stop();
        timeToSpawn = 10f;
        timeToSpawnText = timeToSpawnText.gameObject.GetComponent<TextMeshPro>();
       // nameStr = bugController.bugStrings[Random.Range(0, GameManager.Instance.bugStrings.Length)];
        nameTextMesh.GetComponent<TextMeshPro>().text = nameStr;
        nameArray = nameStr.ToCharArray();
        playerPos = GameManager.Instance.player.transform;
        gameObject.tag = number.ToString();
            
        int.TryParse(gameObject.tag, out counter);
        if (counter == 1 || counter == 2) counter *= 8;
        HP = nameArray.Length * counter;
        //text.text = number.ToString() + "\n���";
    }
    
    /*public BugController bugController;

    [SerializeField] private float speed;
    public int number;
    [SerializeField] private Transform playerPos;

    

    
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
        GetComponent<AudioSource>().Play();
        isIncubating = false;
    }

    public void StartIncubating()
    {
        isMoving = false;
        isIncubating = true;
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
    }*/

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("8") || other.CompareTag("16"))
        {

            int damage;
            int.TryParse(other.tag, out damage);
            HP -= damage;
            if (HP <= 0) Destroy(gameObject);

            if (HP % counter == 0)
            {
                string outputName = "";
                for (int i = 0; i < (HP/counter); i++)
                {
                    outputName = outputName + nameArray[i];
                }

                nameStr = outputName;
                nameTextMesh.text = outputName;
            }
        }
    }
}
