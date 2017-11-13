using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Movement : MonoBehaviour{

	NavMeshAgent agent;
	public GameState _GameState;

	void Start(){
		agent = GetComponent<NavMeshAgent> ();
	}

	void Update(){
		if (Input.GetMouseButtonDown (0) && _GameState.gameState == 1) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit, 100)) {
				if (hit.transform.tag == "Ground") {	
					agent.SetDestination (hit.point);
				} else if (hit.transform.tag == "NPC"){
					NPC targetnpc = hit.transform.gameObject.GetComponent<NPC>();
					agent.SetDestination (targetnpc.InteractionCube.transform.position);
					targetnpc.TalkToThisNPC ();
				}
			}
		}
	}
}