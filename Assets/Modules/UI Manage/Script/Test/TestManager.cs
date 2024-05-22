using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestManager : MonoBehaviour
{
    private void Start() {
        UIManager.Instance.Init();
        UIManager.Instance.OpenScreen(UIScreensList.HomeScreen);
    }
}
