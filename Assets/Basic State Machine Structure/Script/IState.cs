using UnityEngine;

namespace Wan_StateMachine
{
    public interface IState
    {
        void Enter();
        void Exit();
        StateType GetStateType();
        void Init();
    }

    public abstract class StateMachine : MonoBehaviour, IState
    {
        protected StateType State_;

        public StateType GetStateType()
        {
            return State_;
        }
        
        public abstract void Enter();
        public abstract void Exit();
        public abstract void Init();
    }
}