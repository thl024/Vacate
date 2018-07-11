using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory {

	public List<InteractableObject> items = new List<InteractableObject>();

	public void AddItem(InteractableObject item) {
		if (item.canPickUp) {
			items.Add(item);
		} else {
			// Throw exception
		}
	}

	public bool HasItem(InteractableObject item) {
		return items.Contains(item);
	}

	public bool RemoveItem(InteractableObject item) {
		return items.Remove(item);
	}
}
