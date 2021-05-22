using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace
{
    
    public class SlowPlayerOnTouch : MonoBehaviour
    {
        public float slowPercent;
        public float duration;
        
        public void OnTriggerEnter2D(Collider2D other)
        {
            Player player = other.GetComponent<Player>();
            if (player)
            {
                 player.StartCoroutine(DegenSlow(player));
            }
        }
        
        private IEnumerator DegenSlow(Player player)
        {
            float convertedPercent = slowPercent / 100;
            float totalLostSpeed = (convertedPercent * player.movement.runSpeed);
            player.movement.runSpeed -= totalLostSpeed;
            for (int i = 0; i < duration; i++)
            {
                yield return new WaitForSeconds(1f);
                player.movement.runSpeed+=totalLostSpeed / duration;
            }
        }
    }
}