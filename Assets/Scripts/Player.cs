using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Camera movement stuff should be in here
public class Player {

	// Player has inventory of items
	public Inventory inventory;

	// Player holding any item?
	public bool isHoldingItem;
	public InteractableObject itemHeld;

	// Use this for initialization
	public Player() {
		GameObject invGO = GameObject.Find("InventoryUI");
		inventory = invGO.GetComponent<Inventory>();
		isHoldingItem = false;
	}

	// Invoked when player picks up an item
	public void PickUpItem(InteractableObject obj) {
		inventory.AddItem(obj);
	}

	public bool HasItem(InteractableObject obj) {
		return inventory.HasItem(obj);
	}

	public bool RemoveItem(InteractableObject obj) {
		return inventory.RemoveItem(obj);
	}
}