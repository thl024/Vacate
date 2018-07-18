using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {
    //takes care of all the UI stuff.  wow.

    public Canvas popUp;
    Image itemImage;
    Text description;
    CameraMovement mainCam;

    public Transform[] roomsList;

    private void Awake()
    {
       // popUp = GameObject.Find("ItemInteractPopUp 01").GetComponent<Canvas>();
        
        description = GameObject.Find("Item Description").GetComponent<Text>();
        popUp.gameObject.SetActive(false);
        Debug.Log(description);

        mainCam = GameObject.Find("Main Camera").GetComponent<CameraMovement>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
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

    public void RightButton()
    {

    }
}
