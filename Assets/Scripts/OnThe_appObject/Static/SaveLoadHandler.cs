﻿using System;
using System.Collections;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;		//how we open files 

public static class SaveLoadHandler {

	public static void SavePlayer (Player player){
		
		BinaryFormatter bf = new BinaryFormatter(); //create a new binary formatter called bf
		FileStream stream = new FileStream (Application.persistentDataPath + "/player.giz", FileMode.Create); //peristantDataPath is a place in your application which is away from the project files
		PlayerData data = new PlayerData (player);
		bf.Serialize (stream, data);
		stream.Close ();

	}

	public static PlayerData LoadPlayer(){
		if (File.Exists (Application.persistentDataPath + "/player.giz")) {
			BinaryFormatter bf = new BinaryFormatter (); //create a new binary formatter called bf
			FileStream stream = new FileStream (Application.persistentDataPath + "/player.giz", FileMode.Open); //peristantDataPath is a place in your application which is away from the project files
			PlayerData data = bf.Deserialize (stream) as PlayerData;
			stream.Close ();
			return data;


		} else {
			Debug.LogError ("Im sorry my dude, no file to load");
			return new PlayerData (null);
		}
	}




}
[Serializable]
public class PlayerData {
	public string currentlevel;
	public string[] stringstats;
	public string[] stringmarkers;
	public int[] intstats;
	public string race;
	
	public float playerx;
	public float playery;
	public float playerz;
	public string currentleveldata;
	public string[] inventorystring;
	public string headitem;
	public string weaponitem;
	public string bodyitem;
	public string feetitem;
	public string[] pickedupitems;

	//public ItemList inventory;

	public PlayerData(Player player){
		stringstats = new string[2];
		stringstats [0] = player.Name;
		stringstats [1] = player.Gender;
		currentlevel = player.CurrentLevel ();
		currentleveldata = player.CurrentLevelData ();
		playerx = player.transform.position.x;
		playery = player.transform.position.y;
		playerz = player.transform.position.z;

		intstats = new int[7];
		intstats [0] = player.Health;
		intstats [1] = player.Combat;
		intstats [2] = player.Physical;
		intstats [3] = player.Engineering;
		intstats [4] = player.Science;
		intstats [5] = player.Subtle;
		intstats [6] = player.Charisma;
		stringmarkers = player.SpecialDialogueMarkers.ToArray();
		pickedupitems = player.PickedUpItems.ToArray ();
		//player.SpecialDialogueMarkers.CopyTo(stringmarkers);
		race = player.PlayerRace.RaceName;
		//inventory = player.Inventory;
		inventorystring = player.Inventory.SaveItemList();
		if (player.EquipedHeadItem != null) {
			headitem = player.EquipedHeadItem.itemName;
		}
		if (player.EquipedWeapon != null) {
			weaponitem = player.EquipedWeapon.itemName;
		}
		if (player.EquipedBody != null) {
			bodyitem = player.EquipedBody.itemName;
		}
		if (player.EquipedFeet != null) {
			feetitem = player.EquipedFeet.itemName;
		}
	}



}