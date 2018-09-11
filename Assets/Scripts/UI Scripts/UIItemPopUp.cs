using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemPopUp : MonoBehaviour {
    //takes care of all the UI stuff.  wow.

    public Canvas popUp;
    Sprite itemImage;
    //Text description;
    UIManager uiMan;
    Inventory inv;
    

    private void Awake()
    {
        
        //description = GameObject.Find("Item Description").GetComponent<Text>();
        
        itemImage = popUp.transform.Find("Pop Up BG/Item Image").GetComponent<Image>().sprite;
        Debug.Log("uipopup Image: " + itemImage);
        
        inv = GameObject.Find("UI").GetComponent<Inventory>();
        // Debug.Log("UI POP UP INV:" + inv + " in Awake");

        popUp.gameObject.SetActive(false); 
    }

    private void Start()
    {
        //uiMan = GameObject.Find("UI").GetComponent<UIManager>();
        
    }

    public void ItemInteracted(int index) //replace with OBJECT class and extract data
    {
        Debug.Log("UIpop index: " +index);
        
        popUp.gameObject.SetActive(true);

        Debug.Log("Inv in UI Item PopUP" +inv);
        Debug.Log(inv.GetItemAtIndex(index));
        itemImage = inv.UIInventory[index].GetImage();
     

    }

    public void ClosePopUp()
    {
        popUp.gameObject.SetActive(false);
    }

}
