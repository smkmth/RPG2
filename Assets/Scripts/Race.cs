using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Race", menuName = "CharacterCreation/Race", order = 1)]
public class Race : ScriptableObject {

	public string RaceName;
	public string RaceDescription;


	public List<SpecialAbility> RacialAbilities = new List<SpecialAbility>();

	public int StrBonus;
	public int DexBonus;
	public int ConBonus;
	public int IntBonus;
	public int WisBonus;
	public int ChaBonus;




}