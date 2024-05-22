using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wan_StateMachine
{
    public class State_Lobby : StateMachine
    {
       public override void Init()
        {
            State_ = StateType.Lobby;
            Debug.Log($"init {State_}");
        }

        public override void Enter()
        {
            UIManager.Instance.setUi_Lobby();
        }

        public override void Exit()
        {
            
        }
    }
}
