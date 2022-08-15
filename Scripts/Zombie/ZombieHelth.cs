using UnityEngine;

public class ZombieHelth : MonoBehaviour
{
    public int zombieLife;
    public GameObject hearth;


    public void LoseHealth(int weaponDano)
    {
        zombieLife =  zombieLife - weaponDano;
        if(zombieLife < 0)
        {
            int x = Random.Range(0, 10);
            if (x < 3)
            {
                Instantiate(hearth,transform.transform.position, Quaternion.identity);
            }
            FindObjectOfType<UIManager>().zumbiesKilled++;
            Destroy(gameObject);
        }
    }
}
