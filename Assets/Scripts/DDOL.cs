using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


/// <summary>
/// the dont destroy on load script, should be on the _app object to 
/// ensure every child of that object remains persistant throughout 
/// the whole game 
/// </summary>
public class DDOL : MonoBehaviour {

	public void  Awake(){
		DontDestroyOnLoad (gameObject);
		SceneManager.LoadScene ("StartScene");

	}
}
