using System.Collections.Generic;
using Characters;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Items
{
    public class GhostSpawner : MonoBehaviour
    {
        [Header("Ghost List")]
        [SerializeField]
        private List<GameObject> ghosts = new List<GameObject>();

        [Header("Spawn Points")]
        [SerializeField]
        private Transform point1;
        [SerializeField]
        private Transform point2;

        [Header("Spawn Params")]
        [SerializeField]
        private float spawnLimit;
        [Range(0.1f, 5.0f)]
        [SerializeField]
        private float spawnRate = 1;

        // Private vars
        private float _timer;
        private float _spawnIncrease = 1;
        private float _ghostCounter;

        private void Start()
        {
            _timer = 0;
        }

        private void Update()
        {
            Spawn();
        }

        private void OnEnable()
        {
            Ghost.OnGhostDeath += DecreaseGhostCounter;
        }

        private void OnDisable()
        {
            Ghost.OnGhostDeath -= DecreaseGhostCounter;
        }

        private void Spawn()
        {
            if (!(_ghostCounter < spawnLimit)) return;

            _timer += Time.deltaTime * _spawnIncrease;

            if (_timer >= spawnRate)
            {
                var randGhost = Random.Range(0, ghosts.Count);

                var position1 = point1.position;
                var position2 = point2.position;
                var randPos = Random.Range(position1.x, position2.x);

                _ghostCounter++;

                Instantiate(ghosts[randGhost], new Vector3(randPos, position1.y, 0), Quaternion.identity);

                _timer = 0;
            }
        }

        private void DecreaseGhostCounter()
        {
            _ghostCounter--;
        }
    }
}