using System.Collections;
using System.Collections.Generic;
using UnityCommunity.UnitySingleton;
using UnityEngine;
using UnityEngine.UI;

/*
스테이트 예시를 위한 UI매니저
싱글톤으로 호출하여 각 스테이트별 동작을 임시로만 구현 
*/

namespace Wan_StateMachine
{
    public class UIManager : MonoSingleton<UIManager>
    {
        [Header("Intro")]
        public GameObject introStateObject;

        [Header("Lobby")]
        public GameObject lobbyStateObject;
        public Button gameStartButton;

        [Header("Game")]
        public GameObject gameStateObject;
        public Button gameEndButton;

        GameObject CurrentUI;

        public void Start()
        {
            gameStartButton.onClick.AddListener(() =>
            {
                StateManager.Instance.ChangeState(StateType.Game);
            });

            gameEndButton.onClick.AddListener(() =>
            {
                StateManager.Instance.ChangeState(StateType.Lobby);
            });
        }

        public void setUi_Lobby()
        {
            lobbyStateObject.SetActive(true);
            gameStateObject.SetActive(false);
        }

        public void setUi_Game()
        {
            gameStateObject.SetActive(true);
            lobbyStateObject.SetActive(false);
        }
    }
}