using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trapp : MonoBehaviour
{
    public int damage;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHelth>().PlayerDano(damage);
        }
        else if(collision.tag == "Zombie")
        {
            collision.gameObject.GetComponent<ZombieHelth>().LoseHealth(damage);
        }
    }
}
