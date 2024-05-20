using System.Collections;
using System.Collections.Generic;
using UnityCommunity.UnitySingleton;
using UnityEngine;
using UnityEngine.UI;

namespace Wan_StateMachine
{
public class StateTest : MonoSingleton<StateTest>
{
    public void Start() {

        StateManager.Instance.Init();
        StateManager.Instance.ChangeState(StateType.Intro);
    }
    
    }
}