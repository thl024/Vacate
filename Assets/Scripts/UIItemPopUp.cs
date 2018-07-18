using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIItemPopUp : MonoBehaviour {
    //takes care of all the UI stuff.  wow.

    public Canvas popUp;
    Image itemImage;
    Text description;
    

    private void Awake()
    {
       // popUp = GameObject.Find("ItemInteractPopUp 01").GetComponent<Canvas>();
        
        description = GameObject.Find("Item Description").GetComponent<Text>();
        popUp.gameObject.SetActive(false);
        Debug.Log(description);
    }


    public void ItemInteracted(Text inDescription) //replace with OBJECT class and extract data
    {

        
        popUp.gameObject.SetActive(true);
   
        //itemImage = inImage;
        Debug.Log(inDescription);
        description.text = inDescription.text;
     

    }

    public void ClosePopUp()
    {
        popUp.gameObject.SetActive(false);
    }

}
