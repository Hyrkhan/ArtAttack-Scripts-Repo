using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Drag the prefab into this field in the Unity editor
    private float spawnInterval; // The interval between spawns, in seconds
    public Transform spawnPoint; // The location where enemies will be spawned
    public Transform healthbar;

    private float timer = 0f;
    private float timers = 0f;
    private bool active = true; // added this line

    void Start()
    {
        spawnInterval = 3f;
    }
    void Update()
    {
        if (Time.timeSinceLevelLoad >= 90f)
        {
            active = false;
        }

    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        timers += Time.deltaTime;
        if (timers >= 10f)
        {
            if (spawnInterval > 0.5f)
            {
                spawnInterval -= 0.5f;
            }
            timers = 0f;
        }
        if (active) // added this line
        {
            if (timer >= spawnInterval)
            {
                timer = 0f;
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            }
        }
    }

}
