using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int points;
    public Material mat;

    private void Start()
    {
        GetComponent<Renderer>().material = mat;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Projectile"))
        {
            Game.Instance.AddScore(points);
            Destroy(transform.parent.gameObject);
        }
    }
}
