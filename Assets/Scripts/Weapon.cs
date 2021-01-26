using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float fireRate = 0.1f;
    public GameObject bullet;
    
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
            Bullet b = Instantiate(bullet.gameObject, position, Quaternion.identity).GetComponent<Bullet>();
            b.Fire(direction);
            Destroy(b, 20);

            fireTimer = 0;
            //ammo--;

            return true;
        }
        return false;
    }
}
