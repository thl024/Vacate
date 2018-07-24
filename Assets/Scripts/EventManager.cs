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

                // Object types are enumerated in InteractableScript.cs
                switch (obj.type) {

                    case ObjectType.Bed:
                        Debug.Log("Bed Clicked");
                        break;

                    // EXAMPLE!!!
                    case ObjectType.Vent:

                        Debug.Log("Vent Clicked");

                        // TODO -- CHECK SOMEHOW IF THE VENT IS OPEN... MAYBE NEED TO MAKE A NEW SCRIPT OR MODIFY
                        // EXISTING SCRIPT FOR INTERACTBLE ITEM TO CONTAIN SOME SORT OF GENERIC INDICATOR ACROSS ALL
                        // OTHER OBJECT TYPES

                        if (true) { // TODO replace with vent open check

                            if (player.itemHeld != null) { // Player is holding an item

                                if (player.itemHeld.type == ObjectType.Screwdriver) {

                                    // TODO
                                    // Change vent sprite and vent open/close state by modifying current gameObject & script values

                                    // Remove screwdriver from player inventory
                                    player.RemoveItem(player.itemHeld);

                                } else {

                                    // Popup telling user that he or she is a dumbass using the wrong item

                                }

                            } else { // Player is not holding an item

                                // Have popup telling user that it needs something to open or something

                            }

                        } else {

                            // If item is in the vent... it should be able to handle itself being clicked
                            // If no item in the vent, nothing should happen... so in total:

                            // DO NOTHING or prompt user saying the vent is empty 

                        }

                        break;

                    case ObjectType.DeskDrawer:
                        Debug.Log("DeskDrawer Clicked");
                        break;

                    case ObjectType.Computer:
                        Debug.Log("Computer Clicked");
                        break;

                    case ObjectType.DeskDrawer1:
                        Debug.Log("DeskDrawer1 Clicked");
                        break;

                    case ObjectType.DeskDrawer2:
                        Debug.Log("DeskDrawer2 Clicked");
                        break;

                    case ObjectType.DeskDrawer3:
                        Debug.Log("DeskDrawer3 Clicked");
                        break;

                    case ObjectType.Trunk:
                        Debug.Log("Trunk Clicked");
                        break;

                    case ObjectType.ExitDoor:
                        Debug.Log("Exit Door Clicked");
                        break;

                    case ObjectType.Nightstand:
                        Debug.Log("NightStand Clicked");
                        break;

                    case ObjectType.Plant:
                        Debug.Log("Plant Clicked");
                        break;

                    case ObjectType.Candle:
                        Debug.Log("Candle Clicked");
                        break;

                    default:
                        Debug.Log("This shouldn't be happening.");
                        break;
                        
                }

            }

        } else {
            Debug.Log("Non-interactable game object clicked.");
        }
    }
}