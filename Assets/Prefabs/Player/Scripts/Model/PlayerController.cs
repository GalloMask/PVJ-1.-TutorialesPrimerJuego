using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Start()
    {
        // Buscar el PlayerMovement en la escena
        playerMovement = Object.FindFirstObjectByType<PlayerMovement>();
        
        if (playerMovement == null)
        {
            Debug.LogError("No se encontró PlayerMovement en la escena!");
        }
    }

    private void Update()
    {
        // Detectar input horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        
        // Debug para verificar que se está detectando el input
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            Debug.Log($"Input detectado: {horizontalInput}");
        }

        // Ejecutar comandos según las teclas presionadas
        if (Input.GetKey(KeyCode.Space))
        {
            ICommand accelerateCommand = new AccelerateMoveCommand(playerMovement, horizontalInput);
            accelerateCommand.Execute();
            Debug.Log("Comando acelerado ejecutado");
        }
        else if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            ICommand moveCommand = new MoveCommand(playerMovement, horizontalInput);
            moveCommand.Execute();
            Debug.Log("Comando movimiento ejecutado");
        }
    }
}