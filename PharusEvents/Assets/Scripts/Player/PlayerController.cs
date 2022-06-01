using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    PlayerInputActions inputActions;
    Rigidbody rb;
    PhotonView pv;
    [SerializeField] GameObject cameraHolder;
    Joystick joystick;
    

    [SerializeField] float mouseSensitivity, sprintSpeed, walkSpeed, jumpForce, smoothTime;
    float verticalLookRotation;
    bool isGrounded;
    Vector3 smoothMoveVelocity;
    Vector3 moveAmount;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        pv = GetComponent<PhotonView>();
        inputActions = new PlayerInputActions();
        joystick = FindObjectOfType<FixedJoystick>();
        
    }

    void OnEnable()
    {
        inputActions.Enable();
    }

    void OnDisable()
    {
        inputActions.Disable();
    }

    void Start()
    {
        if(!pv.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
            Destroy(rb);
        }
    }

    void Update()
    {
        if(!pv.IsMine)
        {
            return;
        }

        //Look();
        Move();
        //Jump();
    }

    void FixedUpdate()
    {
        if(!pv.IsMine)
        {
            return;
        }
        
        rb.MovePosition(rb.position + transform.TransformDirection(moveAmount) * Time.fixedDeltaTime);
    }
        
    void Look()
    {
        transform.Rotate(Vector3.up * Input.GetAxisRaw("Mouse X") * mouseSensitivity);

        verticalLookRotation += Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90f, 90f);

        cameraHolder.transform.localEulerAngles = Vector3.left * verticalLookRotation;
    }

    void Move()
    {
        Vector2 inputs = inputActions.Player.Movements.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(inputs.x, 0, inputs.y).normalized;

        moveAmount = Vector3.SmoothDamp(moveAmount, moveDir *  sprintSpeed, ref smoothMoveVelocity, smoothTime);
    }

    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * jumpForce);
        }
    }

    public void SetGroundedState(bool _grounded)
    {
        isGrounded = _grounded;
    }
    
}
