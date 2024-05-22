using UnityEngine;
using System.Collections.Generic;
using UnityCommunity.UnitySingleton;
/*
UI를 동적으로 캔버스에 생성하고 관리하는 매니저
*/

public class UIManager : MonoSingleton<UIManager>
    {
        [Header("Datas")]
        public UIData uiData;

        [Header("UI")]
        public Transform UICanvas;

        [SerializeField]
        private UIElement lastScreen, openScreen, modalScreen;

        private Stack<UIElement> modalHistory;
        public UIElement CurrentScreen
        {
            get { return openScreen; }
        }

        protected Dictionary<UIScreensList, UIElement> screensDictionary = new Dictionary<UIScreensList, UIElement>();

        public void Init()
        {
            UIElement element;
            foreach (var screen in uiData.UIScreens)
            {
                element = Instantiate(screen.screenGameObj, UICanvas).GetComponent<UIElement>();
                element.Init(this);
                element.gameObject.SetActive(false);

                screensDictionary.Add(screen.screenName, element);
            }

            modalHistory = new Stack<UIElement>();
        }
        public void OpenScreen(UIScreensList screenName)
        {
            UIElement screen = null;
            if (screensDictionary.TryGetValue(screenName, out screen))
            {
                if (openScreen != null)
                {
                    openScreen.isActive = false;

                        lastScreen = openScreen;
                }

                screen.isActive = true;
                openScreen = screen;
            }
            else
            {
                Debug.LogError("Screen does not exist");
            }
        }

        public bool CheckScreen(UIScreensList screenName)
        {
            UIElement screen = null;
            if (screensDictionary.TryGetValue(screenName, out screen))
            {
                if (openScreen != null)
                {
                    return false;
                }
                return openScreen == screen;
            }
            else
            {
                Debug.LogError("Screen does not exist");
                return false;
            }
        }


        public void Back()
        {
            if (lastScreen != null)
                lastScreen.isActive = true;

            openScreen.isActive = false;

                    UIElement temp = lastScreen;
                     lastScreen = openScreen;
                    openScreen = temp;
        }

  
        public void OpenModal(UIScreensList screenName)
        {
            UIElement screen = null;
            if (screensDictionary.TryGetValue(screenName, out screen))
            {
                screen.isActive = true;
                modalScreen = screen;

                modalHistory.Push(modalScreen);
            }
            else
            {
                Debug.LogError("Screen does not exist");
            }
        }

        public void CloseModal()
        {
            Debug.Log(modalHistory.Count );

            if (modalHistory.Count != 0)
                {
                    modalHistory.Pop().isActive =false;
                }
        }

        public void CloseAllModal()
        {
            while(modalHistory.Count !=0)
            {
                modalHistory.Pop().isActive = false;
            }
        }

        public void CloseModal(UIScreensList uIScreensList)
        {
            UIElement screen = null;
            if (screensDictionary.TryGetValue(uIScreensList, out screen))
            {
                screen.gameObject.SetActive(false);
            }
            else
            {
                Debug.LogError("Screen does not exist");
            }
        }
    }