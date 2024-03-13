using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRB : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float flySpeed = 10f;
    public float rotationSpeed = 5f;

    private Rigidbody rb;
    private Vector3 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get movement input
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        moveInput = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized;

        // Handle flying up and down
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * (flySpeed * Time.deltaTime), ForceMode.VelocityChange);
        }
        else if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl))
        {
            rb.AddForce(Vector3.down * (flySpeed * Time.deltaTime), ForceMode.VelocityChange);
        }
    }

    void FixedUpdate()
    {
        Move();
        Rotate();
    }

    void Move()
    {
        // Apply movement force
        Vector3 movement = moveInput * (moveSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);
    }

    void Rotate()
    {
        // Rotate towards movement direction
        if (moveInput != Vector3.zero)
        {
            Quaternion newRotation = Quaternion.LookRotation(moveInput);
            rb.MoveRotation(Quaternion.Slerp(rb.rotation, newRotation, rotationSpeed * Time.fixedDeltaTime));
        }
    }
}
