using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInvItem : MonoBehaviour {

    Image image;
    [SerializeField]
    int index;
    

    void Awake()
    {
        image = GetComponent<Image>();
        
        Debug.Log("UIInvItem Awake: " + image);

        
    }

    public void SetImage(Sprite inSprite)
    {
        image.sprite = inSprite;
        Debug.Log("UIINVITEM sprite:" + image);
    }

    public int GetIndex() { return index; }

    

    

}
