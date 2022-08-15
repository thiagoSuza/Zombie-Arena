using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieBullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage;

    private void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            
            collision.gameObject.GetComponent<PlayerHelth>().PlayerDano(damage);
            Destroy(gameObject);
        }
            

    }
}
