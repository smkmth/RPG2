using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BridgeGoon : MonoBehaviour {

	public Transform[] patrolpoints;
	public string AIState;
	private int destpoint = 0;
	private NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		agent.autoBraking = false;
		AIState = "Idle";
		
	}


	
	// Update is called once per frame
	void GoToNextPoint(){
		
		if (patrolpoints.Length == 0) {
			return; 
		}
		agent.destination = patrolpoints [destpoint].position;
		destpoint = (destpoint + 1) % patrolpoints.Length;


	}
	void Update(){
		if (AIState == "Idle") {
			StartCoroutine (waiter ());
			AIState = "MoveSomewhere";
			Debug.Log("AI State = " + AIState);

		} else if (AIState == "MoveSomewhere") {
			//Debug.Log ("destination = " + agent.destination);
			if (agent.destination != null) {
				GoToNextPoint ();

				if (!agent.pathPending && agent.remainingDistance < 0.5f) {
					Debug.Log ("AI State = " + AIState);

					AIState = "Idle";
				}
			}
		}
	}
	IEnumerator waiter()
	{
		int wait_time = Random.Range (120, 600);
		yield return new WaitForSeconds(wait_time);
		print ("I waited for "+ wait_time + "sec");

	}
}
