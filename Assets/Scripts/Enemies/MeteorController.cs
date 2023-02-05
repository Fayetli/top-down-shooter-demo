using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TopDown.Gameplay.Enemies
{
    public class MeteorController : MonoBehaviour
    {
        [SerializeField] private Meteor meteorPrefab;
        [SerializeField] private Transform player;
        [SerializeField] private Transform container;
        private List<Transform> meteors;

        private float timer = 0f;
        private float delay = 2f;
        private const float decreaseDelayVolume = 0.1f;
        private Vector2 clampDelay = new Vector2(0.25f, 2f);

        private void Start()
        {
            meteors = new List<Transform>();
        }

        private void Update()
        {
            timer += Time.deltaTime;

            if(timer >= delay)
            {
                timer = 0f;
                delay -= decreaseDelayVolume;
                delay = Mathf.Clamp(delay, clampDelay.x, clampDelay.y);

                GenerateMeteor();
            }
        }

        private void FixedUpdate()
        {
            meteors = meteors.FindAll(m => m != null);
            foreach (var meteor in meteors)
                if (Vector2.Distance(player.position, meteor.position) > 10f)
                    Destroy(meteor.gameObject);
        }

        private void GenerateMeteor()
        {
            var spawnPosition = player.position +
                new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized
                * Random.Range(5f, 6f);

            var meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity, container);
            meteor.Init(player);
            meteors.Add(meteor.transform);
        }
    }
}