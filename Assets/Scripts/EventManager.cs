using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager {
    #region Data 
    //the big D

    // Keep track of the player 
    public Player player;

    public CameraMovement mainCameraMover;
    
    #endregion

    public EventManager() {
        // Keeps track of the player
        player = new Player();

        // Get camera script to change cam when necessary
        mainCameraMover = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    public void PerformEquip(ObjectType type) {

        // Unequip item
        if (!ReferenceEquals( player.itemHeld, null )) {

            ObjectType currentItemType = player.itemHeld.type;
            Debug.Log("Unequipping: " + currentItemType);
            player.UnequipInventoryItem();

            // If the item selected was the one equipped, simply unequip
            if (currentItemType == type) return;

        }

        bool result = player.EquipInventoryItem(type);

        if (!result) {
            Debug.Log("Could not equip player with " + type);
            return;
        }

        Debug.Log("Equipped player with " + type);

    }

    // Determines the event upon gameobject selection
    public void PerformEvent(GameObject gameObject) {
        Debug.Log("Event Manager Logic");

        // Check if object is a zoomable space
        ZoomSpace space = gameObject.GetComponent(typeof(ZoomSpace)) as ZoomSpace;
        if (space != null) {

            Debug.Log("Zoom space clicked");

            // Move main camera to the space

            HelperFunctions.printTransform(space.camTarget.transform);
            mainCameraMover.MoveCam(space.camTarget.transform);

            //adjust UI
            UIManager uiManager = GameObject.Find("UI").GetComponent<UIManager>();
            uiManager.DeactivateButtons();

            return;
        }

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

                        // Vent is an openable object and should have the the openable object script; if not TODO!! (throw error)
                        OpenableObject openableObj = gameObject.GetComponent(typeof(OpenableObject)) as OpenableObject;

                        if (!openableObj.isOpen) { // If vent is not open

                            if (!ReferenceEquals( player.itemHeld, null )) { // Player is holding an item

                                if (player.itemHeld.type == ObjectType.Screwdriver) {

                                    Debug.Log("Vent Opened");

                                    // TODO!!
                                    // Change vent sprite

                                    // Open vent
                                    openableObj.isOpen = true;

                                    // Remove screwdriver from player inventory
                                    player.RemoveItem(player.itemHeld);

                                } else {

                                    Debug.Log("Incorrect item used on vent");

                                    // TODO -- Popup telling user that he or she is a dumbass using the wrong item

                                }

                            } else { // Player is not holding an item

                                Debug.Log("Vent clicked with no item");

                                // TODO -- popup telling user that it needs something to open or something

                            }

                        } else { // Vent is open

                            Debug.Log("Vent opened");

                            // If item is in the vent... it should be able to handle itself being clicked

                            // DO NOTHING

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