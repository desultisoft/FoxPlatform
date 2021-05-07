using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class SpeedGem : Item
    {
        public float speedMultiplier = 2;
        public float duration;

        private IEnumerator SpeedUpPlayer(Player player)
        {
            player.itemManager.UnEquip();
            
            //Consume the gem
            player.movement.runSpeed *= speedMultiplier;

            yield return new WaitForSeconds(duration);
            
            //return to normal
            player.movement.runSpeed /= speedMultiplier;
            
        }
        
        public override void Use(Player user)
        {
            user.StartCoroutine(SpeedUpPlayer(user));
        }
    }
}