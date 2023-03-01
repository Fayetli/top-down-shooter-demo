using UnityEngine;
using System.Collections.Generic;
using System.Linq;

namespace TopDown.Gameplay.Enemies
{
    public class MeteorController : MonoBehaviour
    {
        [SerializeField] private Meteor meteorPrefab;
        [SerializeField] private Transform player;
        [SerializeField] private Transform container;

        private List<Transform> meteors;

        private float timer = 0f;
        private const float delay = 0.25f;

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
            var spawnPosition = player.position + new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * Random.Range(5f, 6f);

            var meteor = Instantiate(meteorPrefab, spawnPosition, Quaternion.identity, container);
            meteor.Init(player);
            meteors.Add(meteor.transform);
        }
    }
}