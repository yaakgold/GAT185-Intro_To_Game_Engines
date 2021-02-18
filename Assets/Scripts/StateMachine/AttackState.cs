using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public float attackTimeMin = 0.5f;
    public float attackTimeMax = 2.0f;
    public float meleeDistance = 4.0f;

    float timer;
    float attackTimer;
    Vector3 lastTargetPos;

    public override void Enter(Agent owner)
    {
        Debug.Log(GetType().Name + " Enter");
        attackTimer = Random.Range(attackTimeMin, attackTimeMax);
    }

    public override void Execute(Agent owner)
    {
        GameObject[] gameObjects = owner.perception.GetGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");

        //Player seen
        if(player != null)
        {
            lastTargetPos = player.transform.position;
            timer = 1;

            attackTimer -= Time.deltaTime;
            if(attackTimer <= 0)
            {
                float distance = Vector3.Distance(owner.transform.position, player.transform.position);
                if (distance < meleeDistance)
                {
                    ((StateAgent)owner).StateMachine.SetState("AttackMeleeState");
                }
                else
                {
                    ((StateAgent)owner).StateMachine.SetState("AttackRangeState");
                }
            }
        }

        owner.movement.MoveTowards(lastTargetPos);

        if (player == null)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ((StateAgent)owner).StateMachine.SetState("IdleState");
            }
        }
    }

    public override void Exit(Agent owner)
    {
        Debug.Log(GetType().Name + " Exit");
    }
}
