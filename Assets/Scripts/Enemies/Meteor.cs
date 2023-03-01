using UnityEngine;

namespace TopDown.Gameplay.Enemies
{
    public class Meteor : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D rb;
        [SerializeField] private Vector2 angleRange;
        [SerializeField] private Vector2 speedRange;

        public void Init(Transform player)
        {
            var direction = (player.position - transform.position).normalized;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            angle += Random.Range(angleRange.x, angleRange.y);
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);

            rb.AddForce(transform.right * Random.Range(speedRange.x, speedRange.y));
        }

        public void TakeDamage()
        {
            Destroy(gameObject);
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.TryGetComponent<Character>(out var character))
            {
                character.OnDamaged();
            }
        }
    }
}