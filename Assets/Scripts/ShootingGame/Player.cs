using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Weapon[] weapons;

    // Update is called once per frame
    void Update()
    {
        //Vector3 velocity = Vector3.zero;

        //velocity.x = Input.GetAxis("Horizontal");
        //velocity.z = Input.GetAxis("Vertical");

        //if(Input.GetButtonDown("Jump"))
        //{
        //    velocity.y = 400;
        //}

        //transform.position = Vector3.Lerp(transform.position, transform.position + velocity * speed, Time.deltaTime);

        if(Game.Instance.State == Game.eState.GAME)
        {
            if(Input.GetButtonDown("Fire1"))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                weapons[0].Fire(ray.origin, ray.direction);
            }
        }
    }
}
