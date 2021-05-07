using System;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class ItemManager
{
    [SerializeField] private Item _heldItem;
    [SerializeField] private LayerMask m_WhatIsInteractable;
    [SerializeField] private Player _player;
    [SerializeField] private Transform equipSlot;

    public ItemManager(Player player)
    {
        _player = player;
    }

    /// <summary>
    /// Attempt to interact via a button in world.
    /// </summary>
    /// <param name="player"></param>
    public void InteractButton()
    {
        Collider2D interactableCollider = Physics2D.OverlapCircle(_player.transform.position, 3, m_WhatIsInteractable);
        if (interactableCollider)
        {
            Interactable interactable = interactableCollider.GetComponent<Interactable>();
            interactable.Interact(_player);
        }
        else
        {
            Action();
        }
    }
    

    public void Equip(Item item)
    {
        if (_heldItem == null)
        {
            _heldItem = item;
            
            item.transform.parent = equipSlot;
            item.transform.localPosition = Vector3.zero;
        }
            
    }

    public void Action()
    {
        if (_heldItem)
            _heldItem.Use(_player);
    }

    public void Init(Player player)
    {
        _player = player;
    }
}