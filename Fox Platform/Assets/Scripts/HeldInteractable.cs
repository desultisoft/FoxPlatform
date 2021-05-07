using UnityEngine;

namespace DefaultNamespace
{
    public class HeldInteractable : Interactable
    {
        public override void Interact(Player player) { Debug.Log("HELDINTERACTABLE USED"); }
    }
}