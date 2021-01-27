using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [Range(1, 100)]
    public float speed = 10.0f;
    public float lifeTime;

    Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    // Start is called before the first frame update
    public void Fire(Vector3 forward)
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(forward * speed, ForceMode.VelocityChange);
    }
}
