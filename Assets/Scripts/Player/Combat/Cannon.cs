using Assets.Scripts.Player.Movement;
using UnityEngine;

namespace Assets.Scripts.Player.Combat
{
    public class Cannon : MonoBehaviour
    {
        [SerializeField] private bool isActive = false;
        [SerializeField] private bool isInPlayersRange = false;


        private PlayerController playerController;

        [SerializeField] private GameObject bullet;
        [SerializeField] private float bulletSpeed;
        [SerializeField] private GameObject hidePlatformsParent;
        [SerializeField] private Transform bulletSpawn;

        [SerializeField] private AudioSource bulletSpawnAudioSource;

        [SerializeField] private ParticleSystem fire;


        private void Start()
        {
            playerController = GameManager.Instance.player.GetComponent<PlayerController>();
            bulletSpawnAudioSource = GetComponent<AudioSource>();
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
                isActive = false;
                for (int i = 0; i < hidePlatformsParent.transform.childCount; i++)
                {
                    Transform localPlatformParent = hidePlatformsParent.transform.GetChild(i);
                    for (int j = 0; j < localPlatformParent.childCount; j++)
                    {

                        localPlatformParent.GetChild(j).GetComponent<SpriteRenderer>().color =
                            new Color(1, 1, 1, 1);
                        localPlatformParent.GetChild(j).GetComponent<BoxCollider2D>().enabled = true;
                    }
                }
            }
        }
        public void Update()
        {
            if (isInPlayersRange && Input.GetKeyDown(KeyCode.E))
            {
                isActive = !isActive;
                playerController.enabled = !isActive;
                playerController.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
                for (int i = 0; i < hidePlatformsParent.transform.childCount; i++)
                {
                    Transform localPlatformParent = hidePlatformsParent.transform.GetChild(i);
                    for (int j = 0; j < localPlatformParent.childCount; j++)
                    {
                        if (isActive)
                        {
                            localPlatformParent.GetChild(j).GetComponent<SpriteRenderer>().color =
                                new Color(1, 1, 1, 0.3f);
                            localPlatformParent.GetChild(j).GetComponent<BoxCollider2D>().enabled = false;
                        }
                        else
                        {
                            localPlatformParent.GetChild(j).GetComponent<SpriteRenderer>().color =
                                new Color(1, 1, 1, 1);
                            localPlatformParent.GetChild(j).GetComponent<BoxCollider2D>().enabled = true;
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
                        var bulletInstance = Instantiate(bulletInPlayerInv, bulletSpawn.position, Quaternion.identity);
                        bulletInstance.GetComponent<Rigidbody2D>().velocity = ((Camera.main.ScreenToWorldPoint(Input.mousePosition) - bulletSpawn.position).normalized * bulletSpeed);
                        bulletInstance.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                        playerController.currentAmmunition = null;
                        fire.Play();
                        bulletSpawnAudioSource.Play();
                    }
                }
            }
        }
    }
}
