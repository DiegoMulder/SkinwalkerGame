using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] Animator cameraAnimator;
    private CharacterController character_Controller;

    private Vector3 move_Direction;

    private float speed = 3f;
    [SerializeField] private float walkingSpeed;
    private float gravity = 20;

    private float vertical_Velocity;
    private bool CanRun = false;

    [SerializeField] private float runSpeed = 6f;

    [SerializeField]
    AudioSource FootStepSound;

    public static bool walkSoundAcces = false;
    // Start is called before the first frame update
    void Start()
    {
        walkSoundAcces = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
        WalkingLogic();
    }

    public void WalkingLogic()
	{
        if (Input.GetKey(KeyCode.LeftShift) && CanRun == true)
        {
            speed = runSpeed;
            cameraAnimator.SetBool("isWalking", false);
            cameraAnimator.SetBool("isRunning", true);
        }
        else
        {
            speed = walkingSpeed;
        }

        if (Input.GetKey(KeyCode.W))
        {
            CanRun = true;
        }
        else
        {
            CanRun = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            CanRun = false;
        }

        if (Input.GetKey(KeyCode.S))
        {
            CanRun = false;
        }

        if (Input.GetKey(KeyCode.D))
        {
            CanRun = false;
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                speed = 0;
                cameraAnimator.SetBool("isWalking", false);
                cameraAnimator.SetBool("isRunning", false);
            }
        }

        if (speed > 1 && speed < 6)
        {
            cameraAnimator.SetBool("isWalking", true);
            cameraAnimator.SetBool("isRunning", false);
        }

        if (speed >= 6)
        {
            cameraAnimator.SetBool("isWalking", false);
            cameraAnimator.SetBool("isRunning", true);
        }

        if (walkSoundAcces == true)
        {
            if (character_Controller.isGrounded && character_Controller.velocity.magnitude > 1f && FootStepSound.isPlaying == false)
            {
                FootStepSound.Play();
            }

            else if (character_Controller.isGrounded && character_Controller.velocity.magnitude < 1f)
            {
                FootStepSound.Stop();
            }
        }
        else
        {
            FootStepSound.Stop();
        }
    }

    public void MoveThePlayer()
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        move_Direction = transform.TransformDirection(move_Direction);
        move_Direction *= speed * Time.deltaTime;
        ApplyGravity();
        character_Controller.Move(move_Direction);
    }

    public void ApplyGravity()
    {
        if (character_Controller.isGrounded)
        {
            vertical_Velocity -= gravity * Time.deltaTime;
        }
        else
        {
            vertical_Velocity -= gravity * Time.deltaTime;
        }
        move_Direction.y = vertical_Velocity * Time.deltaTime;
    }
}