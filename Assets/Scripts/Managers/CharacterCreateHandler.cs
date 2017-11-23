using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CharacterCreateHandler : MonoBehaviour {

	public InputField NameField;
	public Dropdown GenderDropdown;
	public Player _Player;
	public GameState _GameState;
	public GameObject StatPanel;
	public Text ComText;
	public int comAmount = 5;
	public Text PhysText;
	public int physAmount = 5;
	public Text EngiText;
	public int engiAmount = 5;
	public Text SciText;
	public int sciAmount = 5;
	public Text SubtText;
	public int subtAmount = 5;
	public Text ChaText;
	public int chaAmount = 5;
	public Text RemainingScore;
	public int remainingScoreAmount = 10;
	public UnityEvent scoreHigher;
	public UnityEvent scoreLower;
	public Dropdown RaceDropdown;
	public Race workingRace;
	public List<Race> PlayableRaces = new List<Race> ();
	public List<int> Stats = new List<int>();
	public List<int> BadStats = new List<int>();

	public List<string> PlayableRacesNames = new List<string>();


	void Start () {
		ComText.text = comAmount.ToString ();
		PhysText.text = physAmount.ToString ();
		EngiText.text = engiAmount.ToString ();
		SciText.text = sciAmount.ToString ();
		SubtText.text = subtAmount.ToString ();
		ChaText.text = chaAmount.ToString ();
		RemainingScore.text = remainingScoreAmount.ToString ();
		Stats.Add (comAmount);
		Stats.Add (physAmount);
		Stats.Add (engiAmount);
		Stats.Add (sciAmount);
		Stats.Add (subtAmount);
		Stats.Add (chaAmount);





		if (scoreHigher == null) {
			scoreHigher = new UnityEvent();
		}
		if (scoreLower == null) {
			scoreLower= new UnityEvent();
		}

		scoreHigher.AddListener (LowerRemainingScore);
		scoreLower.AddListener (HigherRemainingScore);

		foreach (Race race in PlayableRaces) {
			PlayableRacesNames.Add (race.RaceName);
		}
		RaceDropdown.AddOptions (PlayableRacesNames);

	}

	public void RefreshStats(){

		if (workingRace != null) { 
			
			ComText.text = (workingRace.CombatBonus + comAmount).ToString ();
			PhysText.text = (workingRace.PhysicalBonus + physAmount).ToString ();
			EngiText.text = (workingRace.EngineeringBonus + engiAmount).ToString ();
			SciText.text = (workingRace.ScienceBonus + sciAmount).ToString ();
			SubtText.text = (workingRace.SubtleBonus + subtAmount).ToString ();
			ChaText.text = (workingRace.CharismaBonus + chaAmount).ToString ();
 
		} else {
			ComText.text = comAmount.ToString ();
			PhysText.text = physAmount.ToString ();
			EngiText.text = engiAmount.ToString ();
			SciText.text = sciAmount.ToString ();
			SubtText.text =  subtAmount.ToString ();
			ChaText.text = chaAmount.ToString ();
			
		
		}
	}

	public void GetName(){
		Debug.Log (NameField.text);
		_Player.Name = NameField.text;
	}

	public void GetGender(){
		Debug.Log (GenderDropdown.captionText.text);
		_Player.Gender = GenderDropdown.captionText.text;
	}
	
	
	public void GetRace(){
		_Player.PlayerRace = workingRace;
			
	}
	public void UpdateRace(){
		workingRace = PlayableRaces [RaceDropdown.value];
	
		RefreshStats ();
	
	}

	public void GetCombat(){
		_Player.Combat = comAmount;

	}
	public void IncreaseCombat(){
		if (remainingScoreAmount > 0) {
			comAmount += 1; 
			ComText.text = comAmount.ToString ();
			scoreHigher.Invoke ();
		} else {
			Debug.Log ("Max amount!");
		}

	}
	public void DecreaseCombat(){
		if (comAmount > 0) {
			comAmount -= 1; 
			ComText.text = comAmount.ToString ();
			scoreLower.Invoke ();
		} else {
			Debug.Log ("Min Amount!");
		}
	}

	public void GetPhysical(){
		_Player.Physical = Convert.ToInt32(PhysText.text);
	}
	public void IncreasePhysical(){
		if (remainingScoreAmount > 0) {
			physAmount += 1; 
			PhysText.text = physAmount.ToString ();
			scoreHigher.Invoke ();
		} else {
			Debug.Log ("Max Amount!");
		}
	}
	public void DecreasePhysical(){
		if (physAmount > 0) {
			physAmount -= 1; 
			PhysText.text = physAmount.ToString ();
			scoreLower.Invoke ();
		} else {
			Debug.Log ("Min Amount!");
		}
	}
	public void GetEngineering(){
		_Player.Engineering = Convert.ToInt32(EngiText.text);
	}
	public void IncreaseEngineering(){
		if (remainingScoreAmount > 0) {
			engiAmount += 1; 
			EngiText.text = engiAmount.ToString ();
			scoreHigher.Invoke ();
		} else {
			Debug.Log ("Max Amount!");
		}
	}
	public void DecreaseEngineering(){
		if (engiAmount > 0) {
			engiAmount -= 1; 
			EngiText.text = engiAmount.ToString ();
			scoreLower.Invoke ();
		} else {
			Debug.Log ("Min Amount!");
		}
	}
	public void GetScience(){
		
		_Player.Science = Convert.ToInt32(SciText.text);
	}
	public void IncreaseScience(){
		if (remainingScoreAmount > 0) {
			sciAmount += 1; 
			SciText.text = sciAmount.ToString ();
			scoreHigher.Invoke ();
		} else {
			Debug.Log ("Max Amount!");
		}
	}
	public void DecreaseScience(){
		if (sciAmount > 0) {
			sciAmount -= 1; 
			SciText.text = sciAmount.ToString ();
			scoreLower.Invoke ();
		} else {
			Debug.Log ("Min Amount!");
		}
	}
	

	public void GetSubtle(){
		_Player.Subtle = Convert.ToInt32(SubtText.text);
	}

	public void IncreaseSubtle(){
		if (remainingScoreAmount > 0) {
			subtAmount += 1; 
			SubtText.text = subtAmount.ToString ();
			scoreHigher.Invoke ();
		} else {
			Debug.Log ("Max Amount!");
		}
	}
	public void DecreaseSubtle(){
		if (subtAmount > 0) {
			subtAmount -= 1; 
			SubtText.text = subtAmount.ToString ();
			scoreLower.Invoke ();
		} else {
			Debug.Log ("Min Amount!");
		}
	}
	public void GetCharisma(){
		_Player.Charisma = Convert.ToInt32(ChaText.text);
	
	}
	public void IncreaseCharisma(){
		if (remainingScoreAmount > 0) {
			chaAmount += 1;

			ChaText.text = chaAmount.ToString ();
			scoreHigher.Invoke ();
		} else {
			Debug.Log ("Max Amount!");
		}
	}
	public void DecreaseCharisma(){
		if (chaAmount > 0) {
			chaAmount -= 1; 
			ChaText.text = chaAmount.ToString ();
			scoreLower.Invoke ();
		} else {
			Debug.Log ("Min Amount!");
		}
	}

	public void GetStats(){
		
		GetName ();
		GetGender ();
		GetRace ();
		comAmount += PlayableRaces [RaceDropdown.value].CombatBonus;
		physAmount += PlayableRaces [RaceDropdown.value].PhysicalBonus;
		engiAmount += PlayableRaces [RaceDropdown.value].EngineeringBonus;
		sciAmount += PlayableRaces [RaceDropdown.value].ScienceBonus;
		subtAmount += PlayableRaces [RaceDropdown.value].SubtleBonus;
		chaAmount += PlayableRaces [RaceDropdown.value].CharismaBonus;
		GetCombat ();
		GetPhysical();
		GetEngineering ();
		GetScience();
		GetSubtle ();
		GetCharisma ();

	}		
	// Unity Action 
	void LowerRemainingScore(){
		remainingScoreAmount -= 1;
		RemainingScore.text = remainingScoreAmount.ToString();
		RefreshStats ();
	}
	void HigherRemainingScore(){
		remainingScoreAmount += 1;
		RemainingScore.text =  remainingScoreAmount.ToString();
		RefreshStats ();

	}


	

}
