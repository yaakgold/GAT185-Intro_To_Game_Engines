using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class Impact : MonoBehaviour
{
    public float force = 10;
    public float damage = 10;
    public bool isRadial = false;

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
            float scale = 1;
            if(isRadial)
            {
                float dist = Vector3.Distance(transform.position, other.transform.position);
                scale = 1 - (dist / sc.radius);
            }

            h.AddHealth(-damage * scale);
        }

        Rigidbody rb = other.GetComponent<Rigidbody>();
        if(rb != null && sc != null)
        {
            rb.AddExplosionForce(force, transform.position, sc.radius);
        }
    }
}
