using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public Rigidbody2D rb;
    public GameObject flashlight;

    private GameObject friend1;
    private GameObject friend2;
    private Camera cam;

    float mx;

    private void Start()
    {
        friend1 = GlobalData.instance.friend1.gameObject;
        friend2 = GlobalData.instance.friend2.gameObject;
        cam = GlobalData.instance.cam;
    }

    // Update is called once per frame
    private void Update()
    {
        Physics2D.IgnoreCollision(friend1.GetComponent<Collider2D>(), friend2.GetComponent<Collider2D>());
        mx = Input.GetAxisRaw("Horizontal");

        Vector3 flashlightCenter = cam.WorldToScreenPoint(flashlight.transform.position);
        Vector3 target = Input.mousePosition;
        float angle = Mathf.Atan2(target.y - flashlightCenter.y, target.x - flashlightCenter.x) * Mathf.Rad2Deg;
        flashlight.transform.localEulerAngles = new Vector3(0.0f, 0.0f, angle - 90.0f);
    }

    private void FixedUpdate() 
    {
        Vector2 movement = new Vector2(mx * movementSpeed, rb.velocity.y);
        rb.velocity = movement;
    }
}
