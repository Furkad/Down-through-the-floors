using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

namespace Unity.FPS.Gameplay
{
    public class LiftDoorsOpen : MonoBehaviour
    {
        public Transform PlayerCamera;
        [Header("MaxDistance you can open or close the door.")]
        public float MaxDistance = 5;

        public Animator anim;

        private void Start()
        {
            PlayerCamera = FindObjectOfType<Camera>().transform;
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Pressed();
            }
        }

        void Pressed()
        {
            RaycastHit buttonhit;

            if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out buttonhit, MaxDistance))
            {
                if (buttonhit.transform.name == name)
                {
                    anim.SetTrigger("Opened");
                }
            }
        }
    }
}
