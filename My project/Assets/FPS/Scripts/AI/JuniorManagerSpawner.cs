using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

namespace Unity.FPS.AI
{
    public class JuniorManagerSpawner : MonoBehaviour
    {
        [Tooltip("Points of children enemies spawn")]
        public List<Transform> spawnPoints = new List<Transform>(3);

        [Tooltip("Prefab of spawning enemy")]
        public GameObject childEnemy;

        [HideInInspector]
        public bool m_hasSpawned = false;

        public DetectionModule DetectionModule { get; private set; }

        private void Start()
        {
            var detectionModules = GetComponentsInChildren<DetectionModule>();
            DetectionModule = detectionModules[0];
            DetectionModule.onDetectedTarget += OnDetectedTarget;
        }

        void OnDetectedTarget()
        {
            if (!m_hasSpawned)
            {
                foreach (Transform spawnPoint in spawnPoints)
                {
                    //if (Physics.Raycast(spawnPoint.position, spawnPoint.TransformDirection(Vector3.down), Mathf.Infinity))
                        Instantiate(childEnemy, spawnPoint.position, Quaternion.identity);
                }
                m_hasSpawned = true;
            }
        }
    }
}
