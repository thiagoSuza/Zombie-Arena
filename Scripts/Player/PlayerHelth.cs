using UnityEngine;
using UnityEngine.UI;

public class PlayerHelth : MonoBehaviour
{
    public static PlayerHelth instance;
    public int maxLife,currentLife;
    public Slider lifeSlider;

    
    void Start()
    {
        currentLife = maxLife;
        lifeSlider.maxValue = maxLife;
        lifeSlider.value = currentLife;
        instance = this;
    }

    public void HelthUp(int medicine)
    {
        currentLife += medicine;
        lifeSlider.value = currentLife;
        if (currentLife > maxLife)
        {
            currentLife = maxLife;
        }
    }

    


    public void PlayerDano(int zombieDano)
    {
        currentLife  -=  zombieDano ;
        lifeSlider.value = currentLife;

        if (currentLife <= 0)
        {
            FindObjectOfType<GameManager>().playerAlived = false;
            Destroy(gameObject);
        }
    }
}
