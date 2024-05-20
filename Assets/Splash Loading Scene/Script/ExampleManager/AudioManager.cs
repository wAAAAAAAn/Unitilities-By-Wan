using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityCommunity.UnitySingleton;

namespace Wan_Splash
{
public class AudioManager : WanManager
{
   public static AudioManager Instance;

    protected override void InitDetails()
    {
        if(CreateInstance<AudioManager>())
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
}