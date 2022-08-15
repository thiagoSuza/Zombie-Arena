using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadeUP : MonoBehaviour
{
    
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            int randomGranadeAmount = Random.Range(2, 5);
            FindObjectOfType<ActionOfFire>().GranadeUp(randomGranadeAmount);
            Destroy(gameObject);
        }
    }
}
