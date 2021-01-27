using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitSpawner : MonoBehaviour
{
    public GameObject spawnGameObject;
    public float lifetime = 5;
    public bool useLifetime = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            var go = Instantiate(spawnGameObject, transform);
            if (useLifetime)
                Destroy(go, lifetime);
        }
    }
}
