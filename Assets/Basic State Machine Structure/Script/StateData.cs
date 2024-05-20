using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
이 스크립트는 스테이트가 추가적으로 생성이 되어도 관리할 수 있게 스크립터블 오브젝트로 만들어 관리를 합니다.
*/

namespace Wan_StateMachine
{
[CreateAssetMenu(fileName = "StateData", menuName = "StateMachine/StateData", order = 0)]
public class StateData : ScriptableObject {
    public List<GameObject> States;
}

    public enum StateType
    {
        None,
        Intro,
        Lobby,
        Game
    }
}