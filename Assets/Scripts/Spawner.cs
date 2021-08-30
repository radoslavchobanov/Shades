using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> typeObjectsToSpawn;
    public int density; // count objects to spawn
    public float timeBetweenSpawn;

    private float timeForNextSpawn;

    // private float activationRange; // ?? distance to the player ??

    private void Awake()
    {
        timeForNextSpawn = Time.time + timeBetweenSpawn;
    }

    private void Update() 
    {
        if (Time.time >= timeForNextSpawn)
        {
            timeForNextSpawn = Time.time + timeBetweenSpawn;
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        GameObject objToSpawn = GetRandomObjectToSpawn();

        Instantiate(objToSpawn, this.transform.position, this.transform.rotation);
        
        density -= 1;
        if (density == 0)
            this.gameObject.SetActive(false);
    }

    private GameObject GetRandomObjectToSpawn()
    {
        return typeObjectsToSpawn[Random.Range(0, typeObjectsToSpawn.Count)];
    }
}
