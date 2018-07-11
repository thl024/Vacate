using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Inventory inventory;
	public InventoryObject itemHeld;

	// Use this for initialization
	void Start () {
		inventory = new Inventory();
		itemHeld = null;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Invoked when player picks up an item
	public void PickUpItem(InventoryObject invObj) {
		inventory.AddItem(invObj);
	}
}