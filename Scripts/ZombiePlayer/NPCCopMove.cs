using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCopMove : MonoBehaviour
{
    public Transform target = null;
    public int speed;
    public Rigidbody2D theRgb;
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        theRgb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        NPCMovement();



    }

    public void NPCMovement()
    {
        if (target == null)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            Vector3 lookDirection = target.position - transform.position;
            float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
            theRgb.rotation = lookAngle;
        }
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            target = collision.gameObject.GetComponent<Transform>();

            

        }


    }


    
}
