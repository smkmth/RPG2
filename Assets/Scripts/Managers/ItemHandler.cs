using System;
using UnityEngine;

public class ItemHandler : MonoBehaviour{

	public Item item;
	public Player _Player;

	void Start(){
		_Player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
	}

	public void PickUpItem(){
		_Player.AddInventoryItem (item);
		_Player.PickedUpItems.Add (gameObject.name);
		Destroy (gameObject);


	}






}
