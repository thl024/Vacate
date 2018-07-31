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
		inventory = GameObject.Find("UI").GetComponent<Inventory>();
		isHoldingItem = false;
	}

	// Equips an item
	public bool EquipInventoryItem(InteractableObject objectToEquip) {

		InteractableObject obj = inventory.GetItem(objectToEquip.type);

		// Object does not exist in the inventory
		if (obj == null) {

			Debug.Log("Error: " + objectToEquip.type + " could not be retrieved.");
			return false;

		}

		// Object exists, equip item
		this.isHoldingItem = true;
		this.itemHeld = obj;
        //UIUPDATE CODE 

		return true;
	}

	// Equips an item -- overloaded to support removing an item with matching object type
	public bool EquipInventoryItem(ObjectType typeToEquip) {

		InteractableObject obj = inventory.GetItem(typeToEquip);

		// Object does not exist in the inventory
		if (ReferenceEquals( obj, null )) {

			Debug.Log("Error: " + typeToEquip + " could not be retrieved.");
			return false;

		}

		// Object exists, equip item
		this.isHoldingItem = true;
		this.itemHeld = obj;

		return true;
	}

	// Unequips all items
	public void UnequipInventoryItem() {

		this.isHoldingItem = false;
		this.itemHeld = null;

	}

	// Invoked when player picks up an item
	public bool PickUpItem(InteractableObject obj) {

		// Can pick up object
		if (obj.canPickUp) {
			inventory.AddItem(obj);
			Debug.Log("Player successfully picked up: " + obj.type);
			return true;
		}

		Debug.Log("Attemped to pick up object that cannot be picked up: " + obj.type);
		return false;
		
	}

	// Checks whether player has an item
	public bool HasItem(InteractableObject obj) {
		return inventory.HasItem(obj);
	}

	// Removes an item from the player's inventory
	public bool RemoveItem(InteractableObject obj) {
		bool result = inventory.RemoveItem(obj);

		if (result) {
			Debug.Log("Player successfully removed " + obj.type + " from inventory.");
			return true;
		}

		Debug.Log("Player failed to remove " + obj.type + " from inventory.");
		return false;
	}
}