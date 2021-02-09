using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnObj;
    public float spawnTimeMin = 2, spawnTimeMax = 5;
    public bool isSpawnChild = true;

    private float spawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    // Update is called once per frame
    void Update()
    {
        if(Game.Instance.State == Game.eState.GAME)
        {
            if(transform.childCount == 0)
            {
                spawnTimer -= Time.deltaTime;
            }

            if(spawnTimer <= 0)
            {
                spawnTimer = Random.Range(spawnTimeMin, spawnTimeMax);
                Transform parent = (isSpawnChild) ? transform : null;
                Instantiate(spawnObj, transform.position, transform.rotation, parent);
            }
        }
    }
}
