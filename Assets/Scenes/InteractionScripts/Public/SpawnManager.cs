using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject targetPrefab; 
    public Transform boundOne;     
    public Transform boundTwo;      

    public float minSpawnInterval = 2f; 
    public float maxSpawnInterval = 4f; 

    public float minHeight = 1f; 
    public float maxHeight = 5f; 

    private void Start()
    {
        StartCoroutine(SpawnTargets());
    }

    private IEnumerator SpawnTargets()
    {
        while (true)
        {
            float waitTime = Random.Range(minSpawnInterval, maxSpawnInterval);
            yield return new WaitForSeconds(waitTime);

            SpawnTarget();
        }
    }

    private void SpawnTarget()
    {
        float spawnHeight = Random.Range(minHeight, maxHeight);

        Vector3 spawnPosition = new Vector3(boundOne.position.x, spawnHeight, boundOne.position.z);

        GameObject target = Instantiate(targetPrefab, spawnPosition, Quaternion.identity);

        MoveToDestination(target);
    }

    private void MoveToDestination(GameObject target)
    {
        float destinationHeight = Random.Range(minHeight, maxHeight);

        Vector3 destinationPosition = new Vector3(boundTwo.position.x, destinationHeight, boundTwo.position.z);

        TargetMover mover = target.AddComponent<TargetMover>();
        mover.SetDestination(destinationPosition);
    }
}
