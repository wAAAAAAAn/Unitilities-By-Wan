using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityCommunity.UnitySingleton;
using UnityEngine;
using Wan;

public class GameManager : WanManager
{
    public static GameManager Instance;

    protected override void InitDetails()
    {
        if(CreateInstance<GameManager>())
        {
            Debug.Log($"Success Create : {this.GetType().Name}");
        }
    }

    protected override bool CreateInstance<T>()
    {
        if(Instance != null)
        {
            Debug.LogError($"{this.GetType().Name} is already created");
            return false;
        }

       Instance = this;
       DontDestroyOnLoad(this);
       return true;
    }

    public void Debug_Checking()
    {
        Debug.Log($"I'm Good [{this.GetType().Name}]");
    }
}