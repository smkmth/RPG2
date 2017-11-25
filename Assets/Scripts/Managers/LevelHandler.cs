using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class LevelHandler : MonoBehaviour{

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
		
		LoadLevel ("Ship", "Ship");
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
				if (!_Player.PickedUpItems.Contains (_buildingScene.items [i].name)) {
					GameObject gameobject = (GameObject)Instantiate (_buildingScene.items [i], _buildingScene.itemLocation [i], Quaternion.identity);
				}
			}
		}
	}





}