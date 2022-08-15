using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] ZumbieNormal;
    public Transform[] spawnPoint;
    public GameObject[] outbreakZ;
    public Transform[] spawnOutbreak;

    public float currentTime, timeBtwSpawns;

    

    // Update is called once per frame
    void Update()
    {
        if(FindObjectOfType<GameManager>().playerAlived == true)
        {
            currentTime -= Time.deltaTime;
            if(currentTime <= 0)
            {
                SpawnAction();
            }
            if(DigitalCountdown.instance.outbreakactive == true)
            {
                Spawnoutbreak();
            }
        }
    }

    public void Spawnoutbreak()
    {
        for(int i = 0; i < 3; i++)
        {
            int randomPoint = Random.Range(0, spawnPoint.Length);
            int randomZombie = Random.Range(0, outbreakZ.Length);
            Instantiate(outbreakZ[randomZombie], spawnPoint[randomPoint].position, spawnPoint[randomPoint].rotation);
        }
                
        DigitalCountdown.instance.outbreakactive = false;

    }



    


    public void SpawnAction()
    {
        int randomPoint = Random.Range(0, spawnPoint.Length);
        int randomZombie = Random.Range(0, ZumbieNormal.Length);
        Instantiate(ZumbieNormal[randomZombie], spawnPoint[randomPoint].position,spawnPoint[randomPoint].rotation);
        currentTime = timeBtwSpawns;
    }
}
