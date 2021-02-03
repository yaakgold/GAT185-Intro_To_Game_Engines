using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public float addHealthAmount;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<Health>();

        if (health != null)
        {
            health.AddHealth(addHealthAmount);
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
