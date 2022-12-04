using Unity.FPS.Gameplay;
using UnityEngine;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.UI;

public class PlayerSaver : MonoBehaviour
{
    static private GameObject firstInstance = null;
    bool isConnected = false;
    public GameObject GameManager;
    void Awake()
    {
        //Singleton
        if (firstInstance == null)
            firstInstance = gameObject;
        else if (gameObject != firstInstance)
            Destroy(gameObject);

        if (transform.Find("GameManager") == true)
        {
            transform.DetachChildren();
            FindObjectOfType<PlayerCharacterController>().HasKey = false;
            FindObjectOfType<KeyHUDManager>().keyImage.enabled = false;
        }
        else
        {
            Instantiate(GameManager, gameObject.transform);
        }
    }

    private void Start()
    {
        FindObjectOfType<NewLevelButton>().ButtonPressed += Save;
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!isConnected)
        {
            FindObjectOfType<NewLevelButton>().ButtonPressed += Save;
            isConnected = true;
        }
    }

    void Save()
    {
        FindObjectOfType<PlayerCharacterController>().gameObject.transform.SetParent(transform);
        FindObjectOfType<GameFlowManager>().gameObject.transform.SetParent(transform);
    }

}
