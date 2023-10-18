using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    public float movementSpeed = 10.0f;
    public float jumpForce = 10.0f;
    public int maxJumps = 2;
    private Rigidbody rb;
    public int jumpCount = 0;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float horizontalInput = 0.0f;
        float verticalInput = 0.0f;
        float jump = 0.0f;

        // Movement
        if (Input.GetKey(KeyCode.W))
        {
            horizontalInput = 1.0f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            horizontalInput = -1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            verticalInput = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            verticalInput = 1.0f;
        }

        // Jump
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpCount < maxJumps && canJump)
            {
                jump = 1.0f;
                jumpCount++;
                canJump = false;
            }
        }
        // Reset Jump
        if (!Input.GetKey(KeyCode.Space))
        {
            canJump = true;
        }
        // planar movement
        rb.AddForce(new Vector3(verticalInput, 0, horizontalInput) * movementSpeed * Time.fixedDeltaTime);
        // jump
        rb.AddForce(new Vector3(0, jump * jumpForce, 0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // reset jump counts when colliding
        jumpCount = 0;
    }
}
