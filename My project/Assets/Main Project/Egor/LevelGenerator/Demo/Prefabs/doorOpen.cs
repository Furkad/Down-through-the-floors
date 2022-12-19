using System.Collections;
using System.Threading.Tasks;
using Unity.FPS.Gameplay;
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
            Pressed();
        }
    }

    IEnumerator WaitPressed(NavMeshBaker baker, LevelCounter counter)
    {
        baker.Bake(counter.counter);
        yield return new WaitForEndOfFrame();
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
            LevelCounter levelCounter = FindObjectOfType<LevelCounter>();
            NavMeshBaker baker = FindObjectOfType<NavMeshBaker>();
            WaitPressed(baker, levelCounter);
        }

        
    }
}
