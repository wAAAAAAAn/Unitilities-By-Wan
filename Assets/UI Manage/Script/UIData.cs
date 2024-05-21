using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UIData", menuName = "UIData", order = 0)]
public class UIData : ScriptableObject {
         [ArrayElementTitle("screenName")]
        public List<UIScreen> UIScreens;

}

/// <summary>
    /// UI Screen class.
    /// </summary>
    [System.Serializable]
    public class UIScreen
    {
        public UIScreensList screenName;
        public GameObject screenGameObj;
    }