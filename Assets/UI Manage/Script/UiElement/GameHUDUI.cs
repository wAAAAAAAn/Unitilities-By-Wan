using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameHUDUI : UIElement
{
    public GameObject[] HPobjects;
    public TMPro.TMP_Text ScoreText;
    public CanvasGroup uiGroup; // CanvasGroup 컴포넌트가 할당될 변수
    public TMPro.TMP_Text stageText;

    public override void Init(UIManager manager)
    {
        base.Init(manager);
    }

    public void PauseOpen()
    {
        uiManager.OpenModal(UIScreensList.Pause);
    }

    public override void UpdatePlayerHP(int value)
    {
        base.UpdatePlayerHP(value);

        for(int i = 0;i< HPobjects.Length;i++)
        {
            if(i<value)
            {
                HPobjects[i].gameObject.SetActive(true);
            }
            else
            {
                HPobjects[i].gameObject.SetActive(false);
            }
        }
    }

    public override void UpdateScore(int value)
    {
        base.UpdateScore(value);
        ScoreText.text = value.ToString();
    }

    
}
