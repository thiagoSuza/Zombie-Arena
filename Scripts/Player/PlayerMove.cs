using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float PlayerSpeed;
    public Rigidbody2D theRgb;
    private Vector2 playerMovement;
    private Vector2 mousePosition;
    public Camera gameCamera;

    
  
    void Update()
    {
         Move();
        MousePosition();
    }

    void FixedUpdate()
    {
        theRgb.MovePosition(theRgb.position+ playerMovement.normalized * PlayerSpeed * Time.deltaTime);
        Vector2 lookDirection = mousePosition - theRgb.position;
        float playerAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        theRgb.rotation = playerAngle;
    }


    void Move()
    {
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");
    }

    void MousePosition()
    {
        mousePosition = gameCamera.ScreenToWorldPoint(Input.mousePosition);
    }


}
