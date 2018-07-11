using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {

    // Keep track of the player 
    public Player player;

    public EventManager() {
        // Keeps track of the player


        // Instantiate ItemDB
        ItemDatabase.instance = new ItemDatabase();
    }

    // Determines the event upon gameobject selection
    public void PerformEvent(GameObject gameObject) {
        Debug.Log("Event Manager Logic");
        // TODO -- lots of logic goes here

        // if (player.itemHeld == null) {

        //     InventoryObject invObj = gameObject.GetComponent(typeof(InventoryObject)) as InventoryObject;

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