using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;

    public GameObject friend1;
    public GameObject friend2;

    float mx;

    // Update is called once per frame
    private void Update()
    {
        Physics2D.IgnoreCollision(friend1.GetComponent<Collider2D>(), friend2.GetComponent<Collider2D>());
        mx = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate() 
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
}
