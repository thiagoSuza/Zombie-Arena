using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMiniGame : MonoBehaviour
{
    public GameObject[] police;
    public Transform[] policeSpawn;
    public Transform[] zombiesSpawn;
    public GameObject[] zombies;
    public float  pcount, pready;
    public int zombieToRespawn;
    public static SpawnMiniGame instance;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
        pready = pcount;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnController();
    }


    public void SpawnController()
    {
        
        //ZOMBIE
        while(zombieToRespawn > 0)
        {
            int zrandomposition = Random.Range(0, zombiesSpawn.Length);
            int zrandom = Random.Range(0, zombies.Length);
            Instantiate(zombies[zrandom],zombiesSpawn[zrandomposition].position, Quaternion.identity);
            zombieToRespawn--;
        }

        pcount -= Time.deltaTime;
        //POLICE
        if(pcount <= 0)
        {
            int prandomposition = Random.Range(0,policeSpawn.Length);
            int prandom = Random.Range(0,police.Length);
            Instantiate(police[prandom],policeSpawn[prandomposition].position, Quaternion.identity);
            pcount= 2f;
        }
    }

   



}
