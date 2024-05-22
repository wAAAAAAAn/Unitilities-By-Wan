using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModalDepthTestUI : UIElement
{
    public Button CloseBTN;
    public Button CloseAllBTN;

    public override void Init(UIManager manager)
    {
        base.Init(manager);
        CloseBTN.onClick.AddListener(()=> uiManager.CloseModal());
        CloseAllBTN.onClick.AddListener(()=> uiManager.CloseAllModal());

    }

}
