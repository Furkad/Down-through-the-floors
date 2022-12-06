using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class LevelCounter : MonoBehaviour
    {
        public int counter = 0;
        private void Start()
        {
            counter = 0;
            for(int i = 1; i < 5; i++)
            {
                GameObject.Find("Level (" + i + ")").transform.Find("SpawnRoom(Clone)").gameObject.transform.Find("New Level Button").gameObject.SetActive(false);
            }
        }
    }
}
