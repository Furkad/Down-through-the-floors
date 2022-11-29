using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;
using UnityEngine.SceneManagement;

namespace Unity.FPS.Gameplay
{
    public class NewLevelButton : MonoBehaviour
    {
        Camera m_Camera;
        Transform m_PlayerTransform;

        private void Start()
        {
            m_Camera = Camera.main;
            m_PlayerTransform = GameObject.Find("Player").transform;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                RaycastHit hit;
                Ray ray = m_Camera.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);
                if (hit.transform.position == transform.position && ((Mathf.Abs(hit.transform.position.x-m_PlayerTransform.position.x) < 1f) || Mathf.Abs(hit.transform.position.z - m_PlayerTransform.position.z) < 1f))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
            }
        }


    }
}