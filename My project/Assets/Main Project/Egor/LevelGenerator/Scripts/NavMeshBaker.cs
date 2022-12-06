using UnityEngine;
using UnityEngine.AI;
using System.Collections.Generic;
public class NavMeshBaker : MonoBehaviour
{
    //private List<NavMeshSurface> _navMeshSurfaces;
    [SerializeField]
    private List<GameObject> _rooms;
    
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            foreach (NavMeshSurface surface in _rooms[i].GetComponentsInChildren<NavMeshSurface>())
            {
                //_navMeshSurfaces.Add(surface);
                surface.BuildNavMesh();
            }
        }
            
    }

}
