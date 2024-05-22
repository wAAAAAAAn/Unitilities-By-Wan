using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIElement : MonoBehaviour
{
    protected UIManager uiManager;

    public bool isActive
    {
        set { this.gameObject.SetActive(value);}
    }

    public virtual void Init(UIManager manager)
    {
        uiManager = manager;
    }

    public virtual void UpdatePlayerHP(int value)
    {

    }

    public virtual void UpdateScore(int value)
    {

    }

}
