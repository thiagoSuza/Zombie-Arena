using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMove : MonoBehaviour
{
    public Transform target = null;
    public int speed;
    public Rigidbody2D theRgb;
    public int damage;
    public SpriteRenderer spriteRenderer;

    
    void Start()
    {
        theRgb = GetComponent<Rigidbody2D>();
        
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    
    void Update()
    {
        NPCMovement();
        
    }
    

    public void NPCMovement()
    {
        if(target == null)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
           
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            Vector3 lookDirection = target.transform.position - transform.position;
            float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            theRgb.rotation = lookAngle;
            spriteRenderer.flipX = false;
            
        }
    }

    

    

    public void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Zombie") )
        {
            target = collision.gameObject.GetComponent<Transform>();
            
            
        }

        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
       if(collision.gameObject.CompareTag("Zombie"))
        {
            collision.gameObject.GetComponent<NPCCopHealth>().LosseCopHealth(damage);
        }
    }
}
