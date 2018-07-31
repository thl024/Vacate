using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// May need to inherit from script or something to render items updates on UI
public class Inventory : MonoBehaviour {

	public List<InteractableObject> items = new List<InteractableObject>();

	public void AddItem(InteractableObject item) {
		items.Add(item);
	}

	public bool HasItem(InteractableObject item) {

		// Potential TODO: override == in InteractableObject
		foreach (InteractableObject invItem in items) {
			if (invItem.type == item.type) {
				return true;
			}
		}

		return false;
	}

	public bool HasItem(ObjectType type) {

		// Potential TODO: override == in InteractableObject
		foreach (InteractableObject invItem in items) {
			if (invItem.type == type) {
				return true;
			}
		}

		return false;
	}

	public bool RemoveItem(InteractableObject item) {
		var ind = -1;

		for (var i = 0; i < items.Count; i++) {
			if (items[i].type == item.type) {
				ind = i;
				break;
			}
		}

		if (ind != -1) {
			items.RemoveAt(ind);
			return true;
		}

		Debug.Log("ERROR: Item " + item.type + " not in inventory!");
		return false;
	}

	public bool RemoveItem(ObjectType type) {
		var ind = -1;

		for (var i = 0; i < items.Count; i++) {
			if (items[i].type == type) {
				ind = i;
				break;
			}
		}

		if (ind != -1) {
			items.RemoveAt(ind);
			return true;
		}

		Debug.Log("ERROR: Item " + type + " not in inventory!");
		return false;
	}

	public InteractableObject GetItem(ObjectType type) {

		foreach (InteractableObject invItem in items) {

			if (invItem.type == type) {
				return invItem;
			}
			
		}

		Debug.Log("ERROR: Item " + type + " not in inventory!");

		return null;

	}

	// Draw on GUI?
	void OnGUI() {
    	// GUI.Label( new Rect(...), text );
 	}
}
