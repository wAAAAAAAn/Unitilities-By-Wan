using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SettingUI : UIElement
{
    public Button OpneModalBTN;
    public Button CloseBTN;
public override void Init(UIManager manager)
    {
        base.Init(manager);
        CloseBTN.onClick.AddListener(()=>uiManager.CloseModal());
        OpneModalBTN.onClick.AddListener(()=>uiManager.OpenModal(UIScreensList.ModalDepthTest));
    }
}
