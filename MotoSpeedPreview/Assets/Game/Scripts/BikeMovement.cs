using UnityEngine;

public class BikeMovement : MonoBehaviour
{
    [SerializeField] Rigidbody2D frontWheelRb;
    [SerializeField] Rigidbody2D backWheelRb;
    [SerializeField] float speed;
    [SerializeField] int theNumberOfPartsOnWhichTheScreenIsDivided;

    int inFrontOfDirectionNumber = -1;
    int backDirectionNumder = 1;
    void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            TrafficConditions(touch);
        }
    }
    void TrafficConditions(Touch touch)
    {
        if (touch.position.x < HalfOfScreen())
        {
            Direction(backDirectionNumder);
        }
        else if (touch.position.x > HalfOfScreen())
        {
            Direction(inFrontOfDirectionNumber);
        }
    }
    void Direction(int directionOfMovement)
    {
        backWheelRb.AddTorque(directionOfMovement * speed * Time.fixedDeltaTime);
    }

    float HalfOfScreen()
    {
        return Screen.width / theNumberOfPartsOnWhichTheScreenIsDivided;
    }
}
