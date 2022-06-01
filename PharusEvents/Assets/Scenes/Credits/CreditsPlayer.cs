using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsPlayer : MonoBehaviour
{
    PlayerInputActions inputActions;

    public float speed;
    public Rigidbody rb;
    Vector2 inputs;
    void Awake()
    {
        inputActions = new PlayerInputActions();
    }

    void OnEnable()
    {
        inputActions.Enable();
    }



    public void FixedUpdate()
    {
        inputs = inputActions.Player.Movements.ReadValue<Vector2>();

        Vector3 direction = Vector3.forward * inputs.y + Vector3.right * inputs.x;
        rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
}