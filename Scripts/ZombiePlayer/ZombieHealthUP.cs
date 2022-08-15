using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealthUP : MonoBehaviour
{
    public int healthup;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<ZombiePlayerHealth>().LifeUp(healthup);
            Destroy(gameObject);
        }
    }
}
