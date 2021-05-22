using System;
using System.Collections;
using UnityEngine;

namespace Items
{
    public class PlacedBearTrap : MonoBehaviour
    {
        public float slowPercent = 20f;
        public float duration = 3f;
        
        private Player owner;
        private Animator _animator;
        public  Collider2D _collider;

        public void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void OnCreated(Player creator)
        {
            owner = creator;
            _collider.enabled = true;
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Player player = other.GetComponent<Player>();
            if (player && player != owner)
            {
                _animator.SetTrigger("Snap");
                player.StartCoroutine(FlatSlow(player));
                
                _collider.enabled = false;
                Destroy(gameObject, duration);
            }
        }
        
        private IEnumerator DegenSlow(Player player)
        {
            float convertedPercent = slowPercent / 100;
            float totalLostSpeed = (convertedPercent * player.movement.runSpeed);
            player.movement.runSpeed -= totalLostSpeed;
            for (int i = 0; i < duration; i++)
            {
                player.movement.runSpeed+=totalLostSpeed / duration;
                yield return new WaitForSeconds(1f);
            }
        }
        private IEnumerator FlatSlow(Player player)
        {
            float convertedPercent = slowPercent / 100;
            float totalLostSpeed = (convertedPercent * player.movement.runSpeed);
            player.movement.runSpeed -= totalLostSpeed;
            for (int i = 0; i < duration; i++)
            {
                yield return new WaitForSeconds(1f);
            }
            player.movement.runSpeed+=totalLostSpeed;
        }
    }
}