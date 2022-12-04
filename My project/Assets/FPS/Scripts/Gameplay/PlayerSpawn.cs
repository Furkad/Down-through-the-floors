using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class PlayerSpawn : MonoBehaviour
    {
        public GameObject player;

        void Awake()
        {
            if (FindObjectOfType<PlayerCharacterController>() == true)
            {
                GameObject thePlayer = FindObjectOfType<PlayerCharacterController>().gameObject;
                thePlayer.transform.position = transform.position;
            }
            else
            {
                Instantiate(player, transform.position, Quaternion.identity);
            }
            Destroy(this);
        }

    }
}
