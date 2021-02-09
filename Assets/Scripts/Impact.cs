using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Impact : MonoBehaviour
{
    public float force = 10;
    public float damage = 10;

    SphereCollider sc;

    private void Start()
    {
        sc = GetComponent<SphereCollider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Health h = other.GetComponent<Health>();
        if(h != null)
        {
            h.AddHealth(-damage);
        }

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null)
        {
            rb.AddExplosionForce(force, transform.position, sc.radius);
        }
    }
}
