using System.Collections.Generic;
using UnityEngine;

namespace ExtendedUnityEvents
{
    using UnityEngine;

    public class ArgEvent<T> : ScriptableObject
    {
        public List<ArgEventListener<T>> _eventListeners = new List<ArgEventListener<T>>();
        
        public void Raise(T e)
        {

            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(e);
        }

        public void RegisterListener(ArgEventListener<T> listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(ArgEventListener<T> listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}