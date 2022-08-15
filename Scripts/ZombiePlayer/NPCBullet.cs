using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCBullet : MonoBehaviour
{
    public int damage;
    public int speed;
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
        if (collision.gameObject.CompareTag("NPC"))
        {

            collision.gameObject.GetComponent<NPCHealth>().LosseHealth(damage);
            Destroy(gameObject);
        }else if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ZombiePlayerHealth>().Hurt(damage);
        }


    }
}
