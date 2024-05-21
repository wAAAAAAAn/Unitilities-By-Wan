using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 
public class TitleUI : UIElement
{

    [Header("UI")]
    
    [Header("Object")]
    public GameObject Title;

    public override void Init(UIManager manager)
    {
        base.Init(manager);

       // LightManager.Instance.AddMapLightReceiver(gameObject);

    }
}
