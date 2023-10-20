using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajalController : MonoBehaviour
{
    public float _groundedRadius;
    public float MovementSpeed = 1;

    public float JumpForce = 1;

    private bool _onFloor;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField]
    private LayerMask groundLayer;

    public GameObject mainLever;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Horizontal movement
         if (Input.GetKey(KeyCode.A))

         {
             _rigidbody.velocity = new Vector2(-MovementSpeed, _rigidbody.velocity.y);
         }
         if (Input.GetKey(KeyCode.D))

         {
             _rigidbody.velocity = new Vector2(MovementSpeed, _rigidbody.velocity.y);
         }
        _animator.SetFloat("Horizontal", Mathf.Abs(_rigidbody.velocity.x)); //Sets the state of run in the animator
     
        //Vertical movement
        _onFloor =  Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y-0.5f), _groundedRadius, groundLayer);//Checks if the player is on the floor
        if (Input.GetKeyDown(KeyCode.W) && _onFloor)

        {

            _rigidbody.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);

        }
        _animator.SetBool("OnFloor", _onFloor);//sets the jump state in the animator

        //Flips the character to face the movement direction
        if (_rigidbody.velocity.x > 0.1)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
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
         
        // Control de la palanca
        if (Input.GetKeyDown(KeyCode.E))
        {
            LeverController leverController = mainLever.GetComponent<LeverController>();
            GameObject closestLever = leverController.ClosestLever();
            if (closestLever != null){
                closestLever.GetComponent<LeverController>().ActuateLever();
            }
        }
    }
}
