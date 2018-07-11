using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase  {

	// Singleton... yet again
	public static ItemDatabase instance = null;

	// Keep a map from a unique ID to the interactable object
	Dictionary<int, InteractableObject> itemMap;

	public ItemDatabase() {
		// Singleton instantiation
		itemMap = new Dictionary<int, InteractableObject>();
	}

	public void setItem(int id, InteractableObject obj) {
		itemMap[id] = obj;
	}

	public InteractableObject fetchItem(int id) {
		return itemMap[id];
	}

}
