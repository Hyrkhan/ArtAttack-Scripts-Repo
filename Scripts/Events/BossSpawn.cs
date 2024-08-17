using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossSpawn : MonoBehaviour
{
    public GameObject enemyPrefab; // Drag the prefab into this field in the Unity editor
    public GameObject edgeobject;
    public Transform spawnPoint; // The location where enemies will be spawned
    public Transform healthbar;
    public GameObject bossAlertPrefab;


    private float startTimer = 0f;
    private float hideTimer = 0f;
    private bool spawned;

    void Start()
    {
        spawned = false;
    }
    void Update()
    {

    }
    private void FixedUpdate()
    {
        startTimer += Time.deltaTime;
        hideTimer += Time.deltaTime;
        if (!spawned)
        {
            if (startTimer >= 180f)
            {
                GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
                GameObject foothold = Instantiate(edgeobject, spawnPoint.position, Quaternion.identity);

                bossAlertPrefab.SetActive(true);
                startTimer = 0;
                spawned = true;
            }
        }
        if (hideTimer >= 184f)
        {
            bossAlertPrefab.gameObject.SetActive(false);
            hideTimer = 0;
        }
    }
}

