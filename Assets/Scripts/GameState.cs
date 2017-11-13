using System;
using UnityEngine;

public class GameState : MonoBehaviour{

	public int gameState;
	public GameObject _CharacterSelect;
	public GameObject _Inventory;
	

	void Start(){
		gameState = 0;
		SetState ();

	}

	public void SetState(){

		if (gameState == 0) {
			_CharacterSelect.SetActive (true);
			_Inventory.SetActive (false);

		} else if (gameState > 0) {
			_CharacterSelect.SetActive (false);
		}
	}

	public void FinishCharacterSelect(){
		gameState += 1;
		SetState ();
		Debug.Log (gameState);
	}

}	