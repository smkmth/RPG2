using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour {

	public GameObject InteractableMaker;



	public void UseObject(){
		if (gameObject.GetComponent<AreaExit> () != null) {
			AreaExit areaexit = gameObject.GetComponent<AreaExit> ();
			areaexit.Transition ();
		}
		

	}
}
