using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float addHealthAmount;
    public GameObject spawnObject;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.AddHealth(addHealthAmount);
            if(spawnObject != null)
            {
                Destroy(Instantiate(spawnObject, transform.position, transform.rotation, other.transform), 2);
            }
            
            Destroy(gameObject);
        }
    }
}
