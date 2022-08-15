using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCCopHealth : MonoBehaviour
{
    public int health;
    public GameObject greenHearth;
    public static NPCCopHealth instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LosseCopHealth(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            int randomDrop = Random.Range(0, 10);
            if(randomDrop <= 3)
            {
                Instantiate(greenHearth,transform.position,Quaternion.identity);
            }
            SpawnMiniGame.instance.zombieToRespawn++;
            Destroy(gameObject);
        }
    }
}
