using UnityEngine;
using UnityEngine.Events;

namespace TWGFramework
{
    [System.Serializable]
    public class GameEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public GameEvent GameEvent;
        
        [SerializeField]
        internal ExtendedUnityEvents.GE _gameEvent;

        private void OnEnable()
        {
            GameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            GameEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            _gameEvent.Invoke();
        }
    }
}