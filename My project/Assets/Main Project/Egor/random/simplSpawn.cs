using UnityEngine;

public class simplSpawn : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnLocations;
    public GameObject roll;
    GameObject[] spawnObjectsResults;
    float angle = 0;
    bool rot=false;
    float speed = 150;
    int chance = 1;

    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;

    void Start()
    {
        spawnObjectsResults = new GameObject[spawnObjects.Length];
        PlayerCamera = FindObjectOfType<Camera>().transform;
    }


    void FixedUpdate()
    {
        if(!rot)
        {
            roll.transform.Rotate(0f, speed * Time.deltaTime, 0f);
        }
        else
        {
            roll.transform.rotation = Quaternion.Euler(angle, 90f, 90f);

        }
        
        if (Input.GetKeyDown(KeyCode.F))
            OnButtonClick();
    }

    void OnButtonClick()
    {
        RaycastHit buttonhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out buttonhit, MaxDistance))
        {
            if (buttonhit.transform.name == name && chance > 0)
            {
                for (int i = 0; i < spawnObjects.Length; i++)
                {
                    spawnObjectsResults[i] = spawnObjects[i];
                }

                for (int i = 0; i < spawnLocations.Length; i++)
                {
                    int nbChildren = spawnLocations[i].childCount;
                    if (nbChildren != 0)
                    {
                        Destroy(spawnLocations[i].GetChild(0).gameObject);
                    }
                }

                int id;
                int count = 0;

                for (int i = 0; i < spawnLocations.Length; i++)
                {
                    count++;
                    id = Random.Range(0, spawnObjectsResults.Length - count);

                    angle = id * 360 / spawnObjects.Length;

                    Instantiate(spawnObjectsResults[id], spawnLocations[i]);
                    spawnObjectsResults = RemoveElement(spawnObjectsResults, id, count);
                    rot = true;
                }

                chance--;
            }
        }
    }

    public static GameObject[] RemoveElement(GameObject[] arr, int id, int count)
    {
        for(int i=id; i<arr.Length-count; i++)
        {
            arr[i] = arr[i + 1];
        }

        return arr;
    }
}
