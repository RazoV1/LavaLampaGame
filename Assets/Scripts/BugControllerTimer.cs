using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts.Enemies.Kukaracha;
using Assets.Scripts.Environment.Door;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class BugControllerTimer : MonoBehaviour
    {

        [SerializeField] private TextMeshProUGUI _timer;
        [SerializeField] private TextMeshProUGUI _size;
        [SerializeField] private Canvas _canvas;
        [Space(10)]
        public Wave[] Waves = new Wave[0];
        
        [HideInInspector]public List<Transform> spawnPositions;
        public List<Transform> emptySpawnPositions;

        public float spawnSpeed;

        public DoorByTrigger closedDoor;
        public DoorByTrigger nextDoor;

        private int _currentBug=0;

        private void Awake()
        {
            _canvas.gameObject.SetActive(false);
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                StartCoroutine(SpawnBugs(spawnSpeed));
            }
        }

        public IEnumerator SpawnBugs(float timeToSpawn)
        {
            _canvas.gameObject.SetActive(true);
            _timer.text = "";
            GetComponent<BoxCollider2D>().enabled = false;
            SoundsBaseCollection.Instance.fightMusic.Play();

            foreach (var wave in Waves)
            {
                KukarachaWord trueCockrouch = SpawnedBug(wave.truePrefab);
                KukarachaWord[] falseCocks = new KukarachaWord[wave.falsePrefabs.Length];


                for (int i = 0; i < wave.falsePrefabs.Length; i++)
                {
                    falseCocks[i] = SpawnedBug(wave.falsePrefabs[i]);
                }

                float left = wave.time + trueCockrouch.timeToSpawn;
                _size.text = wave.sizeText;
                while (true)
                {
                    
                    left -= Time.deltaTime;
                    if (trueCockrouch == null)
                    {
                        foreach (var kukarachaWord in falseCocks) Destroy(kukarachaWord.gameObject);
                        break;
                    }
                    foreach (var kukarachaWord in falseCocks)
                    {
                        if (kukarachaWord == null) SceneManager.LoadScene(1);
                    }

                    if (left <= 0)
                    {
                        SceneManager.LoadScene(1);
                    }

                    if (left - wave.time <= 0) _timer.text = Mathf.Round(left).ToString();
                    else _timer.text = "";
                    
                    
                    yield return null;
                }

                while (spawnPositions.Count != 0)
                {
                    Transform point = spawnPositions[0];
                    spawnPositions.Remove(point);
                    emptySpawnPositions.Add(point);
                }
            }
            
            Finish();
        }

        private void Finish()
        {
            SoundsBaseCollection.Instance.fightMusic.Stop();
            closedDoor.Open();
            nextDoor.Open();
        }

        private KukarachaWord SpawnedBug(KukarachaWord bugPrefab)
        {
            KukarachaWord spawnedBug = Instantiate(bugPrefab);

            spawnedBug.spawnPos = emptySpawnPositions[Random.Range(0, emptySpawnPositions.Count)];
            
            emptySpawnPositions.Remove(spawnedBug.spawnPos);
            spawnPositions.Add(spawnedBug.spawnPos);

            spawnedBug.transform.position = spawnedBug.spawnPos.position;

            //spawnedBug.bugController = this;

            spawnedBug.StartIncubating();
            return spawnedBug;
        }
    }

    [Serializable]
    public class Wave
    {
        public KukarachaWord[] falsePrefabs;
        public KukarachaWord truePrefab;
        public float time = 10f;
        public string sizeText;
    }
}
