using UnityEngine;

public class DamageAndSpeedOfBullet : MonoBehaviour
{
    public float speed= 10f;
    public int damage;
    public Rigidbody2D theRb2D;
    public GameObject impactEffect, zumbieEffect;
    
    void Update()
    {
       // theRb2D.velocity = transform.right* speed;
       transform.Translate(Vector2.right * speed * Time.deltaTime);
    }


    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie"))
        {
            Instantiate(zumbieEffect,transform.position,transform.rotation);   
            collision.gameObject.GetComponent<ZombieHelth>().LoseHealth(damage);
            Destroy(gameObject);
        }
        else
        {
            Instantiate(impactEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        
    }

}
