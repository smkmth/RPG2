using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// incredably convoluted class hopefully we will never again have to touch this one
/// should just take the responces from the dialogue scriptable objects and just 
/// run them 
/// </summary>
public class DialogueHandler : MonoBehaviour {

	public Text NPCText;				//this is like the console the dialogue is printed to 
	public Button Responce1;			//so we have a whole bunch of buttons
	public Button Responce2;			//these buttons are the responces
	public Button Responce3;
	public Button Responce4;
	public Button Responce5;
	public Button Responce6;
	public Button Responce7;
	public Button Responce8;
	public Button Responce9;
	public Button Responce10;

	public List<Responce> activeResponceList = new List<Responce>(); 	// an active responce list so we can access responces from allover the script
	public GameObject DialogueWindow;									// a ref to the window itself incase we need to turn it off
	public GameObject DialogueResponceWindow;							//a ref to the window with the responce buttons
	public GameState _GameState;										// a ref to the gamestate
	public Player _Player;												// a player ref
	public List<Button> responceList = new List<Button>();				//a list of buttons which can be itterated through.

	/// <summary>
	/// in the start method we double check the dialogue window is false, find our player 
	/// with the "Player" tag, then add all the responce buttons to the responce list, 
	/// before running the clear buttons script.
	/// </summary>
	void Start(){
		_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
		DialogueWindow.SetActive (false);
		DialogueResponceWindow.SetActive (false);
		responceList.Add (Responce1);
		responceList.Add (Responce2);
		responceList.Add (Responce3);
		responceList.Add (Responce4);
		responceList.Add (Responce5);
		responceList.Add (Responce6);
		responceList.Add (Responce7);
		responceList.Add (Responce8);
		responceList.Add (Responce9);
		responceList.Add (Responce10);
;
		ClearButtons ();



	}
	/// <summary>
	/// makes sure all the buttons are turned off by defult, so we can turn them on as
	/// we need them. 
	/// </summary>
	public void ClearButtons(){
		foreach (Button button in responceList) {
			button.gameObject.SetActive (false);
		}
	}

	/// <summary>
	/// this method takes a gameobject representing the npc. it then turns on the 
	/// dialogue windows, and turns the gamestate to dialogue mode. 
	/// 
	/// </summary>
	/// <param name="npc">Npc.</param>
	public void RunDialogueStart(GameObject npc){
		//turning on windows that need to be on - switch game state - get component
		DialogueWindow.SetActive (true);
		DialogueResponceWindow.SetActive (true);
		_GameState._GameState = "DialogueMode";
		NPC npcd = npc.GetComponent<NPC> ();

		//print text
		NPCText.text = " " + npcd.StartTopic.SpeakerName + " ";			//get speaking npcs name, leave a space before and after
		NPCText.text += npcd.StartTopic.Dialouge;						//print the dialogue for the npc

		//add special marker for first interaction
		if (npcd.StartTopic.SpecialMarker != null && !_Player.SpecialDialogueMarkers.Contains(npcd.StartTopic.SpecialMarker)) { 		// if the responce has a special marker attached
			_Player.SpecialDialogueMarkers.Add (npcd.StartTopic.SpecialMarker);																	// we add that to the players special marker list
		}

		//work out how many responces we need
		var max = npcd.StartTopic.responces.Count;
		Debug.Log ("Should be a potential max " + npcd.StartTopic.responces.Count + " Responces in the list - before skill culling and special culling ");
		var count = 0;													//init the second itterator.
		if (npcd.StartTopic.responces.Count > 0) {
			//Actual convo loop.
			foreach (Button button in responceList) {
				if (count == max) {											// break out of loop when the count reaches max
					break;
				}
				button.GetComponentInChildren<Text> ().text = npcd.StartTopic.responces [count].responce;		//set the text components of the button to be the responce
				activeResponceList.Add (npcd.StartTopic.responces [count]);										//add the npc responces to the active responce list			

				if (activeResponceList [count].Requirement == true) {					//is the requirement bool set?
					if (_Player.SkillRequireCheck (activeResponceList [count].RequirementType, activeResponceList [count].RequirementChallange)) {		//if so run the skill check method in the player using the requirement type as the requiremnt type
						Debug.Log (_Player.SkillRequireCheck (activeResponceList [count].RequirementType, activeResponceList [count].RequirementChallange));	//and challange as number to bead
						button.gameObject.SetActive (true);		//turn on the button if player passes skill check
						count += 1;			//increase count by one. 
					} else {
						button.gameObject.SetActive (false);
						Debug.Log ("You cannot use the responce " + activeResponceList [count].responce + " without " + activeResponceList [count].RequirementType + activeResponceList [count].RequirementChallange);
						count += 1;
					}
				}
				if (activeResponceList [count].SRequirement == true) {
					if (_Player.SpecialDialogueMarkers.Contains (activeResponceList [count].SpecialRequirement)) {
						button.gameObject.SetActive (true);
						count += 1;
					} else {
						Debug.Log ("you cannot see this special requirement option " + activeResponceList [count].responce + " without " + activeResponceList [count].SpecialRequirement);
						button.gameObject.SetActive (false);
					}
					
				} else {
					button.gameObject.SetActive (true);
					count += 1;
				}
			
							

			}
		}else {
				Responce10.gameObject.SetActive (true);
				Responce10.GetComponentInChildren<Text> ().text = "Cancel";
			}

			



	}
		
//	if (activeResponceList [count].SpecialMarker != null && !_Player.SpecialDialogueMarkers.Contains(activeResponceList [count].SpecialMarker)) { 		// if the responce has a special marker attached
//		_Player.SpecialDialogueMarkers.Add (activeResponceList [count].SpecialMarker);																	// we add that to the players special marker list
//	}
	public void Option0(){
		
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [0].responce;
		if (activeResponceList [0].SpecialMarker != null) {
			_Player.SpecialDialogueMarkers.Add (activeResponceList [0].SpecialMarker);
		}
		if (activeResponceList [0].NextDialogue != null) {
			PlayNextResponce (activeResponceList [0].NextDialogue);
		} else {
			QuitDialogue ();
		}
		
	}
	public void Option1(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [1].responce;

		if (activeResponceList [1].NextDialogue != null) {
			PlayNextResponce (activeResponceList [1].NextDialogue);
		} else {
			QuitDialogue ();
		}
	}
	public void Option2(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [2].responce;

		if (activeResponceList [2].NextDialogue != null) {
			PlayNextResponce (activeResponceList [2].NextDialogue);
		} else {
			QuitDialogue ();
		}

	}
	public void Option3(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [3].responce;

		if (activeResponceList [3].NextDialogue != null) {
			PlayNextResponce (activeResponceList [3].NextDialogue);
		} else {
			QuitDialogue ();
		}

	}
	public void Option4(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [4].responce;

		if (activeResponceList [4].NextDialogue != null) {
			PlayNextResponce (activeResponceList [4].NextDialogue);
		} else {
			QuitDialogue ();
		}
	}
	public void Option5(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [5].responce;

		if (activeResponceList [5].NextDialogue != null) {
			PlayNextResponce (activeResponceList [5].NextDialogue);
		} else {
			QuitDialogue ();
		}
	}
	public void Option6(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [6].responce;

		if (activeResponceList [1].NextDialogue != null) {
			PlayNextResponce (activeResponceList [1].NextDialogue);
		} else {
			QuitDialogue ();
		}

	}
	public void Option7(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [7].responce;

		if (activeResponceList [1].NextDialogue != null) {
			PlayNextResponce (activeResponceList [1].NextDialogue);
		} else {
			QuitDialogue ();
		}

	}
	public void Option8(){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [8].responce;

		if (activeResponceList [1].NextDialogue != null) {
			PlayNextResponce (activeResponceList [1].NextDialogue);
		} else {
			QuitDialogue ();
		}

	}
	public void Option9(){
		QuitDialogue ();
	}

