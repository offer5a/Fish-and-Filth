using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.Direction.y != 0)
        {
            rigidbody.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
        }
    }
}
