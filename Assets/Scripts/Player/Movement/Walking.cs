using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour
{
    [SerializeField] Animator cameraAnimator;
    int isWalkingHash;
    int isRunningHash;
    private CharacterController character_Controller;

    private Vector3 move_Direction;

    [SerializeField]
    float speed = 1.5f;
    private float gravity = 20;

    private float vertical_Velocity;
    bool CanRun = false;

    [SerializeField]
    float runSpeed = 2.5f;

    [SerializeField]
    AudioSource FootStepSound;

    public static bool walkSoundAcces = false;
    // Start is called before the first frame update
    void Start()
    {
        walkSoundAcces = false;
    }

    void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }


    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();

        if (Input.GetKey(KeyCode.LeftShift) && CanRun == true)
        {
            speed = runSpeed;
            cameraAnimator.SetBool("isWalking", false);
            cameraAnimator.SetBool("isRunning", true);
        }
        else
        {
            speed = 2.5f;
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

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            if (Input.GetAxisRaw("Horizontal") == 0)
            {
                speed = 0;
                cameraAnimator.SetBool("isWalking", false);
                cameraAnimator.SetBool("isRunning", false);
            }
        }

        if (speed == 1.5f)
        {
            cameraAnimator.SetBool("isWalking", true);
            cameraAnimator.SetBool("isRunning", false);
        }

        if (speed == 2.5f)
        {
            cameraAnimator.SetBool("isWalking", false);
            cameraAnimator.SetBool("isRunning", true);
        }

        void MoveThePlayer()
        {
            move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
            move_Direction = transform.TransformDirection(move_Direction);
            move_Direction *= speed * Time.deltaTime;
            ApplyGravity();
            character_Controller.Move(move_Direction);

        }

        void ApplyGravity()
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
}