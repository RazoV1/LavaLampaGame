using Assets.Scripts.Player.Combat;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Enemies.Kukaracha
{
    public class KukarachaWord : Kukaracha
    {
        [SerializeField] private TextMeshPro nameText;
        
        
        public string nameStr;

        private void Awake()
        {
            nameText.text = nameStr;
        
        }

        protected override void StartDeathMarch()
        {
            base.StartDeathMarch();
            number = number * nameStr.Length;
        }
    

        private void OnTriggerEnter2D(Collider2D other)
        {
            BulletBehaviour bullet;
            if (other.TryGetComponent(out bullet))
            {
                number -= bullet.damage;
                if (number <= 0)
                {
                    if (bugController)
                    {
                        bugController.emptySpawnPositions.Add(spawnPos);
                        bugController.spawnPositions.Remove(spawnPos);
                    }
                    
                    Destroy(gameObject);
                }
                Destroy(other.gameObject);
            

            }
            else if (other.tag == "Player")
            {
                SceneManager.LoadScene(1);
            }
        }
    }
}
