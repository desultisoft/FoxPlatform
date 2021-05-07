using System;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(SpriteRenderer))]
public abstract class Item : MonoBehaviour
{
    protected Collider2D collision;
    protected SpriteRenderer rend;
    
    public void OnTriggerEnter2D(Collider2D other)
    {
        //Pickup the item.
        Player player = other.GetComponent<Player>();
        if (player)
        {
            player.Equip(this);
            collision.enabled = false;
        }
    }
    
    public void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        collision = GetComponent<Collider2D>();
    }

    public abstract void Use(Player user);
}