using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Abstracts /Level Data", order = 1)]
public class LevelData : ScriptableObject{

	public string LevelName;

	public List<GameObject> Npcs = new List<GameObject>();
	public List<Vector3> NpcLocations = new List<Vector3> ();

	public List<Item> items = new List<Item> ();
	public List<Vector3> itemLocation = new List<Vector3>();

	public Vector3 PlayerPosition;


}