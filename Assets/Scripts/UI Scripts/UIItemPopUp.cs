using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemPopUp : MonoBehaviour {
    //takes care of all the UI stuff.  wow.

    public Canvas popUp;
    Image itemImage;
    //Text description;
    UIManager uiMan;
    Inventory inv;
    

    private void Awake()
    {
        
        //description = GameObject.Find("Item Description").GetComponent<Text>();
        
        itemImage = popUp.transform.Find("Pop Up BG/Item Image").GetComponent<Image>();
        Debug.Log("uipopup Image: " + itemImage); //this works. 10/4/18
        
        inv = GameObject.Find("UI").GetComponent<Inventory>();
        Debug.Log("UI POP UP INV:" + inv + " in Awake");

        popUp.gameObject.SetActive(false); 
    }

    private void Start()
    {
        //uiMan = GameObject.Find("UI").GetComponent<UIManager>();
        
    }

    public void ItemInteracted(int index) //replace with OBJECT class and extract data
    {   //the index comes from the onClick(); is manually linked.

        Debug.Log("itemImage: " +itemImage+ "\nnew item image: " + inv.GetItemAtIndex(index).GetImage());
        itemImage.sprite = inv.GetItemAtIndex(index).GetImage();
        popUp.gameObject.SetActive(true);

        //Debug.Log("Inv in UI Item PopUP" +inv); //this works: we got our inv.
        
       // itemImage = inv.GetItemAtIndex(index).GetImage();
     

    }

    public void ClosePopUp()
    {
        popUp.gameObject.SetActive(false);
    }

}
