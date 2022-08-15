using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SentryUp : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int randomGranadeAmount = Random.Range(2, 3);
            FindObjectOfType<ActionOfFire>().SentryUp(randomGranadeAmount);
            Destroy(gameObject);
        }
    }
}
