using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAWSD : MonoBehaviour
{
    public float speed = 5f;
    private Vector2 movementInput;

    
    public AudioManager audioManager;

    void FixedUpdate()
    {
        Vector3 moveDirection = new Vector3(movementInput.x, 0, movementInput.y);
        transform.position += moveDirection.normalized * speed * Time.deltaTime;

        // Si el personaje se est� moviendo y el sonido "Caminar" no se est� reproduciendo, reproducir el sonido
        if (moveDirection != Vector3.zero && !audioManager.SFXSource.isPlaying)
        {
            audioManager.SFXSource.clip = audioManager.Caminar;
            audioManager.SFXSource.Play();
        }
        // Si el personaje no se est� moviendo y el sonido "Caminar" se est� reproduciendo, detener el sonido
        else if (moveDirection == Vector3.zero && audioManager.SFXSource.clip == audioManager.Caminar && audioManager.SFXSource.isPlaying)
        {
            audioManager.SFXSource.Stop();
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>();
    }
}