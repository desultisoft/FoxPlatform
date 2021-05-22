using UnityEngine;
using UnityEngine.Events;

namespace TWGFramework
{
    [System.Serializable]
    public class PlayerEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public PlayerArgEvent UnityPlayerEvent;
        
        [SerializeField]
        internal ExtendedUnityEvents.PE _playerEvent;

        private void OnEnable()
        {
            UnityPlayerEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            UnityPlayerEvent.UnregisterListener(this);
        }

        public void OnEventRaised(Player e)
        {
            _playerEvent.Invoke(e);
        }
    }
}