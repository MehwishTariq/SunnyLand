using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    float speed = 2.0f;
    float originalPos;
    SpriteRenderer enemySprite;
    bool turn = true;

    // Start is called before the first frame update
    void Start()
    {
        originalPos = transform.position.x;
        enemySprite = GetComponent<SpriteRenderer>();        
    }

    // Update is called once per frame
    void Update()
    {
       
        if (transform.position.x <= originalPos && !turn)
        {
            turn = true;
            enemySprite.flipX = true;
        }

        if (transform.position.x < originalPos + 5.0f && turn)
        {
            transform.Translate(transform.right * speed * Time.deltaTime);
            
        }

        if(transform.position.x >= originalPos + 5.0f && turn)
        {
            turn = false;
            enemySprite.flipX = false;
        }

        if (!turn)
        {
            transform.Translate(-transform.right * speed * Time.deltaTime);            
        }
    }
}
