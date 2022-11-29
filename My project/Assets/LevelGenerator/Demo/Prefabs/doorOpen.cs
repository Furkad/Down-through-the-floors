using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            Pressed();
            Debug.Log("You Press F");
        }
    }

    void Pressed()
    {
        RaycastHit doorhit;

        if (Physics.Raycast(PlayerCamera.transform.position, PlayerCamera.transform.forward, out doorhit, MaxDistance))
        {
            if (doorhit.transform.tag == "door")
            {
                anim = doorhit.transform.GetComponentInParent<Animator>();
                opened = !opened;
                anim.SetBool("Opened", !opened);
            }
        }
    }
}
