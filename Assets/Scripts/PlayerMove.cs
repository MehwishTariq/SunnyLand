using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    public static bool isGrounded = true;
    float speed = 5.0f;
    float jumpSpeed = 6.0f;

    public Transform cam;
    SpriteRenderer player;
    Animator anim;

      
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        cam.transform.position = new Vector3(transform.position.x - 2f, transform.position.y + 1f, -1);

        anim.SetBool("Jump", false);
        anim.SetBool("Run", false);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(speed * -transform.right * Time.deltaTime);
            player.flipX = true;
            anim.SetBool("Run", true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(jumpSpeed * transform.up * Time.deltaTime);            
            anim.SetBool("Jump", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * transform.right * Time.deltaTime);
            player.flipX = false;
            anim.SetBool("Run", true);
        }        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
