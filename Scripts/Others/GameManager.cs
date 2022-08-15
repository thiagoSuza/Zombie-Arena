using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool playerAlived;
    // Start is called before the first frame update
    void Start()
    {
        playerAlived = true;
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
