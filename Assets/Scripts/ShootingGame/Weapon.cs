using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Range(0, 3)] public float fireRate = 0.1f;
    [Range(0, 100)] public float angle = 10.0f;
    public GameObject projectile;
    public int maxAmmo;
    public Transform emitTransform;
    
    private int ammo = 100;
    private float fireTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer += Time.deltaTime;
    }

    public bool Fire(Vector3 position, Vector3 direction)
    {
        if(fireTimer >= fireRate && ammo > 0)
        {
            Projectile b = Instantiate(projectile.gameObject, position, Quaternion.identity).GetComponent<Projectile>();
            b.Fire(direction);
            Destroy(b, 20);

            fireTimer = 0;
            //ammo--;

            return true;
        }
        return false;
    }

    public bool Fire(Vector3 direction)
    {
        if (fireTimer >= fireRate && ammo > 0)
        {
            Projectile b = Instantiate(projectile.gameObject, emitTransform.position, emitTransform.rotation).GetComponent<Projectile>();
            b.Fire(direction);
            Destroy(b, 20);

            fireTimer = 0;
            //ammo--;

            return true;
        }
        return false;
    }
}
