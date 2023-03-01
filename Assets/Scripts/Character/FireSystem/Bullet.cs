using UnityEngine;
using TopDown.Gameplay.Enemies;
using System;

namespace TopDown.Gameplay.FireSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float force;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private Action onScore;

        public void Init(Sprite sprite, Action onScore)
        {
            spriteRenderer.sprite = sprite;
            this.onScore = onScore;
        }

        public void Fire()
        {
            rb.AddForce(transform.right * force);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<Meteor>(out var meteor))
            {
                onScore?.Invoke();
                meteor.TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}