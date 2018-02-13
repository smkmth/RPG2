using System;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;


public class AreaExit : MonoBehaviour {

	public string exit;
	public string exitData;
	private LevelHandler _LevelHandler;

	void Start(){
		_LevelHandler = GameObject.FindGameObjectWithTag ("Manager").GetComponent<LevelHandler> ();
	}

	public void Transition(){
		_LevelHandler.LoadLevel (exit, exitData);
	}

}