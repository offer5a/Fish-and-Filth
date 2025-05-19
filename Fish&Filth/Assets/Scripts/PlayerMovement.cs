using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Joystick movementJoystick;
    public float playerSpeed;
    private Rigidbody2D rigidbody2d;
    public SpriteRenderer _spriteRenderer;
    private bool _isfacingleft;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(movementJoystick.Direction.y != 0)
        {
            rigidbody2d.velocity = new Vector2(movementJoystick.Direction.x * playerSpeed, movementJoystick.Direction.y * playerSpeed);
        }
        else
        {
            rigidbody2d.velocity = Vector2.zero;
        }

        if(_isfacingleft && rigidbody2d.velocity.x > 0)
        {
            FlipFacingDirection();
        }
        else if(!_isfacingleft && rigidbody2d.velocity.x < 0)
        {
            FlipFacingDirection();
        }
    }
    private void FlipFacingDirection()
    {
        _isfacingleft = !_isfacingleft;

        _spriteRenderer.flipX = _isfacingleft;
    }
}
