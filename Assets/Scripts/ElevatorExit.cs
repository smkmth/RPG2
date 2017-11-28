using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElevatorExit : MonoBehaviour {


	private LevelHandler _LevelHandler;
	private GameState _GameState;
	public GameObject _ShipElevatorGUI;
	public GameObject _ButtonPrefab;
	public string ElevatorDescription;

	public List<Text> buttontextlist = new List<Text> ();

	public List<string> levels = new List<string>();
	public List<string> leveldatas = new List<string>();

	void Start(){
		_LevelHandler = GameObject.FindGameObjectWithTag ("Manager").GetComponent<LevelHandler> ();
		_GameState = GameObject.FindGameObjectWithTag ("Manager").GetComponent<GameState> ();


	}


	public void UseElevator(){
		_GameState._GameState = "ElevatorMode";

		_ShipElevatorGUI = GameObject.FindGameObjectWithTag ("ElevatorGui");
		Debug.Log ("found" + _ShipElevatorGUI.name);
		for (var i = 0; i < levels.Count; i++) {

			GameObject button = Instantiate (_ButtonPrefab);
			button.transform.SetParent (_ShipElevatorGUI.transform, false);
			button.GetComponentInChildren<Text> ().text = levels [i];
			int number = i;
			button.GetComponent<Button> ().onClick.AddListener (delegate {
				Option (number);
			});
		}


	}

	public void Option(int number){
		Debug.Log ("level number " + number);
		_LevelHandler.LoadLevel (levels [number], leveldatas [number]);
		_ShipElevatorGUI.SetActive (false);
		_GameState._GameState = "PlayMode";
		//_GameState._CharacterSelectI did as cdie you put the lime in the coconut and throw the can away}}
	

	}
}
