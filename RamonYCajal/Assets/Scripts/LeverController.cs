using System.Collections.Generic;
using UnityEngine;

public class LeverController : MonoBehaviour
{
    /// <summary>
    /// Define el estado actual de la palanca
    /// True - arriba
    /// False - abajo
    /// </summary>
    [SerializeField] private bool leverState = false;

    /// <summary>
    /// Objeto de Cajal
    /// </summary>
    private GameObject cajal;

    /// <summary>
    /// Objeto de la plataforma
    /// </summary>
    [SerializeField] private GameObject platform;

    /// <summary>
    /// SpriteRenderer
    /// </summary>
    [SerializeField] private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Sprite de palanca en estado cerrado
    /// </summary>
    [SerializeField] private Sprite closedSprite;

    /// <summary>
    /// Sprite de palanca en estado abierto
    /// </summary>
    [SerializeField] private Sprite openSprite;

    /// <summary>
    /// Lista de palancas del nivel
    /// </summary>
    private static List<GameObject> leverList = new List<GameObject>();

    /// <summary>
    /// Gamemanager Object
    /// </summary>
    private GameManager _gm;
    private AudioSource _audioSource;

    public void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        if (!leverList.Contains(gameObject)){
            leverList.Add(gameObject);
        }

        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();

        _gm = GameManager.Instance;
        cajal = _gm.GetCajal();
    }

    public void ActuateLever()
    {
        if (NearLever())
        {
            PlatformController pltController = platform.GetComponent<PlatformController>();
            // Comprobamos que la plataforma no se mueva
            if (!pltController.isMoving)
            {
                _audioSource.Play();
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
            if (lever!= null) 
            {
                float distance = Vector3.Distance(lever.transform.position, cajal.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestLever = lever;
                }
            }
        }

        return closestLever;
    }
}
