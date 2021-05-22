using System.Collections.Generic;
using UnityEngine;

namespace TWGFramework
{
    [CreateAssetMenu(menuName = "CameraArgEvent")]
    public class CameraArgEvent : ScriptableObject
    {
        public List<CameraEventListener> _eventListeners = new List<CameraEventListener>();
        
        public void Raise(Camera e)
        {

            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(e);
        }

        public void RegisterListener(CameraEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(CameraEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}