using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueHandler : MonoBehaviour {

	public Text NPCText;
	public Button Responce1;
	public Button Responce2;
	public Button Responce3;
	public Button Responce4;
	public Button Responce5;
	public Button Responce6;
	public Button Responce7;
	public Button Responce8;
	public Button Responce9;
	public Button Responce10;

	public List<Responce> activeResponceList = new List<Responce>();
	public GameObject DialogueWindow;
	public GameObject DialogueResponceWindow;
	public GameState _GameState;
	public Player _Player;
	public List<Button> responceList = new List<Button>();


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

	public void ClearButtons(){
		foreach (Button button in responceList) {
			button.gameObject.SetActive (false);
		}
	}

	public void RunDialogueStart(GameObject npc){
		DialogueWindow.SetActive (true);
		DialogueResponceWindow.SetActive (true);
		_GameState._GameState = "DialogueMode";
		NPC npcd = npc.GetComponent<NPC> ();
		NPCText.text = " " + npcd.StartTopic.SpeakerName + " ";

		NPCText.text += npcd.StartTopic.Dialouge;
		var max = npcd.StartTopic.responces.Count;
		Debug.Log (npcd.StartTopic.responces.Count);
		var count = 0;
		foreach (Button button in responceList) {
			if (count == max) {
				break;
			}
			button.GetComponentInChildren<Text> ().text = npcd.StartTopic.responces [count].responce;
			activeResponceList.Add (npcd.StartTopic.responces [count]);

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
			} else {
				button.gameObject.SetActive (true);
				count += 1;
			}
		
						

			}



	}
		

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

				button.gameObject.SetActive (true);

				button.GetComponentInChildren<Text> ().text = dialogue.responces [count].responce;
				activeResponceList.Add (dialogue.responces [count]);
				count += 1;


			}
		} else {
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


