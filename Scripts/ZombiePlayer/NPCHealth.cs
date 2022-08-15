using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCHealth : MonoBehaviour
{
    public static NPCHealth instance;
    public int health;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
       
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LosseHealth(int damage)
    {
        health -= damage;
        
        if(health < 0)
        {
            Destroy(gameObject);
        }
    }
}
