using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class LevelHandler : MonoBehaviour{
	public LevelData Ship;
	//public GameState _GameState;
	public Player _Player;
	public GameObject prefab;
	public GameObject _app;
	private LevelData _buildingScene;
	UnityEvent NewScene;

	void Awake(){
		SceneManager.activeSceneChanged += BuildScene;
	}
	
	public void StartNewGame(){
		
		SceneManager.LoadScene ("Ship");
		_buildingScene = Ship;
		//_GameState.ChangeState ("PauseMode");
	}
	public void QuitGame(){
		SceneManager.LoadScene ("preload");
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
		}
	}





}