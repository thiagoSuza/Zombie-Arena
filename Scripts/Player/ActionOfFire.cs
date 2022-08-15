using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActionOfFire : MonoBehaviour
{

    public Transform weapon;
    public GameObject projetilPrefab;
    public GameObject granade;
    public GameObject sentury;
    public Rigidbody2D theRg;
    public int numberOfGranades;
    public float shootCounter, timeBtwShoots;
    public float spread;
    public int numberOfSentury;
   







    void Update()
    {
        Shoot();
        
        Throwing();

        DeploySentury();
    }

    public void Shoot()
    {
        if (SceneManager.GetActiveScene().name == "Arena") 
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(projetilPrefab, weapon.position, weapon.rotation);
            }

        }

        if (SceneManager.GetActiveScene().name == "Park")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(projetilPrefab, weapon.position, weapon.rotation);
            }

            if (Input.GetButtonUp("Fire1"))
            {
                Instantiate(projetilPrefab, weapon.position, weapon.rotation);
            }

        }


        if (SceneManager.GetActiveScene().name == "Woods")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                Instantiate(projetilPrefab, weapon.position, weapon.rotation);
                shootCounter = timeBtwShoots;
            }
            shootCounter -= Time.deltaTime;
            if (Input.GetMouseButton(0))
            {
                
                if(shootCounter <= 0)
                {
                    Instantiate(projetilPrefab, weapon.position, weapon.rotation);
                    shootCounter = timeBtwShoots;
                }
               
            }

        }

        if (SceneManager.GetActiveScene().name == "House")
        {
            if (Input.GetButtonDown("Fire1"))
            {
                StartCoroutine("Brust");
                
            }
            

        }


        if (SceneManager.GetActiveScene().name == "Cave")
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
               
                Instantiate(projetilPrefab, weapon.position, weapon.rotation * Quaternion.Euler(0f,0f,12f));
                Instantiate(projetilPrefab, weapon.position, weapon.rotation * Quaternion.Euler(0f,0f,0f));
                Instantiate(projetilPrefab, weapon.position, weapon.rotation * Quaternion.Euler(0f,0f,-12f));
               

            }


        }



    }

    IEnumerator Brust()
    {
        Instantiate(projetilPrefab, weapon.position, weapon.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(projetilPrefab, weapon.position, weapon.rotation);
        yield return new WaitForSeconds(0.1f);
        Instantiate(projetilPrefab, weapon.position, weapon.rotation);
        
        
    }

    public void Throwing()
    {
          
            if (Input.GetKeyDown(KeyCode.G))
            {
               if (numberOfGranades > 0)
               {
                Instantiate(granade, weapon.position, weapon.rotation);
                numberOfGranades--;
               }
            }
       
        
       
    }

    public void GranadeUp(int moreGranade)
    {
        numberOfGranades += moreGranade;
    }

    public void SentryUp(int moreSentury)
    {
        numberOfSentury += moreSentury;
    }

    public void DeploySentury()
    {
        if (Input.GetKeyDown(KeyCode.F) && numberOfSentury > 0)
        {
            
            Instantiate(sentury,transform.position, transform.rotation);
            numberOfSentury--;
        }
    }
}
