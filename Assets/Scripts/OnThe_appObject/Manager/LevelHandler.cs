using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class LevelHandler : MonoBehaviour{
	/// <summary>
	/// The Level Handler builds the levels dynamically from a scriptable object called 'level data'.
	/// The way it works is that i have a list of leveldata files, for all the levels in the game - and 
	/// also for all the variations on initial setup. This script takes those leveldata files and uses 
	/// them as instructions to build a scene dynamically. 
	/// 
	/// This is a usefull thing to do because :
	/// - i can have different setups for different times of day- different officers on the bridge, different backdrops, whatever
	/// - as the level is building, i can step in and tell the levelhandler dynamic things the player has done, for instance if
	/// they have killed a bridge officer, he wont show up in the scene, if i have picked up an item, it wont show up again when the
	/// level is built ect.
	/// - I can quickly change all the elements of a scene at a glance, and change any instance of a scene instantly 
	/// A disadvantage of this, and important note,
	/// -If you make a new level, you must add the level data to the 'levels' list. 
	/// - If you want to load a new level, you must ref this script, and use the method LoadLevel().
	/// 
	/// Awake() - The scene manager listens for anytime the scene changes, and if the scene does change,
	/// it runs a method called buildscene, which takes the next scene to be loaded and the current scene 
	/// as arguments. 
	/// We get the game state object.
	/// 
	/// StartNewGame() - Called by the main menu, this meth runs the loadlevel() method giving it the instructions
	/// for the first scene in the game,
	/// 
	/// QuitGame() - Also called by the main menu, this meth returns you to the preload scene essentially quiting 
	/// to the main menu. 
	/// 
	/// LoadLevel(string LevelName, string LevelData) - This is the meth to call to load a new scene. Almost everything else
	/// here isnt really worth worrying about. 
	/// 
	/// It takes the string LevelData, and looks through the list of leveldata scriptable objects. The leveldata scriptable 
	/// objects each have a value called levelname, and when it finds one that matches, it sets that specific leveldata as 
	/// the '_buildingScene'. 
	/// 
	/// It then runs the LoadScene method on the LevelName string.
	/// 
	/// When the scene is changed, the event activeSceneChanged lights up, calling the BuildScene method.
	/// 
	///BuildScene() buildscene knows what leveldata to use to build the scene because its stored in the _buildingScene var.
	/// 
	/// It then runs through the scriptable object, placing things where they should go. 
	/// 
	/// One thing of note is the 
	/// if (!_Player.PickedUpItems.Contains (_buildingScene.items [i].name + "(Clone)")) {
	/// This is checking the player for a list called pickedupitems, which is a string list containing specific reference to 
	/// each item the player has picked up in the game. If that item is in that list, it dosnt spawn it into the scene. 
	/// 
	/// 
	/// </summary>

	public List<LevelData> levels = new List<LevelData> ();
	public GameState _GameState;
	public Player _Player;
	public LevelData _buildingScene;
	UnityEvent NewScene;

	void Awake(){
		SceneManager.activeSceneChanged += BuildScene;
		_GameState = gameObject.GetComponent<GameState> ();
	}
	
	public void StartNewGame(){
		
		LoadLevel ("Bridge", "Start");
	}
	public void QuitGame(){
		SceneManager.LoadScene ("preload");
		_GameState._GameState = "MainMenu";

	}
	public void LoadLevel (string LevelName, string LevelData)
	{
		
		foreach (LevelData level  in levels) {
			if (level.LevelName == LevelData) {
				_buildingScene = level;
				break;
			} else {
				Debug.Log ("Error, leveldata not found, you probably didnt add the level data foir this level to the level data list - bad times");
			}
		}
		SceneManager.LoadScene (LevelName);
		_Player.gameObject.transform.position = _buildingScene.playerEntrance;

	}





	///my original plan to just move the objects to the right place on loading. i dont remember why this didnt work...?
//		foreach (GameObject npc in leveldata.Npcs) {
//			Debug.Log ("npc " + npc.name + npc.transform.position);
//
//			GameObject gameobject = (GameObject)Instantiate (npc, leveldata.NpcLocations [count], Quaternion.identity);
//			Debug.Log (gameobject.name + gameobject.transform.position);
//			count += 1;
//		}


	void BuildScene(Scene previousScene, Scene newScene ){
		if (_buildingScene != null){
			for (var i = 0; i < _buildingScene.Npcs.Count; i++){
				GameObject gameobject = (GameObject)Instantiate (_buildingScene.Npcs[i], _buildingScene.NpcLocations [i], Quaternion.identity);
				Debug.Log (gameobject.name + gameobject.transform.position);

			}
			for (var i = 0; i < _buildingScene.items.Count; i++) {
				if (!_Player.PickedUpItems.Contains (_buildingScene.items [i].name + "(Clone)")) {
					Debug.Log ("items in the scene");
					GameObject gameobject = (GameObject)Instantiate (_buildingScene.items [i], _buildingScene.itemLocation [i], Quaternion.identity);
				} else {
					Debug.Log ("items not in the scene" + _buildingScene.items [i] + _buildingScene.itemLocation [i]);
				}
			}
		}
	}





}