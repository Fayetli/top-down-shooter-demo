using TopDown.Gameplay.Enemies;
using UnityEngine;

namespace TopDown.Gameplay.FireSystem
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private float force;
        [SerializeField] private SpriteRenderer spriteRenderer;

        public void Init(Sprite sprite)
        {
            spriteRenderer.sprite = sprite;
        }

        public void Fire()
        {
            rb.AddForce(transform.right * force);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.TryGetComponent<Meteor>(out var meteor))
            {
                meteor.TakeDamage();
                Destroy(gameObject);
            }
        }
    }
}