
using UnityEngine;

public class HelthUp : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        int x = Random.Range(5, 20);

        if (collision.gameObject.CompareTag("Player"))
        {
            FindObjectOfType<PlayerHelth>().HelthUp(x);
            Destroy(gameObject);
        }
    }
}
