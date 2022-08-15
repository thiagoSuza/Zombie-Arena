
using UnityEngine;

public class Granade : MonoBehaviour
{
   public float speed = 2f;
    public int damage; 
    public Rigidbody2D rgb;
    public GameObject explosionEffect;
    
    
    
    



    void Start()
    {
        var direction = transform.right;
         GetComponent<Rigidbody2D>().AddForce(direction * speed,ForceMode2D.Impulse);
        
       
       
    }
    void Update()
    {
        transform.position += speed * Time.deltaTime * transform.right;
        Explosion();
    }
    public void Explosion()
    {   
        if(speed >= 0)
        {
            speed -= 2f * Time.deltaTime;
        }
        else
        {
            
            speed = 0;
            
            ExplosionPS();            
            Destroy(gameObject);
            
        }      

        
    }

    

    public void OnTriggerExit2D(Collider2D collision)
    {
               
            
            if (collision.tag == "Zombie"  )
            {                
                collision.gameObject.GetComponent<ZombieHelth>().LoseHealth(damage);
                Debug.Log("HIT GRANADE");           
              
                
            }
        
        
    }

    public void ExplosionPS()
    {
        Instantiate(explosionEffect, transform.position, transform.rotation);
    }

}
