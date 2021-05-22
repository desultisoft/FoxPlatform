using System;
using System.Collections;
using UnityEngine;

namespace Items
{
    public class SpeedGem : Item
    {
        public float speedMultiplier = 2;
        public float duration;

        private IEnumerator SpeedUpPlayer(Player player)
        {
            player.itemManager.UnEquip();
            float totalGainedSpeed = ((speedMultiplier * player.movement.runSpeed)-player.movement.runSpeed);
            player.movement.runSpeed += totalGainedSpeed;
            for (int i = 0; i < duration; i++)
            {
                player.movement.runSpeed-=totalGainedSpeed / duration;
                yield return new WaitForSeconds(1f);
            }
            
        }

        public override void Use(Player user)
        {
            user.StartCoroutine(SpeedUpPlayer(user));
        }
    }
}