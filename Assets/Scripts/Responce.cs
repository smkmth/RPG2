using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Responce", menuName = "Dialogue/Responce", order = 2)]
public class Responce : ScriptableObject {

	public string ResponceName;

	[TextArea(3,10)]
	public string responce;

	public bool Requirement;
	public int RequirementChallange;
	public string RequirementType;

	public bool SRequirement;
	public string SpecialRequirement;

	public string SpecialMarker;

	public bool SRace;
	public string CheckRace;

	public Topic NextDialogue;



}
