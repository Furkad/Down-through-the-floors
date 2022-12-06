using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class PlayerSpawn : MonoBehaviour
    {
        public GameObject player;

        void Awake()
        {
            if (FindObjectOfType<PlayerCharacterController>() == null && transform.parent.transform.parent.transform.parent.name == "Level (0)")
            {
                Instantiate(player, transform.position, Quaternion.identity);
                Destroy(this);
            }
        }

        /*                GameObject thePlayer = FindObjectOfType<PlayerCharacterController>().gameObject;
                thePlayer.transform.position = transform.position;
            }
            else
            {*/

    }
}
