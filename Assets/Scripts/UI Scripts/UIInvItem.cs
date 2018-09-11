using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInvItem : MonoBehaviour {

    Image image;
    [SerializeField]
    int index;


    public bool IsEmpty { get; set; }

    void Awake()
    {
        image = GetComponent<Image>();

        // Debug.Log("UIInvItem Awake: " + image);

        IsEmpty = true;

        
    }

    public void SetImage(Sprite inSprite)
    {
        image.sprite = inSprite;
        //Debug.Log("UIINVITEM sprite:" + image);
    }

    public Sprite GetImage()
    {
        return image.sprite;
    }

    public int GetIndex() { return index; }

    

    public void EquippedUI()
    {
        //TO DO: have the circle behind equipped object in thing
    }

}
