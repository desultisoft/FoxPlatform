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
                 player.StartCoroutine(Slow(player));
            }
        }
        
        private IEnumerator Slow(Player player)
        {
            float convertedPercent = slowPercent / 100;

            float lostSpeed = convertedPercent *= player.movement.runSpeed;
            player.movement.runSpeed -= lostSpeed;
            
            yield return new WaitForSeconds(duration);
            
            player.movement.runSpeed += lostSpeed;
        }
    }
}