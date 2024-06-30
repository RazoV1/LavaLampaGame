using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BugController : MonoBehaviour
{

    public Kukaracha bugPrefab;
    public Kukaracha[] bugs;
    
    public List<Transform> spawnPositions;
    public List<Transform> emptySpawnPositions;

    public bool isSecondScene;

    public float spawnSpeed;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(SpawnBugs(3, spawnSpeed));
        }
    }

    public IEnumerator SpawnBugs(int count, float timeToSpawn)
    {
        GetComponent<BoxCollider2D>().enabled = false;
        for (int i = 1; i <= count; i++)
        {
            while (emptySpawnPositions.Count == 0) yield return new WaitForSeconds(1f);
            Kukaracha spawnedBug = Instantiate(bugPrefab);
            spawnedBug.spawnPos = emptySpawnPositions[Random.Range(0, emptySpawnPositions.Count)];
            emptySpawnPositions.Remove(spawnedBug.spawnPos);
            spawnPositions.Add(spawnedBug.spawnPos);
            spawnedBug.transform.position = spawnedBug.spawnPos.position;
            spawnedBug.bugController = this;
            spawnedBug.StartIncubating();
            
            if(isSecondScene) spawnedBug.number =
                GameManager.Instance.bugNumbers[Random.Range(0, 2)];
            else spawnedBug.number =
                GameManager.Instance.bugNumbers[Random.Range(0, GameManager.Instance.bugNumbers.Length)];
            yield return new WaitForSeconds(timeToSpawn);
        }
    }
}
