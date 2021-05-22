using System.Collections.Generic;
using UnityEngine;

namespace TWGFramework
{
    [CreateAssetMenu(menuName = "PlayerArgEvent")]
    public class PlayerArgEvent : ScriptableObject
    {
        public List<PlayerEventListener> _eventListeners = new List<PlayerEventListener>();
        
        public void Raise(Player e)
        {

            for (int i = _eventListeners.Count - 1; i >= 0; i--)
                _eventListeners[i].OnEventRaised(e);
        }

        public void RegisterListener(PlayerEventListener listener)
        {
            if (!_eventListeners.Contains(listener))
                _eventListeners.Add(listener);
        }

        public void UnregisterListener(PlayerEventListener listener)
        {
            if (_eventListeners.Contains(listener))
                _eventListeners.Remove(listener);
        }
    }
}