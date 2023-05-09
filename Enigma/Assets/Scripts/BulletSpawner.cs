using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.3f;
    public float spawnRateMax = 2f;
    public float spawnRate;

    //public float timeAfterSpawn;

    GameManager gamemanager;

    // Start is called before the first frame update
    void Start()
    {
        gamemanager = FindObjectOfType<GameManager>();
        StartCoroutine(SpawnBullet());
        //timeAfterSpawn = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(Time.deltaTime);
        /*
        timeAfterSpawn += Time.deltaTime;

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
        */
    }

    IEnumerator SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        //Debug.Log(Time.deltaTime);
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        yield return new WaitForSeconds(spawnRate);

        if (!gamemanager.isGameover)
        {
            StartCoroutine(SpawnBullet());
        }
    }
}
