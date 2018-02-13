using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Topic", menuName = "Dialogue/Topic", order = 2)]
public class Topic : ScriptableObject {
	public string SpeakerName;

	public string DialogueName;

	[TextArea(3,10)]
	public string Description;


	[TextArea(3,10)]
	public string Dialouge;


	public List<Responce> responces = new List<Responce> ();
	//public List<Responce> specialresponces = new List<Responce> ();

	public bool ContainsSpecialMarker;
	public string SpecialMarker;

	

}
