using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    /// <summary>
    /// Define el estado actual de la palanca
    /// True - arriba
    /// False - abajo
    /// </summary>
    public bool leverState = false;

    /// <summary>
    /// Objeto de Cajal
    /// </summary>
    public GameObject cajal;

    /// <summary>
    /// Objeto de la plataforma
    /// </summary>
    public GameObject platform;

    /// <summary>
    /// SpriteRenderer
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Sprite de palanca en estado cerrado
    /// </summary>
    public Sprite closedSprite;

    /// <summary>
    /// Sprite de palanca en estado abierto
    /// </summary>
    public Sprite openSprite;

    /// <summary>
    /// Lista de palancas del nivel
    /// </summary>
    private static List<GameObject> leverList = new List<GameObject>();

    public void Start()
    {
        if (!leverList.Contains(gameObject)){
            leverList.Add(gameObject);
        }

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public void ActuateLever()
    {
        if (NearLever())
        {
            PlatformController pltController = platform.GetComponent<PlatformController>();
            // Comprobamos que la plataforma no se mueva
            if (!pltController.isMoving)
            {
                if (pltController.platformState)
                {
                    // La plataforma esta arriba, queremos bajarla
                    leverState = false;
                    ChangeSprite(closedSprite);
                    pltController.Move();
                }
                else
                {
                    // La plataforma esta abajo, queremos subirla
                    leverState = true;
                    ChangeSprite(openSprite);
                    pltController.Move();
                }
            }
        }
    }

    /// <summary>
    /// Devuelve si el jugador se encuentra cerca de la palanca
    /// </summary>
    private bool NearLever()
    {
        float distance = Vector3.Distance(transform.position, cajal.transform.position);
        return distance < 2f;
    }

    /// <summary>
    /// Cambia el sprite de la palanca
    /// </summary>
    /// <param name="newSprite"></param>
    private void ChangeSprite(Sprite newSprite)
    {
        spriteRenderer.sprite = newSprite;
    }

    /// <summary>
    /// Devuelve la palanca mas cercana o null si no hay ninguna
    /// </summary>
    /// <returns></returns>
    public GameObject ClosestLever()
    {
        GameObject closestLever = null; 
        float minDistance = 2f;
        foreach (GameObject lever in leverList)
        {
            float distance = Vector3.Distance(lever.transform.position, cajal.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestLever = lever;
            }
        }

        return closestLever;
    }
}
