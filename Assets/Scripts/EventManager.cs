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

        if (obj != null) {

            if (player.itemHeld == null) {

                if (!player.HasItem(obj)) {

                    player.PickUpItem(obj);

                    // Make gameobject disappear from scene
                    UnityEngine.Object.Destroy(gameObject);

                }

            }

        } else {
            Debug.Log("Non-interactable game object clicked.");
        }

        // TODO -- lots of logic goes here

        // if (player.itemHeld == null) {

        //     

        //     if (invObj != null) { // Object is an inventory object

        //         // Add object to inventory
        //         player.PickUpItem(invObj);
        //         Debug.Log("Player picked up object");
                
        //     } else { // Object is an environment object
                
        //         EnvironmentObject envObj = gameObject.GetComponent(typeof(EnvironmentObject)) as EnvironmentObject;

        //     }

        // } else {



        // }

        // User holding item or not?
        // Interacted object pickupable or not?
        // etc.
    }
}