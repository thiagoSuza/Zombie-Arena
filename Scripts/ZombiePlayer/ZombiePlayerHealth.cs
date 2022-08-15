using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombiePlayerHealth : MonoBehaviour
{
    public static ZombiePlayerHealth Instance;
    public int currentHealth, maxHealth;
    public Image img;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hurt(int damage)
    {
       img.fillAmount -= 1f/20f;
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void LifeUp(int medicine)
    {
        img.fillAmount += 10f / 20f;
        currentHealth += medicine;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
