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

	public Text NPCText;//this is like the console the dialogue is printed to 
	public GameObject ButtonPrefab;
	public List<GameObject> tempbuttonlist = new List<GameObject> ();
	public GameObject _ResponcePanel;


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

	

		ClearButtons ();



	}
	/// <summary>
	/// makes sure all the buttons are turned off by defult, so we can turn them on as
	/// we need them. 
	/// </summary>
	public void ClearButtons(){
		foreach (GameObject button in tempbuttonlist) {
			Destroy (button);
		}
	}

		

	public void Option(int number){
		NPCText.text += "\n";
		NPCText.text += " " + _Player.Name + " ";
		NPCText.text += activeResponceList [number].responce;

		if (activeResponceList [number].NextDialogue != null) {
			PlayNextResponce (activeResponceList [number].NextDialogue);
		} else {
			QuitDialogue ();
		}



		//_GameState._CharacterSelectI did as cdie you put the lime in the coconut and throw the can away}}


	}

	public void PlayNextResponce(Topic dialogue){
		
		_GameState._GameState = "DialogueMode";
		
		if (dialogue.Description != null) {
			//NPCText.fontStyle = FontStyle.Italic;
			NPCText.text = "<i>" + dialogue.Description + "</i> \n";
			//NPCText.fontStyle = FontStyle.Normal;

		}
		NPCText.text += " " + dialogue.SpeakerName + ": ";			//get speaking npcs name, leave a space before and after
		NPCText.text += dialogue.Dialouge;	
			
		Debug.Log (dialogue.Dialouge);
		if (dialogue.ContainsSpecialMarker) { 		// if the responce has a special marker attached
			_Player.SpecialDialogueMarkers.Add (dialogue.SpecialMarker);																	// we add that to the players special marker list
		}

	
		activeResponceList.Clear ();
		ClearButtons ();
		if (dialogue.responces.Count > 0) {
//			var count = 0;
//			var max = dialogue.responces.Count;

			for (var i = 0; i < dialogue.responces.Count; i++) {
				activeResponceList.Add (dialogue.responces[i]);										//add the npc responces to the active responce list			

				GameObject button = Instantiate (ButtonPrefab);
				tempbuttonlist.Add (button);
				button.transform.SetParent (_ResponcePanel.transform, false);
				button.GetComponentInChildren<Text> ().text =  dialogue.responces[i].responce;

				if (dialogue.responces [i].SRace == true) {
					//first check the race cos this is the most important cull
					if (_Player.PlayerRace.RaceName == dialogue.responces [i].CheckRace) {
						button.gameObject.SetActive (true);
						int number = i;
						button.GetComponent<Button> ().onClick.AddListener (delegate {
							Option (number);
						});

					} else if (_Player.PlayerRace.RaceName == "-" +  dialogue.responces [i].CheckRace) {
						button.gameObject.SetActive (false);
						Debug.Log ("This race" +  dialogue.responces + "is  specifically excluded from the responce ");
					} else {
						button.gameObject.SetActive (false);
						Debug.Log ("you cannot see this racial requirement option " +  dialogue.responces[i] + " without " +  dialogue.responces[i].CheckRace);


					}
				}
				//then check skill requirements
				else if (activeResponceList [i].Requirement == true) {
					if (_Player.SkillRequireCheck (activeResponceList [i].RequirementType, activeResponceList [i].RequirementChallange)) {
						Debug.Log (_Player.SkillRequireCheck (activeResponceList [i].RequirementType, activeResponceList [i].RequirementChallange));
						button.gameObject.SetActive (true);
						int number = i;
						button.GetComponent<Button> ().onClick.AddListener (delegate {
							Option (number);
						});
					} else {
						button.gameObject.SetActive (false);
						Debug.Log ("You cannot use the responce " + activeResponceList [i].responce + "without " + activeResponceList [i].RequirementType + activeResponceList [i].RequirementChallange);
					}
					//lastly check special requirements
				} else if (activeResponceList [i].SRequirement == true) {
					if (_Player.SpecialDialogueMarkers.Contains (activeResponceList [i].SpecialRequirement)) {
						button.gameObject.SetActive (true);
						int number = i;
						button.GetComponent<Button> ().onClick.AddListener (delegate {
							Option (number);
						});
					} else {
						Debug.Log ("you cannot see this special requirement option " + activeResponceList [i].responce + " without " + activeResponceList [i].SpecialRequirement);
						button.gameObject.SetActive (false);
					}


				} 
				//if it hasnt be culled, display now.
				else {
					button.gameObject.SetActive (true);
					int number = i;
					button.GetComponent<Button> ().onClick.AddListener (delegate {
						Option (number);
					});
				}

			}

		
		}

		else {
			GameObject button = Instantiate (ButtonPrefab);
			tempbuttonlist.Add (button);
			button.transform.SetParent (_ResponcePanel.transform, false);
			button.GetComponentInChildren<Text> ().text = "Exit Dialogue";
			button.GetComponent<Button> ().onClick.AddListener (QuitDialogue);

			
			
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


