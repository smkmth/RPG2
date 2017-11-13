using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour {

	public GameObject InteractionCube;
	public Topic StartTopic;
	public DialogueHandler _Dialogue;

	// Use this for initialization
	void Start () {

		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void TalkToThisNPC(){
		_Dialogue = GameObject.FindGameObjectWithTag ("Dialogue").GetComponent<DialogueHandler> ();

		Debug.Log("The npc is talking");
		_Dialogue.RunDialogueStart (gameObject);
	}
}
