using System;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;


namespace ExtendedUnityEvents
{
    [Serializable]
    public class PE : UnityEvent<Player> { }
    
    [Serializable]
    public class I : UnityEvent<int>{}
}
    //[System.Serializable]
    //public class CharS : UnityEvent<Character, string> { }
    
    
