using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightDoor : MonoBehaviour
{
    public Animator animator;
    bool isOpen = false;

    public GameObject Player;
    public GameObject RightDoorObject;
    public float distance;

    public AudioSource openDoor;
    public AudioSource closeDoor;
    [Space]
    private Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(Player.transform.position, RightDoorObject.transform.position);

        if (distance <= 2.5f)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.tag == "door2")
                    {
                        if (isOpen)
                        {
                            CloseDoor();
                            closeDoor.Play();
                        }
                        else
                        {
                            OpenDoor();
                            openDoor.Play();
                        }
                    }
                }
            }
        }
    }

    [ContextMenu("Open")]
    public void OpenDoor()
    {
        isOpen = true;
        animator.SetTrigger("open");
    }

    [ContextMenu("Close")]
    public void CloseDoor()
    {
        isOpen = false;
        animator.SetTrigger("close");
    }
}