	public void PlayNextResponce(Topic dialogue){
		NPCText.text += "\n";
		NPCText.text += " " + dialogue.SpeakerName + " ";
			
		Debug.Log (dialogue.Dialouge);
		NPCText.text += dialogue.Dialouge;
		activeResponceList.Clear ();
		ClearButtons ();
		if (dialogue.responces.Count > 0) {
			var count = 0;
			var max = dialogue.responces.Count;
			foreach (Button button in responceList) {
				
				if (count == max) {
					break;
				}

				//button.gameObject.SetActive (true);

				button.GetComponentInChildren<Text> ().text = dialogue.responces [count].responce;
				activeResponceList.Add (dialogue.responces [count]);

				if (activeResponceList [count].Requirement == true) {
					if (_Player.SkillRequireCheck (activeResponceList [count].RequirementType, activeResponceList [count].RequirementChallange)) {
						Debug.Log (_Player.SkillRequireCheck (activeResponceList [count].RequirementType, activeResponceList [count].RequirementChallange));
						button.gameObject.SetActive (true);
						count += 1;
					} else {
						button.gameObject.SetActive (false);
						Debug.Log ("You cannot use the responce " + activeResponceList [count].responce + "without " + activeResponceList [count].RequirementType + activeResponceList [count].RequirementChallange);
						count += 1;
					}
				} else if (activeResponceList[count].SpecialRequirement != null){
					if (_Player.SpecialDialogueMarkers.Contains (activeResponceList [count].SpecialRequirement)) {
						button.gameObject.SetActive (true);
						count += 1;
					}

				}else {
					button.gameObject.SetActive (true);
					count += 1;
				}



			}
//		
		}

		else {
			Responce10.gameObject.SetActive (true);
			Responce10.GetComponentInChildren<Text> ().text = "Cancel";
		}
			
			

		}
	public void QuitDialogue(){
		ClearButtons ();
		activeResponceList.Clear ();
		DialogueWindow.SetActive(false);
		DialogueResponceWindow.SetActive(false);
		_GameState._GameState = "PlayMode";

	}
}


