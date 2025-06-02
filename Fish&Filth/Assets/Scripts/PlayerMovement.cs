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
    private bool _isfacingup;
    [SerializeField] private Animator _animator;

    private bool _isonwater;


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
            //_animator.SetBool("ismovingside", true);
        }
        else if(!_isfacingleft && rigidbody2d.velocity.x < 0)
        {
            FlipFacingDirection();
           // _animator.SetBool("ismovingside", true);
        }
        // these are two different entries that refer to two different flipping directions.
        if (_isfacingup && rigidbody2d.velocity.y > 0)
        {
            flipfacingdirection();
            _animator.SetBool("ismovingbackward", true);
            _animator.SetBool("ismovingforward", false);

        }
        else if (!_isfacingup && rigidbody2d.velocity.y < 0)
        {
            //flipfacingdirection();
            _animator.SetBool("ismovingforward", true);
            _animator.SetBool("ismovingbackward", false);

        }
        if (!_isfacingup && rigidbody2d.velocity.y > 0)
        {
            _animator.SetBool("ismovingforward", false);
            _animator.SetBool("ismovingbackward", true);

        }
        if(!_isfacingup && rigidbody2d.velocity.y == 0)
        {
            _animator.Play("idle");
        }



    }
    private void FlipFacingDirection()
    {
        _isfacingleft = !_isfacingleft;

        _spriteRenderer.flipX = _isfacingleft;

       
    }

    private void flipfacingdirection()
    {
        _isfacingup = !_isfacingup;

        _spriteRenderer.flipY = _isfacingup;

    }

}
