using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObj;
    public float spawnTimeMin = 2, spawnTimeMax = 5;

    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount == 0)
        {
            spawnTimer -= Time.deltaTime;
        }

        if(spawnTimer <= 0)
        {
            Instantiate(spawnObj, transform.position, transform.rotation, transform);
            spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
        }
    }
}
