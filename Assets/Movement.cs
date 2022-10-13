using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb1;
    public Vector2 movement;
    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

    }
    void FixedUpdate()
    {
        rb1.MovePosition(rb1.position + movement * speed * Time.fixedDeltaTime);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        //Check for a match with the specified name on any GameObject that collides with your GameObject
        if (collision.gameObject.tag == "Door")
        {
            SceneManager.LoadScene("Room");
        }
        if (collision.gameObject.tag == "DoorInside")
        {
            SceneManager.LoadScene("Level 1");
        }
        if (collision.gameObject.tag == "CityEntrance")
        {
            SceneManager.LoadScene("Level 2");
        }
    }
}
