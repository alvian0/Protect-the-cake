using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public float SpawnInterval = 1f;
    public Transform[] SpawnPos;
    public GameObject[] RandomThings;

    float SpawnRate;
    void Start()
    {
        SpawnRate = SpawnInterval;
    }

    void Update()
    {
        if (SpawnRate <= 0)
        {
            Instantiate(RandomThings[Random.Range(0, RandomThings.Length)],
                SpawnPos[Random.Range(0, SpawnPos.Length)].position,
                Quaternion.identity);
            SpawnRate = SpawnInterval;
        }

        else
        {
            SpawnRate -= Time.deltaTime;
        }
    }
}
