using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class doorOpen : MonoBehaviour
{
    public Transform PlayerCamera;
    [Header("MaxDistance you can open or close the door.")]
    public float MaxDistance = 5;

    private bool opened = false;
    private Animator anim;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("You Press F");
            WaitPressed();
        }
    }

    async void WaitPressed()
    {
        Pressed();
        GameObject _rooms = GameObject.Find("Level");
        foreach (NavMeshSurface surface in _rooms.GetComponentsInChildren<NavMeshSurface>())
        {
            await Task.Run(() => surface.BuildNavMesh());
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.tag == "door")
            {
                anim = doorhit.transform.GetComponent<Animator>();
                opened = !opened;
                if (opened)
                    anim.SetTrigger("Opened");
                else
                    anim.SetTrigger("Closed");

            }
        }

        
    }
}
