using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;

namespace Unity.FPS.AI
{
    public class SeniorManagerSpawner : MonoBehaviour
    {
        [Tooltip("Points of children enemies spawn")]
        public List<Transform> spawnPoints = new List<Transform>(2);

        [Tooltip("Prefab of spawning enemy")]
        public GameObject childEnemy;

        //[HideInInspector]
        public GameObject[] secretaries = new GameObject[2];

        public Health Health { get; private set; }

        private void Start()
        {
            Health = GetComponent<Health>();
            if (!Health)
            {
                Health = GetComponentInParent<Health>();
            }

            Health.Invincible = true;

            int i = 0;
            foreach (Transform spawnPoint in spawnPoints)
            {
                //if (Physics.Raycast(spawnPoint.position, spawnPoint.TransformDirection(Vector3.down), Mathf.Infinity))
                secretaries[i] = Instantiate(childEnemy, spawnPoint.position, Quaternion.identity);
                i++;
            }
        }


        private void Update()
        {
            if (secretaries[0] == null && secretaries[1] == null)
            {
                Health.Invincible = false;
            }
        }
    }
}
