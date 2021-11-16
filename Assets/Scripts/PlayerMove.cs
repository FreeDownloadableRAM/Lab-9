using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    private float moveSpeed, jumpForce;
    private float dirX, dirZ;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 10f;        
        jumpForce = 10f;
        rb = GetComponent<Rigidbody>();     
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirZ = Input.GetAxis("Vertical") * moveSpeed;

        if (Input.GetKeyDown("space")){
            rb.velocity = new Vector3(dirX, jumpForce, dirZ);  
        }
    }

    private void FixedUpdate() {
        rb.velocity = new Vector3(dirX, rb.velocity.y, dirZ);
    }
}
