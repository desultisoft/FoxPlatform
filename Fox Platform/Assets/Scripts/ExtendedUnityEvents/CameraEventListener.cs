using UnityEngine;
using UnityEngine.Events;

namespace TWGFramework
{
    [System.Serializable]
    public class CameraEventListener : MonoBehaviour
    {
        [Tooltip("Event to register with.")]
        public CameraArgEvent UnityCameraEvent;
        
        [SerializeField]
        internal ExtendedUnityEvents.C _CameraEvent;

        private void OnEnable()
        {
            UnityCameraEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            UnityCameraEvent.UnregisterListener(this);
        }

        public void OnEventRaised(Camera e)
        {
            _CameraEvent.Invoke(e);
        }
    }
}