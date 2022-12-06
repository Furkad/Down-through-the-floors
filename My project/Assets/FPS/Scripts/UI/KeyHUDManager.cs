using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

namespace Unity.FPS.UI
{
    public class KeyHUDManager : MonoBehaviour
    {
        KeyPickup m_KeyPickup;
        NewLevelButton m_NewLevelButton;
        PlayerCharacterController m_PlayerCharacterController;
        [Tooltip("Image of a key in UI")]
        public Image keyImage;

        void Start()
        {
            m_PlayerCharacterController = FindObjectOfType<PlayerCharacterController>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterController, KeyHUDManager>(m_PlayerCharacterController, this);

            /*m_KeyPickup = FindObjectOfType<KeyPickup>();
            DebugUtility.HandleErrorIfNullFindObject<KeyPickup, KeyHUDManager>(m_KeyPickup, this);*/

            m_PlayerCharacterController.HasKey = false;
            keyImage.enabled = false;

            //m_KeyPickup.OnKeyStateSwitch += SwitchImageState;
        }

        private void Update()
        {
            if (m_KeyPickup == null)
            {
                m_KeyPickup = FindObjectOfType<KeyPickup>();
                m_KeyPickup.OnKeyStateSwitch += SwitchImageState;
            }

            if (m_NewLevelButton == null)
            {
                m_NewLevelButton = FindObjectOfType<NewLevelButton>();
                //m_NewLevelButton.ButtonPressed += SwitchImageState;
            }    
        }

        void SwitchImageState(bool state)
        {
            keyImage.enabled = state;
        }

    }
}
