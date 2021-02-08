using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    [Range(1, 100)]
    public float speed = 10.0f;
    public float lifeTime;
    public GameObject spawnObj;
    public bool destroyOnColl;

    Rigidbody rb;

    private void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    private void OnDestroy()
    {
        if(spawnObj != null)
        {
            Instantiate(spawnObj, transform.position, transform.rotation);
        }
    }

    // Start is called before the first frame update
    public void Fire(Vector3 forward)
    {
        rb = GetComponent<Rigidbody>();

        rb.AddForce(forward * speed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(destroyOnColl && !collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
