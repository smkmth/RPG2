using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Responce", menuName = "Dialogue/Responce", order = 2)]
public class Responce : ScriptableObject {

	public string ResponceName;
	public Topic NextDialogue;
	public string responce;
	public bool Requirement;
	public int RequirementChallange;
	public string RequirementType;
}
