using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleUI : UIElement
{   
    [Header("Object")]
    public Button startBTN;
    public Button settingBTN;

    public override void Init(UIManager manager)
    {
        base.Init(manager);
        startBTN.onClick.AddListener(()=>uiManager.OpenScreen(UIScreensList.GameHUD));
        settingBTN.onClick.AddListener(()=>uiManager.OpenModal(UIScreensList.Setting));
    }
}
