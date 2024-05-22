using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDUI : UIElement
{
    public Button SettingBTN;
    public Button HomeBTN;

    public override void Init(UIManager manager)
    {
        base.Init(manager);
        SettingBTN.onClick.AddListener(()=>uiManager.OpenModal(UIScreensList.Setting));
        HomeBTN.onClick.AddListener(()=>uiManager.OpenScreen(UIScreensList.HomeScreen));
    }

    public override void UpdatePlayerHP(int value)
    {
        base.UpdatePlayerHP(value);
    }

    public override void UpdateScore(int value)
    {
        base.UpdateScore(value);
    }

    
}
