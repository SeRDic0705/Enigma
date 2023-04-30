using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float spawnRateMin = 0.3f;
    public float spawnRateMax = 2f;

    private Transform target;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().transform;

        StartCoroutine(SpawnBullet());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        bullet.transform.LookAt(target);

        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        yield return new WaitForSeconds(spawnRate);

        StartCoroutine(SpawnBullet());
    }
}
