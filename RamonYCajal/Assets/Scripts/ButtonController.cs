using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public Sprite normalSprite;
    public Sprite pressedSprite;
    private SpriteRenderer buttonRenderer;
    private AudioSource _audioSource;

    /// <summary>
    /// Objeto de la puerta
    /// </summary>
    public GameObject door;
    
    private void Start(){
        _audioSource = GetComponent<AudioSource>();
        buttonRenderer = GetComponent<SpriteRenderer>();
        buttonRenderer.sprite = normalSprite;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ramon") || other.CompareTag("Obstacle"))
        {
            DoorController doorController = door.GetComponent<DoorController>();
            // Comprobamos que la puerta no esta en movimiento y que este cerrada
            if (!doorController.isMoving && !doorController.doorState)
            {
                doorController.Open();
                buttonRenderer.sprite = pressedSprite;
                _audioSource.Play();
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ramon") || other.CompareTag("Obstacle"))
        {
            buttonRenderer.sprite = normalSprite;
        }
    }
}
