using UnityEngine;
using UnityEngine.AI;
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
        private LevelCounter counter;

        public UnityAction ButtonPressed;

        private void Start()
        {
            m_Camera = Camera.main;
            counter = FindObjectOfType<LevelCounter>();
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
                    if (counter.counter < 4)
                    {
                        var TheLevel = GameObject.Find("Level (" + counter.counter + ")");
                        counter.GetComponent<LevelCounter>().counter++;
                        var NewLevel = GameObject.Find("Level (" + counter.counter + ")");
                        NewLevel.transform.Find("SpawnRoom(Clone)").gameObject.transform.Find("GameObject").transform.Find("wall2").transform.Find("elevator_wall").transform.Find("New Level Button").gameObject.SetActive(true);
                        NewLevel.transform.Find("SpawnRoom(Clone)").transform.Find("GameObject").transform.Find("door").gameObject.GetComponent<Animator>().SetTrigger("Closed");
                        FindObjectOfType<PlayerCharacterController>().transform.position = NewLevel.transform.Find("SpawnRoom(Clone)").transform.Find("GameObject").transform.Find("PlayerSpawn").transform.position;
                        FindObjectOfType<PlayerCharacterController>().transform.rotation = NewLevel.transform.Find("SpawnRoom(Clone)").transform.Find("GameObject").transform.Find("PlayerSpawn").transform.rotation;
                        FindObjectOfType<PlayerCharacterController>().HasKey = false;
                        Destroy(TheLevel);
                        //ButtonPressed.Invoke();
                    }
                    else
                    {
                        Cursor.lockState = CursorLockMode.None;
                        Cursor.visible = true;
                        SceneManager.LoadScene("mainMenu");
                    }
                }
            }
        }
    }
}