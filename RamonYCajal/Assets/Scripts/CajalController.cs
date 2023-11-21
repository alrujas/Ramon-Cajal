using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajalController : MonoBehaviour
{
    [SerializeField] private float _groundedRadius;
    [SerializeField] private float MovementSpeed = 1;

    [SerializeField] private float JumpForce = 1;

    private bool _onFloor;

    private Rigidbody2D _rigidbody;
    private Animator _animator;

    [SerializeField]
    private LayerMask groundLayer;

    [SerializeField]
    private LayerMask objectLayer;

    public GameObject mainLever;

    // Nueva referencia para el Rigidbody2D de Ramon
    private Rigidbody2D ramonRigidbody;

    // Nueva variable para la fuerza de impulso
    public float _fuerzaImpulso = 10f;

    /// <summary>
    /// Gamemanager Object
    /// </summary>
    private GameManager _gm;

    [SerializeField] private AudioSource _JumpSound;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _gm = GameManager.Instance;

        // Busca el Rigidbody2D en el objeto Ramon
        ramonRigidbody = _gm.GetRamon().GetComponent<Rigidbody2D>();

        StartCoroutine(DeathCheck());
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
            _JumpSound.Play();

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
        // Aplica una fuerza hacia arriba en el personaje Cajal si está encima de Ramon y se pulsa la tecla de espacio
        if (Input.GetKeyDown(KeyCode.UpArrow) && CanApplyForceToRamon())
        {
            _rigidbody.AddForce(Vector2.up * _fuerzaImpulso, ForceMode2D.Impulse);
            _JumpSound.Play();
        }
    }

    /// <summary>
    /// Funcion para detectar si cae un objeto sobre Cajal
    /// </summary>
    /// <returns></returns>
    public IEnumerator DeathCheck()
    {
        // Solo puede morir si estando en el suelo le cae un objeto encima
        if (_onFloor)
        {
            bool deathCheck = Physics2D.OverlapCircle(new Vector2(transform.position.x, transform.position.y + 0.4f), _groundedRadius, objectLayer);
            if (deathCheck)
            {
                _gm.CajalDeath();
            }
        }

        // Esperamos cierto tiempo para volver a realizar el check
        yield return new WaitForSeconds(0.4f);

        StartCoroutine(DeathCheck());
    }
    // Función para verificar si Cajal está encima de Ramon
    private bool IsCajalAboveRamon()
    {
        // posición de Cajal y Ramon en el eje Y
        float cajalY = transform.position.y;
        float ramonY = ramonRigidbody.transform.position.y;

        // Verifica si Cajal está por encima de Ramon con un pequeño margen
        return cajalY > ramonY;
    }

    // Función para verificar si Cajal está tocando a Ramon
    private bool IsCajalTouchingRamon()
    {
        Collider2D cajalCollider = GetComponent<Collider2D>();
        Collider2D ramonCollider = ramonRigidbody.GetComponent<Collider2D>();

        // Verifica si los colliders de Cajal y Ramon se están tocando
        return cajalCollider.IsTouching(ramonCollider);
    }

    // Nueva función que combina ambas comprobaciones
    private bool CanApplyForceToRamon()
    {
        return IsCajalAboveRamon() && IsCajalTouchingRamon();
    }
}
