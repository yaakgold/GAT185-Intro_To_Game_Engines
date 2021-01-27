using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class DoorAnim : MonoBehaviour
{
    [Range(1, 10)] public float speed = 1;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetFloat("Speed", speed);

        if(Input.GetKeyDown(KeyCode.O))
        {
            anim.SetTrigger("OpenDoor");
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.SetTrigger("CloseDoor");
        }
    }
}
