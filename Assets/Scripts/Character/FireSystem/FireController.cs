using UnityEngine;
using System;

namespace TopDown.Gameplay.FireSystem
{
    public class FireController : MonoBehaviour
    {
        [SerializeField] private Bullet bulletPrefab;
        [SerializeField] private Transform[] firePoints;
        [SerializeField] private Sprite[] bulletSprites;

        private float timer = 0f;
        private bool isRightPoint = false;

        private const float delay = 0.1f;

        private Action onScore;

        private void Update()
        {
            if(Input.GetKey(KeyCode.Space))
            {
                if(timer >= delay)
                {
                    timer = 0f;

                    FireBullet();
                }
            }
        }

        private void FixedUpdate()
        {
            if (timer < delay)
                timer += Time.fixedDeltaTime;
        }

        public void Init(Action onScore)
        {
            this.onScore = onScore;
        }

        private void FireBullet()
        {
            var direction = transform.up;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            var bulletRotation = Quaternion.Euler(Vector3.forward * angle);

            var bullet = Instantiate(bulletPrefab, isRightPoint ? firePoints[0].position : firePoints[1].position, bulletRotation);
            bullet.Init(bulletSprites[UnityEngine.Random.Range(0, bulletSprites.Length)], onScore);
            bullet.Fire();

            Destroy(bullet.gameObject, 5f);
            isRightPoint = !isRightPoint;
        }
    }
}