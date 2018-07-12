using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    // Keep track of the player 
    public Player player;

    public EventManager() {
        // Keeps track of the player
        player = new Player();
    }

    // Determines the event upon gameobject selection
    public void PerformEvent(GameObject gameObject) {
        Debug.Log("Event Manager Logic");

        // Check if object is interactable
        InteractableObject obj = gameObject.GetComponent(typeof(InteractableObject)) as InteractableObject;

        if (obj != null) { // Object is interactable

            if (obj.canPickUp) { // Object is pickupable

                if (!player.HasItem(obj)) { // Player does not have the item

                    // Pick up the item and add to inventory
                    player.PickUpItem(obj);

                    // Make gameobject disappear from scene
                    UnityEngine.Object.Destroy(gameObject);

                } else { // Player already has the item

                    Debug.Log("Player already has an item of this type. Something went wrong!");

                }

            } else { // Cannot pick up object

                // TODO - LOGIC BLOCK

                if (player.itemHeld != null) { // Player is holding an item

                    // TODO - LOGIC BLOCK

                } else { // Player is not holding an item



                }

            }

        } else {
            Debug.Log("Non-interactable game object clicked.");
        }
    }
}