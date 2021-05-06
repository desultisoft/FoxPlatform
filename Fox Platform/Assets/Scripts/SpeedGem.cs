using System.Collections;
using UnityEngine;

namespace DefaultNamespace
{
    public class SpeedGem : Interactable
    {
        public Collider2D collision;
        public SpriteRenderer rend;
        
        public float speedMultiplier = 2;
        public float duration;
        
        public override void Interact(Player player)
        {
            StartCoroutine(SpeedUpPlayer(player));
            StartCoroutine(SetInactiveForAWhile());
        }

        private IEnumerator SpeedUpPlayer(Player player)
        {
            player.movement.runSpeed *= speedMultiplier;
            yield return new WaitForSeconds(duration);
            player.movement.runSpeed /= speedMultiplier;
        }
        
        private IEnumerator SetInactiveForAWhile()
        {
            collision.enabled = false;
            rend.enabled = false;
            yield return new WaitForSeconds(duration);
            collision.enabled = true;
            rend.enabled = true;
        }
    }
}