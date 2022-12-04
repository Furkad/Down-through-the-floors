using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Unity.FPS.Gameplay
{
    public class NewLevelButton : MonoBehaviour
    {
        Camera m_Camera;
        [Header("MaxDistance you can open or close the door.")]
        [SerializeField]
        private float MaxDistance = 5;

        public UnityAction ButtonPressed;

        private void Start()
        {
            m_Camera = Camera.main;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F) && m_Camera.GetComponentInParent<PlayerCharacterController>().HasKey)
                Pressed();
        }

        void Pressed()
        {
            RaycastHit buttonHit;

            if (Physics.Raycast(m_Camera.transform.position, m_Camera.transform.forward, out buttonHit, MaxDistance))
            {
                if (buttonHit.transform.name == name)
                {
                    if (ButtonPressed != null)
                        ButtonPressed.Invoke();
                    SceneManager.LoadScene("SampleScene");
                }
            }
        }
    }
}