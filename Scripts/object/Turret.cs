using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    
    Vector2 direction;
    
    public Transform target = null;
    
    public GameObject gun;
    public Transform muzzle;
    public GameObject bullet;
    public int ammo= 20;
    public Animator anim;
    public Text ammoCount;
    


    public void Update()
    {
        if(target != null)
        {
            Vector2 targetPosition = target.position;
            direction = targetPosition - (Vector2)transform.position;
            gun.transform.up = direction;
            

        }
        DestroyTurret();
        ammoCount.text = ammo.ToString();
    }
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie") && ammo > 0 )
        {
            target = collision.gameObject.GetComponent<Transform>();
            Shoot();
        }
       
    }

    public void Shoot()
    {
        if (ammo > 0)
        {
            StartCoroutine("Brust");
        }
        
    }


    IEnumerator Brust()
    {
        Instantiate(bullet, muzzle.position, muzzle.rotation * Quaternion.Euler(0f, 0f, 90f));
        ammo--;
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, muzzle.position, muzzle.rotation * Quaternion.Euler(0f, 0f, 90f));
        ammo--;
        yield return new WaitForSeconds(0.1f);
        Instantiate(bullet, muzzle.position, muzzle.rotation * Quaternion.Euler(0f, 0f, 90f));
        ammo--;
        yield return new WaitForSeconds(2f);



    }

    public void DestroyTurret()
    {
        if (ammo < 0)
        {
            ammo = 0;
            target = null;
            anim.SetBool("Empty", true);
            Destroy(gameObject, 2);
        }
    }
}
