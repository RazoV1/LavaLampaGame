using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemies.Kukaracha;
using Assets.Scripts.Environment.Door;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class BugController : MonoBehaviour
    {

        public Kukaracha bugPrefab;
        public Kukaracha[] bugs = new Kukaracha[0];
    
        public List<Transform> spawnPositions;
        public List<Transform> emptySpawnPositions;
        public List<int> bugNums;
        public List<string> bugStrings;

        [SerializeField] private int bugCount;

        public float spawnSpeed;

        public DoorByTrigger closedDoor;
        public DoorByTrigger nextDoor;

        private int _currentBug=0;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(SpawnBugs(bugCount, spawnSpeed));
            }
        }

        public IEnumerator SpawnBugs(int count, float timeToSpawn)
        {
            GetComponent<BoxCollider2D>().enabled = false;
            SoundsBaseCollection.Instance.fightMusic.Play();
            for (int i = 0; i <= count; i++)
            {
                while (emptySpawnPositions.Count == 0) yield return new WaitForSeconds(1f);

                if (bugs.Length != 0)
                {
                    bugPrefab = bugs[i];
                    _currentBug++;
                }
                Kukaracha spawnedBug = Instantiate(bugPrefab);
            
                spawnedBug.spawnPos = emptySpawnPositions[Random.Range(0, emptySpawnPositions.Count)];
            
                emptySpawnPositions.Remove(spawnedBug.spawnPos);
                spawnPositions.Add(spawnedBug.spawnPos);
            
                spawnedBug.transform.position = spawnedBug.spawnPos.position;
                spawnedBug.bugController = this;
                spawnedBug.StartIncubating();
                if (bugs.Length == 0)
                {
                    spawnedBug.number = bugNums[i];
                }
            
                while (spawnedBug != null)
                {
                    yield return null;
                }
            }
            SoundsBaseCollection.Instance.fightMusic.Stop();
            closedDoor.Open();
            nextDoor.Open();
        }
    }
}
