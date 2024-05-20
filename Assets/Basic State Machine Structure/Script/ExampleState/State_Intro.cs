using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wan_StateMachine
{
    public class State_Intro : StateMachine
    {

         public override void Init()
        {
            State_ = StateType.Intro;
            Debug.Log($"init {State_}");
        }
        public override void Enter()
        {
            StartCoroutine(Intro());
        }

        public override void Exit()
        {
            UIManager.Instance.introStateObject.SetActive(false);
        }

    public IEnumerator Intro()
    {
        StateManager.Instance.ChangeState(StateType.Intro);
        UIManager.Instance.introStateObject.SetActive(true);

        yield return new WaitForSeconds(2);
        StateManager.Instance.ChangeState(StateType.Lobby);
    }

    }
}