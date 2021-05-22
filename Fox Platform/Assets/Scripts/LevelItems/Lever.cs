using UnityEngine;
using UnityEngine.Events;

namespace Items
{
    public class Lever : Interactable
    {

        public UnityEvent onPulled;
        private Animator animator;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        public override void Interact(Player player)
        {
            animator.SetBool("IsMoved", true);
        }

        public void OnAnimationEnd()
        {
            isUsable = false;
            onPulled.Invoke();
        }
    }
}