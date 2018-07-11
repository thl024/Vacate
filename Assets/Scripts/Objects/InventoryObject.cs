using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryObject : InteractableObject {

    public InventoryObjectType itemType;

    // Use this for initialization
    void Start () {
        
    }
    
    // Update is called once per frame
    void Update () {
        
    }

    // Override == so that inventory objects with the same object type are the same 
    public static bool operator == (InventoryObject obj1, InventoryObject obj2)
    {
        return obj1.itemType == obj2.itemType;
    }

    public static bool operator != (InventoryObject obj1, InventoryObject obj2)
    {
        return obj1.itemType != obj2.itemType;
    }
}
