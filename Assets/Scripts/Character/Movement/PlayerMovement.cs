using UnityEngine;

namespace TopDown.Gameplay.Movement
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Rigidbody2D rb;

        private Vector2 movement;
        private Vector2 mousePosition;
        private Camera cam;

        private const float angleOffset = 90f;

        private void Start()
        {
            cam = Camera.main;
        }

        private void Update()
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            mousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        private void FixedUpdate()
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

            Vector2 lookDirection = mousePosition - rb.position;
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg - angleOffset;
            rb.rotation = angle;
        }
    }
}