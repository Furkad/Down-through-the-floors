using UnityEngine;
using UnityEngine.AI;
public class NavMeshBaker : MonoBehaviour
{
    //private List<NavMeshSurface> _navMeshSurfaces;
    private GameObject _rooms;
    
    void Start()
    {
        _rooms = GameObject.Find("Level");
        foreach (NavMeshSurface surface in _rooms.GetComponentsInChildren<NavMeshSurface>())
        {
            //_navMeshSurfaces.Add(surface);
            surface.BuildNavMesh();
        }
            
    }

}
