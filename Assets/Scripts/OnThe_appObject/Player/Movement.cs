using System;
using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class Movement : MonoBehaviour{

	NavMeshAgent agent;
	public GameState _GameState;
	public GameObject _OnScreenGUI;
	public GameObject InfoPrefab;
	public List<GameObject> InfoBoxList = new List<GameObject> ();
	public GlobalItemHandler _GlobalItemHandler;
	//public float rotationspeed;
	public GameObject Player;
	void Start(){
		agent = GetComponent<NavMeshAgent> ();

		_GlobalItemHandler = GameObject.FindGameObjectWithTag ("Manager").GetComponent<GlobalItemHandler> ();

	}

	void Update(){
		if(_GameState._GameState == "PlayMode") {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Input.GetMouseButtonDown (0)) {
				foreach (GameObject infobox in InfoBoxList) {
					Destroy (infobox);
				}
				if (Physics.Raycast (ray, out hit, 100)) {
					if (hit.transform.tag == "Ground") {
						agent.SetDestination (hit.point);
						//agent.updateRotation = true;


					} else if (hit.transform.tag == "NPC") {
						NPC targetnpc = hit.transform.gameObject.GetComponent<NPC> ();
						agent.SetDestination (targetnpc.InteractionCube.transform.position);
						targetnpc.TalkToThisNPC ();
					} else if (hit.transform.tag == "Item") {
						ItemHandler targetitem = hit.transform.gameObject.GetComponent<ItemHandler> ();
						agent.SetDestination (targetitem.transform.position);
						//targetitem.PickUpItem ();
						if (!agent.pathPending) {
							if (agent.remainingDistance <= agent.stoppingDistance) {
								Debug.Log ("Test 2");
								if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
									Debug.Log ("test 3");
									
									targetitem.PickUpItem ();
									Debug.Log ("Trying to pick up item ");
								}
							}
						}
					} else if (hit.transform.tag == "Interactable") {
					Interactable targetinteraction = hit.transform.gameObject.GetComponent<Interactable> ();
					agent.SetDestination (targetinteraction.InteractableMaker.transform.position);
					if (!agent.pathPending) {
							if (agent.remainingDistance <= agent.stoppingDistance) {
								Debug.Log ("Test 2");
								if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f) {
									Debug.Log ("test 3");
									targetinteraction.UseObject ();
								}//move towards target test 3
							}//move towards target twst two
						}//test 0one

					

					
					}//end of interactable
				}//  /\ /\ /\ end of physics hit \/ \/ \/ start of right click while in play mode
			} else if (Input.GetMouseButtonDown (1)) {
				_OnScreenGUI = GameObject.FindGameObjectWithTag ("OnScreenGUI");

				foreach (GameObject infobox in InfoBoxList) {
					Destroy (infobox);
				}
				if (Physics.Raycast (ray, out hit, 100)) {
					
					if (hit.transform.tag == "NPC") {
						NPC targetnpc = hit.transform.gameObject.GetComponent<NPC> ();
						GameObject infobox = Instantiate (InfoPrefab);
						infobox.transform.SetParent (_OnScreenGUI.transform, false);
						InfoBoxList.Add (infobox);
						infobox.transform.position = Input.mousePosition;
						infobox.GetComponentInChildren<Text>().text = targetnpc.NPCDescription;
						Debug.Log(targetnpc.NPCDescription);

					} else if (hit.transform.tag == "Item") {
						ItemHandler targetitem = hit.transform.gameObject.GetComponent<ItemHandler> ();
						GameObject infobox = Instantiate (InfoPrefab);
						infobox.transform.SetParent (_OnScreenGUI.transform, false);
						InfoBoxList.Add (infobox);
						infobox.transform.position = Input.mousePosition;
						infobox.GetComponentInChildren<Text>().text = targetitem.ItemDescription;
						//targetitem.PickUpItem ();
						Debug.Log(targetitem.ItemDescription);
					} else if (hit.transform.tag == "Interactable") {
						
						Interactable targetinteraction = hit.transform.gameObject.GetComponent<Interactable> ();
						GameObject infobox = Instantiate (InfoPrefab);
						infobox.transform.SetParent (_OnScreenGUI.transform, false);
						InfoBoxList.Add (infobox);
						infobox.transform.position = Input.mousePosition;
						infobox.GetComponentInChildren<Text> ().text = targetinteraction.InteractionDescription;
						Debug.Log(targetinteraction.InteractionDescription);
					} //end of interactable method

				}//end of right click sucsessfull hit method
			}//end of right click method
		} else if (_GameState._GameState == "AimMode"){
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			RaycastHit hit;
			if (Input.GetMouseButtonDown (0)) {
				
				if (Physics.Raycast (ray, out hit, 100)) {

					if (hit.transform.tag == "NPC") {
						_GlobalItemHandler.itemTarget = hit.collider.gameObject;
						_GlobalItemHandler.UseItem ();
						//send the target game obeject to the globitem 

					} 

				}//end of aim mode click sucsessfull hit method

			}//end of get button down
		}//end of aim mode
	}//end of update

}//end of class 
