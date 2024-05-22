using System.Collections;
using System.Collections.Generic;
using UnityCommunity.UnitySingleton;
using UnityEngine;

/*
이 스크립트는 게임 플로우를 관리할 스테이트 머신 매니저 입니다.
StateData에서 리스트를 받아와 추가로 스테이트를 동적 생성합니다.
*/

namespace Wan_StateMachine
{
    public class StateManager : MonoSingleton<StateManager>
    {
        public StateData stateData;

        private Dictionary<StateType, IState> stateInstance_;
        private IState currentState;

        public IState CurrentState
        {
            get { return currentState; }
        }

        public void Init()
        {
            stateInstance_ = new Dictionary<StateType, IState>();
            GameObject StateParent = new GameObject("States");

            IState createdState;
            foreach (var state in stateData.States)
            {
                createdState = GameObject.Instantiate(state, StateParent.transform).GetComponent<IState>();

                createdState.Init();

                if(stateInstance_.ContainsKey(createdState.GetStateType()))
                {
                    Debug.LogError($"StateMachine :: This State already create. {createdState.GetStateType()}");
                }
                else
                {
                    stateInstance_.Add(createdState.GetStateType(), createdState);
                }
            }
        }

        // 현재 실행 중인 스테이트를 전환하기 위한 함수 
        public void ChangeState(StateType _newState)
        {
            ChangeState_(stateInstance_[_newState]);
        }

        private void ChangeState_(IState _newState)
        {
            if (currentState == _newState)
            {
                Debug.Log($"<color=red>StateMachine :: tried to change it even though it was in the same state. {_newState}</color>");
                return;
            }

            if (currentState is not null)
                currentState.Exit();

            Debug.Log($"<color=red>StateMachine :: {currentState} ==> {_newState}</color>");

            currentState = _newState;
            currentState.Enter();
        }


        //현재 실행중인 스테이트 타입을 비교하기 위한 함수
        public bool EqualState(StateType _state)
        {
            IState state = stateInstance_[_state];
            return currentState == state;
        }
    }
}
