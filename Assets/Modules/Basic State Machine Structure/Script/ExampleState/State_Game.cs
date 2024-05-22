using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wan_StateMachine
{
    public class State_Game : StateMachine
    {
        public override void Init()
        {
            State_ = StateType.Game;
            Debug.Log($"init {State_}");
        }

        public override void Enter()
        {
            UIManager.Instance.setUi_Game();
        }

        public override void Exit()
        {
            
        }
    }
}
