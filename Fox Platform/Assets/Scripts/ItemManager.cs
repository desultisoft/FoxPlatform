using System;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class ItemManager
{
    [SerializeField] private float interactRadius = 1;
    [SerializeField] private Item _heldItem;
    [SerializeField] private LayerMask m_WhatIsInteractable;
    [SerializeField] private Player _player;
    [SerializeField] private Transform equipSlot;
    [SerializeField] private Interactable interactable;
    public bool isHoldingItem => _heldItem != null;

    /// <summary>
    /// Attempt to interact via a button in world.
    /// </summary>
    /// <param name="player"></param>
    public void InteractButton()
    {
        //Sense interaction.
        Collider2D interactableCollider = Physics2D.OverlapCircle(_player.transform.position, interactRadius, m_WhatIsInteractable);
        if (interactableCollider)
        {
              interactable = interactableCollider.GetComponent<Interactable>();
        }
        
        //If interaction is possible, do it otherwise take an action.
        if (interactable != null && interactable.isUsable)
        {
            interactable.Interact(_player);
        }
        else
            Action();
        
    }
    

    public void Equip(Item item)
    {
        if (_heldItem == null)
        {
            _heldItem = item;
            
            if (item != null)
            {
                item.OnEquip(_player);
                
                //Handle the world position and parenting.
                item.transform.parent = equipSlot;
                item.transform.localPosition = Vector3.zero;
                item.gameObject.SetActive(true);
            }
        }
    }

    public void UnEquip()
    {
        if (_heldItem != null)
        {
            _heldItem.OnUnEquip();
            
            //Handle the world position and parenting.
            _heldItem.transform.parent = null;
            _heldItem.transform.localPosition = Vector3.zero;
            _heldItem.gameObject.SetActive(false);
        }

        _heldItem = null;
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