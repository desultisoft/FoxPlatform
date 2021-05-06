using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;


namespace ExtendedUnityEvents
{
    [Serializable]
    public class PE : UnityEvent<Player> { }
    
    [Serializable]
    public class GE : UnityEvent{}
}
    
    
