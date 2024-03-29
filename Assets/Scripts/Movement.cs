using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using TMPro;


public class Movement : MonoBehaviour
{

    public float speed;
    public Rigidbody2D rb1;
    private Vector2 movement;
    public Animator animator;
    public GameObject player;
    private Vector2 currentPos;
    public BattleMenu battleMenu;
    
    

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    private void Start()
    {
        currentPos.x = -1.4f;
        currentPos.y = 2.5f;
    }

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
        if (collision.gameObject.tag == "HouseDoor")
        {
            currentPos.x = player.transform.position.x;
            currentPos.y = player.transform.position.y -1;
            SceneManager.LoadScene("Room");
            player.transform.position = new Vector2(0, -3);
        }
        if (collision.gameObject.tag == "DoorInside")
        {
            SceneManager.LoadScene("Level 1");
            player.transform.position = currentPos;
        }
        if (collision.gameObject.tag == "CityEntrance" && battleMenu.keysCounter == 3)
        {
            currentPos.x = player.transform.position.x - 1;
            currentPos.y = player.transform.position.y;
            SceneManager.LoadScene("Level 2");
            player.transform.position = new Vector2(-30, 16);
        }
        if (collision.gameObject.tag == "cityEntranceReturning")
        {
            SceneManager.LoadScene("Level 1");
            player.transform.position = currentPos;
        }
        if (collision.gameObject.tag == "SchoolEntrance")
        {
            currentPos.x = player.transform.position.x;
            currentPos.y = player.transform.position.y - 1;
            SceneManager.LoadScene("Classroom");
            player.transform.position = new Vector2(-4f, -1.7f);
        }
        if (collision.gameObject.tag == "ClassroomDoorInside")
        {
            SceneManager.LoadScene("Level 2");
            player.transform.position = currentPos;
        }
    }
}
