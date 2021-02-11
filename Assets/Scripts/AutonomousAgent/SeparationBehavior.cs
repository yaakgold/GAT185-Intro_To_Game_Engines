using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeparationBehavior : Behavior
{
    public override Vector3 Execute()
    {
		Vector3 force = Vector3.zero;

		GameObject[] gameObjects = perception.GetGameObjects();
		if (gameObjects != null && gameObjects.Length > 0)
		{
			// ****
			Vector3 positions = Vector3.zero;
			foreach (GameObject go in gameObjects)
			{
				Vector3 v = Agent.transform.position - go.transform.position;
				v = v.normalized / v.magnitude;
				positions += v;
			}

			Vector3 center = positions / gameObjects.Length;

			Vector3 direction = (center).normalized;

			//****

			Vector3 desired = direction * Agent.maxSpeed;
			force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);

			Debug.DrawRay(transform.position, desired, Color.red);//Desired
			Debug.DrawRay(transform.position + Agent.Velocity, force, Color.green);//Steering
		}

		return force;
	}
}
