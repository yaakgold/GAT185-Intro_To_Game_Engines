using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray mouse = Camera.main.ScreenPointToRay(Input.mousePosition);
            //mouse.z = 5;
            //Vector3 dir = (mouse - transform.position).normalized;

            Bullet b = Instantiate(bullet.gameObject, transform.position, Quaternion.identity).GetComponent<Bullet>();
            b.Fire(mouse.direction);
            //Destroy(b, 3);
        }
    }
}
