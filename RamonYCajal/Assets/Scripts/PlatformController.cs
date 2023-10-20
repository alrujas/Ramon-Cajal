using UnityEngine;

public class PlatformController : MonoBehaviour
{
    /// <summary>
    /// Define si la plataforma se esta moviendo
    /// </summary>
    public bool isMoving = false;

    /// <summary>
    /// Estado de la plataforma
    /// True - Arriba
    /// False - Abajo
    /// </summary>
    public bool platformState = false;

    /// <summary>
    /// Altura maxima de la plataforma
    /// </summary>
    public float maxY;

    /// <summary>
    /// Altura minima de la plataforma
    /// </summary>
    public float minY;

    /// <summary>
    /// Vector de movimiento de la plataforma
    /// </summary>
    public Vector3 currentMovement = new Vector3(0, 0, 0);

    /// <summary>
    /// Velocidad de movimiento de la plataforma
    /// </summary>
    public float movementSpeed = 0.04f;

    public void FixedUpdate()
    {
        if (isMoving)
        {
            // Comprobamos que no haya llegado a la posicion limite
            if (movementSpeed > 0)
            {
                // Si se mueve hacia arriba que no supere el limite superior
                if (transform.position.y < maxY)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + movementSpeed);
                }
                else
                {
                    // En caso de llegar al limite paramos el movimiento
                    platformState = true;
                    StopMove();
                }
            }
            else
            {
                // Si se mueve hacia abajo que no supere el limite inferior
                if (transform.position.y > minY)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + movementSpeed);
                }
                else
                {
                    // En caso de llegar al limite paramos el movimiento
                    platformState = false;
                    StopMove();
                }
            }
        }
    }

    /// <summary>
    /// Mueve la plataforma hacia el estado contrario
    /// </summary>
    public void Move()
    {
        if (platformState)
        {
            movementSpeed = -0.04f;
        }
        else
        {
            movementSpeed = 0.04f;
        }

        isMoving = true;
    }

    /// <summary>
    /// Para el movimiento de la plataforma
    /// </summary>
    public void StopMove()
    {
        isMoving = false;
    }
}
