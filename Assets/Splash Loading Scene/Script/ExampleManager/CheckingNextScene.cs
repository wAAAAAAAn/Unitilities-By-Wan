using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckingNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.Instance.Debug_Checking();
        AudioManager.Instance.Debug_Checking();
    }
}
