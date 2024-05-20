using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Wan_Splash
{
    [CreateAssetMenu(fileName = "InitialData", menuName = "InitialData", order = 0)]
public class InitialData : ScriptableObject
{
    public List<GameObject> PersistentManager; // 런타임 중 계속 동작될 매니저들
}

}
