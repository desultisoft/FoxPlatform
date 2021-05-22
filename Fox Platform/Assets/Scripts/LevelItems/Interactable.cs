using UnityEngine;

namespace Items
{
    public abstract class Interactable : MonoBehaviour
    {
        public bool isUsable = true;
        
        public abstract void Interact(Player player);
    }
}
