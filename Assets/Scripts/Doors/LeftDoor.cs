using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftDoor : MonoBehaviour
{
    public Animator animator1, animator2;
    bool isOpen = false;

    public GameObject Player;
    public GameObject LeftDoorObject;
    public static float distance;

    public AudioSource openDoor;
    public AudioSource closeDoor;
    [Space]
    private Ray ray;
    private float doorCooldown = 1;
    private bool usedDoor = false;
    // Start is called before the first frame update
    void Start()
    {
        animator1 = GetComponent<Animator>();
        usedDoor = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoorOpenCloseLogic();
    }

    [ContextMenu("Open")]
    public void OpenDoor()
    {
        isOpen = true;
        animator1.SetTrigger("open");
        animator2.SetTrigger("open");
    }

    [ContextMenu("Close")]
    public void CloseDoor()
    {
        isOpen = false;
        animator1.SetTrigger("close");
        animator2.SetTrigger("close");
    }

    public void DoorOpenCloseLogic()
	{
		if (usedDoor) doorCooldown -= Time.deltaTime;

        if(doorCooldown < 0)
		{
            doorCooldown = 1;
            usedDoor = false;
		}

        distance = Vector3.Distance(Player.transform.position, LeftDoorObject.transform.position);

        if (distance <= 2.5f)
        {
            if (Input.GetKeyDown(KeyCode.E) && usedDoor == false)
            {
                ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.tag == "door")
                    {
                        usedDoor = true;
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
}
