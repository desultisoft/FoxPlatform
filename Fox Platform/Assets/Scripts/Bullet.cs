using System;
using UnityEngine;

namespace DefaultNamespace
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        public event Action<Player> onHit;
        public float velX;
        private Rigidbody2D rb;

        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            rb.velocity = new Vector2(velX, 0);
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            OnHit(other);
        }


        public virtual void OnHit(Collider2D other)
        {
            Destroy(gameObject);
        }
    }
}