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
    

    private void Awake()
    {
        
        //description = GameObject.Find("Item Description").GetComponent<Text>();
        
        itemImage = popUp.transform.Find("Pop Up BG/Item Image").GetComponent<Image>().sprite;
        popUp.gameObject.SetActive(false);
    }

    private void Start()
    {
        uiMan = GameObject.Find("UI").GetComponent<UIManager>();
        
    }

    public void ItemInteracted(int index) //replace with OBJECT class and extract data
    {
        /*
         getting null reference when trying to reference uimanager uiinventory
         */
        Debug.Log("UIManager in UI Item PopUP" + uiMan);
        popUp.gameObject.SetActive(true);
        Debug.Log(uiMan.GetItemAtIndex(index));
        itemImage = uiMan.UIInventory[index].GetImage();
     

    }

    public void ClosePopUp()
    {
        popUp.gameObject.SetActive(false);
    }

}
