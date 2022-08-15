using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBit : MonoBehaviour
{
    public int damage,bomerAmount;
    public Animator anim;
    public Transform bomerPoint;
    public GameObject bomer;
    

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    // Update is called once per frame
    void Update()
    {
        ATK();
        SpawnBomer();
    }

    public void ATK()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("ATK", true);
            damage = 10;
        }
        else
        {
            anim.SetBool("ATK", false);
            damage = 0;
        }
    }

    public void SpawnBomer()
    {
        
        if(Input.GetKeyDown(KeyCode.F) && bomerAmount > 0)
        {
            bomerAmount--;
            Instantiate(bomer,bomerPoint.position,bomerPoint.rotation);
        }
    }


   

    public void OnCollisionStay2D(Collision2D other)
    {
             if(other.gameObject.tag == "Zombie")
             {
                 other.gameObject.GetComponent<NPCCopHealth>().LosseCopHealth(damage);
             }
           
        
    }
}
