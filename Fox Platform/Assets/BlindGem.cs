using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Items
{
    public class BlindGem : Item
    {
        public float duration;
        private IEnumerator BlindPlayer(Player player)
        {
            player.itemManager.UnEquip();


            Player target = PlayerManager.Instance.players.Where(x => x != player).FirstOrDefault();
            
            target.cameraController.ToggleBlind(true);
            yield return new WaitForSeconds(duration);
            target.cameraController.ToggleBlind(false);
            
        }
        
        public override void Use(Player user)
        {
            user.StartCoroutine(BlindPlayer(user));
        }
    }
}

