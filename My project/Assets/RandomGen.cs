using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomGen : MonoBehaviour
{
    public GameObject wall;

    public GameObject floor;

    int length, width;

    void ploshad ()
    {
        length = Random.Range(3, 10);
        width = Random.Range(3, 10);
    }

    void postroenie()
    {
        for (int i = 0; i < length; i++)
        {
            for(int j = 0; j < width; j++)
            {
                
            }
        }
    }
    
}
