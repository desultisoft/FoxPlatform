using System;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class InteractManager
{
    [SerializeField] private Interactable _heldInteractable;
    [SerializeField] private LayerMask m_WhatIsInteractable;	
    public void Interact(Player player)
    {
        Collider2D interactableCollider = Physics2D.OverlapCircle(player.transform.position, 3, m_WhatIsInteractable);
        if (interactableCollider)
        {
            Interactable interactable = interactableCollider.GetComponent<Interactable>();
			
            if (interactable is HeldInteractable) //It's something we want to pick up.
            {
                _heldInteractable = interactable;
            }
            else //It's a world interactable.
            {
                interactable.Interact(player);
            }
        }
        else if (_heldInteractable != null)
        {
            _heldInteractable.Interact(player);
        }
    }
}