using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Wan
{
[Serializable]
public abstract class WanManager : MonoBehaviour
    {
        public void Init()
        {
            Debug.Log($"Create Manager : {this.GetType().Name}");
            InitDetails();
        }

        protected abstract void InitDetails();
        protected abstract bool CreateInstance<T>();
    }
}
