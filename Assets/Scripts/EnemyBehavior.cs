using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{

    Animator death;
    
    private void Start()
    {
        death = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {        
        if (other.tag == "Player")
        {
            
            if (other.gameObject.transform.position.y <= gameObject.transform.position.y +3f && !PlayerMove.isGrounded)
            {
                death.SetBool("Die", true);
                Destroy(gameObject,1f);
            }

            if ((other.gameObject.transform.position.x <= gameObject.transform.position.x + 2f ||
                other.gameObject.transform.position.x >= gameObject.transform.position.x + 2f) &&
              //  other.gameObject.transform.position.y <= gameObject.transform.position.y + 2 &&
                PlayerMove.isGrounded)
            {               
                other.gameObject.GetComponent<Animator>().SetBool("Die", true);
                Destroy(other.gameObject, 1.5f);
            }
           
        }
    }
}
