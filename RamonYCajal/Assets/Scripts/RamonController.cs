using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamonController : MonoBehaviour
{
public float MovementSpeed = 1;

    public float JumpForce = 1;

    private bool _onFloor;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Horizontal movement
         if (Input.GetKey(KeyCode.LeftArrow))

         {
             _rigidbody.velocity = new Vector2(-MovementSpeed, _rigidbody.velocity.y);
         }
         if (Input.GetKey(KeyCode.RightArrow))

         {
             _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
         }
        _animator.SetFloat("Horizontal", Mathf.Abs(_rigidbody.velocity.x)); //Sets the state of run in the animator
     
        //Vertical movement
        /*_onFloor = _rigidbody.velocity.y == 0;//Checks if the player is on the floor
        if (Input.GetKeyDown(KeyCode.W) && _onFloor)

        {

            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        }
        _animator.SetBool("OnFloor", _onFloor);//sets the jump state in the animator*/

        //Flips the character to face the movement direction
        if (_rigidbody.velocity.x >0.1)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }
        if (_rigidbody.velocity.x < -0.1)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }

        /* if (Input.GetKey(KeyCode.A))
         {
             _rigidbody.AddForce(new Vector2(-MovementSpeed,0)*Time.deltaTime);
         }
         if (Input.GetKey(KeyCode.D))

         {
             _rigidbody.AddForce(new Vector2(MovementSpeed, 0) * Time.deltaTime);
         }*/
    }
}
