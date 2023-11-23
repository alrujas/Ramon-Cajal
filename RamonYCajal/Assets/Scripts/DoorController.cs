using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour
{
    /// <summary>
    /// Define si la puerta esta moviendose
    /// </summary>
    public bool isMoving = false;

    /// <summary>
    /// Define si la puerta se encuentra arriba o abajo
    /// True - Arriba
    /// False - Abajo
    /// </summary>
    public bool doorState = false;

    /// <summary>
    /// Velocidad de movimiento de la puerta
    /// </summary>
    public float movementSpeed;

    /// <summary>
    /// Velocidad actual de la plataforma
    /// </summary>
    private float currentSpeed;

    /// <summary>
    /// Altura maxima de la plataforma
    /// </summary>
    public float maxY;

    /// <summary>
    /// Altura minima de la plataforma
    /// </summary>
    public float minY;

    /// <summary>
    /// Pasado este tiempo se inicia el cierre de la puerta
    /// </summary>
    public int timeToClose;

    public bool _closes = true;
    public void FixedUpdate()
    {
        if (isMoving)
        {
            // Comprobamos que no haya llegado a la posicion limite
            if (currentSpeed > 0)
            {
                // Si se mueve hacia arriba que no supere el limite superior
                if (transform.position.y < maxY)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + currentSpeed * Time.deltaTime);
                }
                else
                {
                    // En caso de llegar al limite paramos el movimiento
                    doorState = true;
                    isMoving = false;
                    if (_closes)
                    {
                        StartCoroutine(Close());
                    }
                }
            }
            else
            {
                // Si se mueve hacia abajo que no supere el limite inferior
                if (transform.position.y > minY)
                {
                    transform.position = new Vector2(transform.position.x, transform.position.y + currentSpeed * Time.deltaTime);
                }
                else
                {
                    // En caso de llegar al limite paramos el movimiento
                    doorState = false;
                    isMoving = false;
                }
            }
        }
    }

    /// <summary>
    /// Funcion para abrir la puerta
    /// </summary>
    public void Open(){
        if (!doorState){
            currentSpeed = movementSpeed;
            isMoving = true;
        }
    }

    /// <summary>
    /// Funcion para cerrar la puerta pasado X tiempo
    /// </summary>
    /// <returns></returns>
    public IEnumerator Close()
    {
        // Esperamos el tiempo de cierre y ejecutamos el inicio del cierre de la puerta
        yield return new WaitForSeconds(timeToClose);

        currentSpeed = -movementSpeed;
        isMoving = true;
    }
}
