using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EventManager {
    #region Data 
    //the big D

    // Keep track of the player 
    public Player player;
     
    #endregion

    public EventManager() {
        // Keeps track of the player
        player = new Player();
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

                    case ObjectType.TeddyBear:

                        OpenableObject teddy = gameObject.GetComponent(typeof(OpenableObject)) as OpenableObject;

                        if (!teddy.isOpen) {

                            if (!ReferenceEquals( player.itemHeld, null )) { // Player is holding an item

                                if (player.itemHeld.type == ObjectType.Scissors) {
                                    Debug.Log("Teddy RIPPED APART");

                                    // TODO!!
                                    // Change teddy sprite with teddy.openSprite

                                    // Unlock vent and open it
                                    teddy.isOpen = true;

                                    // Remove scissors from player inventory
                                    player.RemoveItem(player.itemHeld);

                                    // FIND ITEM IN TEDDY BEAR? Add USB to scene??

                                } else {
                                    Debug.Log("Incorrect item used on teddy bear");
                                    // TODO -- Popup telling user that he or she is a dumbass using the wrong item
                                }

                            } else { // Player is not holding an item
                                Debug.Log("Teddy Bear clicked with no item");
                                // TODO -- popup telling user that it needs something to open or something
                            }

                        }

                        break;

                    case ObjectType.Bed:
                        Debug.Log("Bed Clicked");

                        // Bed itself is uninteresting; nothing happens

                        break;

                    // EXAMPLE!!!
                    case ObjectType.Vent:

                        Debug.Log("Vent Clicked");

                        // Vent is an openable object and should have the the openable object script; if not TODO!! (throw error)
                        OpenableObject vent = gameObject.GetComponent(typeof(OpenableObject)) as OpenableObject;

                        if (!vent.isOpen) {

                            if (!ReferenceEquals( player.itemHeld, null )) { // Player is holding an item

                                if (player.itemHeld.type == ObjectType.Screwdriver) {
                                    Debug.Log("Vent Unhinged");

                                    // Change vent sprite
                                    vent.ChangeSprite(vent.openedSprite);

                                    // Unlock vent and open it
                                    vent.isOpen = true;

                                    // Remove screwdriver from player inventory
                                    player.RemoveItem(player.itemHeld);

                                    // Make matches visible
                                    GameObject matches = ObjectDB.Instance.GetObject(ObjectType.Matches);
                                    if (matches == null) {
                                        Debug.Log("Error; matches not on scene");
                                        return;
                                    }
                                    matches.SetActive(true);

                                } else {
                                    Debug.Log("Incorrect item used on vent");
                                    // TODO -- Popup telling user that he or she is a dumbass using the wrong item
                                }

                            } else { // Player is not holding an item
                                Debug.Log("Vent clicked with no item");
                                // TODO -- popup telling user that it needs something to open or something
                            }

                        } else { // Vent is already unlocked
                            Debug.Log("Vent already open");
                            // If item is in the vent... it should be able to handle itself being clicked
                            // DO NOTHING
                        }

                        break;

                    case ObjectType.DeskDrawer:
                        Debug.Log("DeskDrawer Clicked");

                        OpenableObject deskDrawer = gameObject.GetComponent(typeof(OpenableObject)) as OpenableObject;

                        if (!deskDrawer.isOpen) {
                            Debug.Log("Drawer opened");

                            deskDrawer.isOpen = true;
                            // TODO change sprite
                        } else {
                            Debug.Log("Drawer closed");

                            deskDrawer.isOpen = false;
                            // TODO change sprite
                        }

                        break;

                    case ObjectType.Computer:
                        Debug.Log("Computer Clicked");

                        // todo

                        break;

                    case ObjectType.DeskDrawer1:
                        Debug.Log("DeskDrawer1 Clicked");

                        OpenableObject deskDrawer1 = gameObject.GetComponent(typeof(OpenableObject)) as OpenableObject;

                        if (!deskDrawer1.isOpen) {
                            Debug.Log("Drawer1 opened");

                            deskDrawer1.isOpen = true;
                            // TODO change sprite
                        } else {
                            Debug.Log("Drawer1 closed");

                            deskDrawer1.isOpen = false;
                            // TODO change sprite
                        }
                        break;

                    case ObjectType.DeskDrawer2:
                        Debug.Log("DeskDrawer2 Clicked");

                        OpenableObject deskDrawer2 = gameObject.GetComponent(typeof(OpenableObject)) as OpenableObject;

                        if (!deskDrawer2.isOpen) {
                            Debug.Log("Drawer2 opened");

                            deskDrawer2.isOpen = true;
                            // TODO change sprite
                        } else {
                            Debug.Log("Drawer2 closed");

                            deskDrawer2.isOpen = false;
                            // TODO change sprite
                        }

                        break;

                    case ObjectType.DeskDrawer3:
                        Debug.Log("DeskDrawer3 Clicked");

                        // TODO --- lock on the deskdrawer itself

                        break;

                    case ObjectType.Trunk:
                        Debug.Log("Trunk Clicked");

                        LockableObject trunk = gameObject.GetComponent(typeof(LockableObject)) as LockableObject;

                        if (trunk.isLocked) {

                            if (!ReferenceEquals( player.itemHeld, null )) { // Player is holding an item

                                if (player.itemHeld.type == ObjectType.TrunkKey) {
                                    Debug.Log("Trunk unlocked");

                                    // TODO!! Potentially change sprite

                                    // Unlock trunk
                                    trunk.isLocked = false;

                                    // Remove trunk key from inventory
                                    player.RemoveItem(player.itemHeld);

                                } else {
                                    Debug.Log("Incorrect item used on trunk");
                                    // TODO -- Popup telling user that he or she is a dumbass using the wrong item
                                }

                            } else { // Player is not holding an item
                                Debug.Log("Trunk clicked with no item");
                                // TODO -- popup telling user that it needs something to open or something
                            }

                        } else {
                            // Normal drawer opening stuff
                            if (!trunk.isOpen) {
                                Debug.Log("Trunk opened");

                                trunk.isOpen = true;
                                // TODO change sprite
                            } else {
                                Debug.Log("Trunk closed");

                                trunk.isOpen = false;
                                // TODO change sprite
                            }
                        }

                        break;

                    case ObjectType.ExitDoor:
                        Debug.Log("Exit Door Clicked");

                        LockableObject exitDoor = gameObject.GetComponent(typeof(LockableObject)) as LockableObject;

                        if (player.itemHeld.type == ObjectType.KeyCard) {
                            Debug.Log("Unlocked exit door");

                            // WIN GAME LMAO

                        } else {
                            Debug.Log("Exit Door clicked (not correct item or no item at all)");
                        }

                        break;

                    case ObjectType.Nightstand:
                        Debug.Log("NightStand Clicked");

                        LockableObject nightstand = gameObject.GetComponent(typeof(LockableObject)) as LockableObject;

                        if (nightstand.isLocked) {

                            if (!ReferenceEquals( player.itemHeld, null )) { // Player is holding an item

                                if (player.itemHeld.type == ObjectType.NightstandKey) {
                                    Debug.Log("Nightstand unlocked");

                                    // TODO!! Potentially change sprite

                                    // Unlock nightstand
                                    nightstand.isLocked = false;

                                    // Remove nightstand key from inventory
                                    player.RemoveItem(player.itemHeld);

                                } else {
                                    Debug.Log("Incorrect item used on nightstand");
                                    // TODO -- Popup telling user that he or she is a dumbass using the wrong item
                                }

                            } else { // Player is not holding an item
                                Debug.Log("Nightstand clicked with no item");
                                // TODO -- popup telling user that it needs something to open or something
                            }

                        } else {
                            // Normal nightstand opening stuff
                            if (!nightstand.isOpen) {
                                Debug.Log("Drawer3 opened");

                                nightstand.isOpen = true;
                                // TODO change sprite
                            } else {
                                Debug.Log("Drawer3 closed");

                                nightstand.isOpen = false;
                                // TODO change sprite
                            }
                        }

                        break;

                    case ObjectType.Plant:
                        Debug.Log("Plant Clicked");

                        // TODO

                        break;

                    case ObjectType.Candle:
                        Debug.Log("Candle Clicked");

                        MeltableObject candle = gameObject.GetComponent(typeof(MeltableObject)) as MeltableObject;

                        if (!candle.isMelted) {

                             if (!ReferenceEquals( player.itemHeld, null )) { // Player is holding an item

                                if (player.itemHeld.type == ObjectType.Matches) {
                                    Debug.Log("Candle melted");

                                    // TODO!! change sprite

                                    // Unlock deskDrawer
                                    candle.isMelted = true;

                                    // Remove matches from inventory
                                    player.RemoveItem(player.itemHeld);

                                } else {
                                    Debug.Log("Incorrect item used on candle");
                                    // TODO -- Popup telling user that he or she is a dumbass using the wrong item
                                }

                            } else { // Player is not holding an item
                                Debug.Log("Candle clicked with no item");
                                // TODO -- popup telling user that it needs something to open or something
                            }
                            
                        } else {
                            Debug.Log("Candle already melted");
                            // DO NOTHING
                        }

                        break;

                    default:
                        Debug.Log("No code for item clicked. Ensure that if the item is clickable, its bool for clickable is TRUE");
                        break;
                        
                }

            }

        } else {
            Debug.Log("Non-interactable game object clicked.");
        }
    }
}