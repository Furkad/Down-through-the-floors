using System.Collections;
using System.Collections.Generic;
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
    int cheance = 1;



    void Start()
    {
        spawnObjectsResults = new GameObject[spawnObjects.Length];
    }


    void FixedUpdate()
    {
        if(!rot && cheance>0)
        {
            roll.transform.Rotate(0, speed * Time.deltaTime, 0);
        }
        else if (cheance > 0)
        {
           // roll.transform.Rotate();
            cheance--;
            rot = false;
            //roll.transform.Rotate(0, angle, 0);

            roll.transform.rotation = Quaternion.Euler(0f, 0f, 0f);

        }       
    }
    private void OnMouseDown()
    {
        if (cheance > 0)
        {
            randomWeapon();
        }
        
    }
    void randomWeapon()
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
