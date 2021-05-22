using System;
using UnityEngine;
using UnityEngine.Events;

namespace ExtendedUnityEvents
{
    [System.Serializable]
    public class ArgEventListener<T> : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public ArgEvent<T> UnityPlayerEvent;
        
        [Serializable]
        public class AEL : UnityEvent<T> { }
        
        [SerializeField]
        internal AEL _playerEvent;
        
        private void OnEnable()
        {
            UnityPlayerEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            UnityPlayerEvent.UnregisterListener(this);
        }

        public void OnEventRaised(T e)
        {
            _playerEvent.Invoke(e);
        }
    }
}