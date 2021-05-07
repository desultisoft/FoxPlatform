using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class SpeedGem : Item
    {
        public float speedMultiplier = 2;
        public float duration;

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

        private IEnumerator SpeedUpPlayer(Player player)
        {
            //Consume the gem
            player.movement.runSpeed *= speedMultiplier;
            rend.enabled = false;
            
            yield return new WaitForSeconds(duration);
            
            //return to normal
            player.movement.runSpeed /= speedMultiplier;
            
            player.Equip(null);
        }
        
        public override void Use(Player user)
        {
            StartCoroutine(SpeedUpPlayer(user));
        }
    }
}