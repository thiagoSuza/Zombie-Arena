using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    public static ZombieMovement instance;
    public float minSpeed, maxSpeed, currentSpeed;
    public int zombieBit;
    private Rigidbody2D theRgb;
    private Transform playerPosition;



    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        currentSpeed = Random.Range(minSpeed, maxSpeed);
        theRgb = GetComponent<Rigidbody2D>();
        playerPosition = FindObjectOfType<PlayerMove>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        ZombieMove();
    }


    public void ZombieMove()
    {
        if(FindObjectOfType<GameManager>().playerAlived == true)
        {
            transform.position =  Vector2.MoveTowards(transform.position, playerPosition.position, currentSpeed * Time.deltaTime);
            Vector3 lookDirection = playerPosition.position - transform.position;
            float lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x)* Mathf.Rad2Deg;
            theRgb.rotation = lookAngle;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHelth>().PlayerDano(zombieBit);
        }
    }
}
