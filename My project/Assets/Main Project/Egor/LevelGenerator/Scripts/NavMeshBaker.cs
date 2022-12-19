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
            Bake(i);
        }
    }

    public void Bake(int floor)
    {
        foreach (NavMeshSurface surface in _rooms[floor].GetComponentsInChildren<NavMeshSurface>())
        {
            surface.BuildNavMesh();
            break;
        }
    }
}
