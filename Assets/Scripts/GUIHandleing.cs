using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GUIHandleing : MonoBehaviour {
	public GameObject Inventory;
	public Player _Player;
	public GameState _GameState;
	public GameObject InfoPanel;
	private UnityAction VariableChanged;
	public Text Name;
	public Text Stats;
	public bool InventoryOn;
	

	void Awake(){
		VariableChanged = new UnityAction (RefreshText); 
	}

	void OnEnable (){
		EventManager.StartListening ("VariableChanged", VariableChanged);



	}
	void OnDisable(){
		EventManager.StopListening ("VariableChanged", VariableChanged);
	
	}

	// Use this for initialization
	void Start () {
		InventoryOn = false;


	}
	
	// Update is called once per frame
	void Update () {
		if (_GameState.gameState == 1) {
			if (Input.GetKeyDown (KeyCode.I) && InventoryOn == false) {
				Inventory.SetActive (true);
				InventoryOn = true;
				_GameState.gameState = 2;
				
			
			}

		} else if (_GameState.gameState == 2) {

			if (Input.GetKeyDown (KeyCode.I) && InventoryOn == true) {
				Inventory.SetActive (false);
				InventoryOn = false;
				_GameState.gameState = 1;
			}
		}
	}

	public void RefreshText() {
		Name.text = _Player.Name;
		Stats.text = "Strength = " + _Player.Strength + "\n" + "Dexterity = " + _Player.Dexterity + "\n" + "Constitution = " +
		_Player.Constitution + "\n" + "Intellegence = " + _Player.Intellegence + "\n" + "Wisdom = " + _Player.Wisdom + "\n" + "Charisma = " + _Player.Charisma;


	}
}
