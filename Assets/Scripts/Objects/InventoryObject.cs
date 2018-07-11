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

    // // Override == so that inventory objects with the same object type are the same 
    // public static bool operator == (InventoryObject obj1, InventoryObject obj2)
    // {
    //     // If left hand side is null...
    //     if (System.Object.ReferenceEquals(obj1, null))
    //     {
    //         // ...and right hand side is null...
    //         if (System.Object.ReferenceEquals(obj2, null))
    //         {
    //             //...both are null and are Equal.
    //             return true;
    //         }

    //         // ...right hand side is not null, therefore not Equal.
    //         return false;
    //     }

    //     return obj1.itemType == obj2.itemType;
    // }

    // public static bool operator != (InventoryObject obj1, InventoryObject obj2)
    // {
    //     // If left hand side is null...
    //     if (System.Object.ReferenceEquals(obj1, null))
    //     {
    //         // ...and right hand side is null...
    //         if (System.Object.ReferenceEquals(obj2, null))
    //         {
    //             //...both are null and are Equal.
    //             return false;
    //         }

    //         // ...right hand side is not null, therefore not Equal.
    //         return true;
    //     }

    //     return obj1.itemType != obj2.itemType;
    // }
}
