using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInvItem : MonoBehaviour {

    Image image;
    Image equipUI;
    [SerializeField]
    int index;


    public bool IsEmpty { get; set; }
    public bool IsEquipped { get; set; }

    void Awake()
    {
        image = transform.Find("ItemImage").GetComponent<Image>();
        equipUI = transform.Find("EquippedUI").GetComponent<Image>();
        Debug.Log("equip UI: " + equipUI);

        IsEmpty = true;
        IsEquipped = true;
        EquippedUI();

        
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
        IsEquipped = !IsEquipped;
        equipUI.gameObject.SetActive(IsEquipped);
        Debug.Log("equipping UI" + equipUI);

    }

}
