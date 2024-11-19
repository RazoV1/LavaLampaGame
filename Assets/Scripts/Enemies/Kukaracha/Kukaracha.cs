using System.Collections.Generic;
using Assets.Scripts.Player.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Enemies.Kukaracha
{
    public class Kukaracha : MonoBehaviour
    {
        [SerializeField] private float speed;
        public int number;
        [SerializeField] protected Transform playerPos;

        [SerializeField] private List<AudioClip> funnySounds;
        

        public BugController bugController;
    
        public Transform spawnPos;

        [SerializeField] private TMP_Text text;
        [SerializeField] private float turnSpeed;
        [Space(5)]
        [SerializeField] private bool _timer = false;


        public bool isMoving = false;
        public bool isIncubating = false;

        public float timeToSpawn;
        public TextMeshPro timeToSpawnText;

        protected virtual void StartDeathMarch()
        {
            isMoving = true;
            GetComponent<BoxCollider2D>().enabled = true;
            GetComponent<Animator>().SetTrigger("Bug");
        
            GetComponent<Animator>().SetInteger("num",number);
            //number *= 8;
        
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
                if (_timer)
                {
                    transform.eulerAngles = transform.eulerAngles + new Vector3(0f, 0f, 180f);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            print("Trigger Enter by " + other.gameObject.name);
            BulletBehaviour bullet;
            if (other.TryGetComponent<BulletBehaviour>(out bullet))
            {
                print("TRY GET COMPONENT");
                if (bullet.damage == number)
                {
                    print("BULLET DAMAGE = NUMBER");
                    if (bugController)
                    {
                        print("BUG CONTROLLER");

                        bugController.emptySpawnPositions.Add(spawnPos);
                        bugController.spawnPositions.Remove(spawnPos);
                    }
                    
                    Destroy(other.gameObject);
                    Destroy(gameObject);
                }
            }
            else if (other.tag == "Player")
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
