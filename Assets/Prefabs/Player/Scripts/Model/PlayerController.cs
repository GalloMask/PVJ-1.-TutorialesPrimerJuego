using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement playerMovement;
    private IMovementStrategy smoothStrategy;
    private IMovementStrategy accelerateStrategy;

    private void Start()
    {
        playerMovement = Object.FindFirstObjectByType<PlayerMovement>();
        
        // Crear las estrategias una sola vez
        smoothStrategy = new SmoothMovement();
        accelerateStrategy = new AcelerateMovement();
        
        if (playerMovement == null)
        {
            Debug.LogError("No se encontró PlayerMovement en la escena!");
        }
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        
        if (Mathf.Abs(horizontalInput) > 0.1f)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                // Usar estrategia acelerada
                playerMovement.SetMovementStrategy(accelerateStrategy);
                playerMovement.MovePlayer(horizontalInput);
                Debug.Log("Movimiento ACELERADO");
            }
            else
            {
                // Usar estrategia suave
                playerMovement.SetMovementStrategy(smoothStrategy);
                playerMovement.MovePlayer(horizontalInput);
                Debug.Log("Movimiento SUAVE");
            }
        }
        else
        {
            // Cuando no hay input, mantener la estrategia pero con input 0
            // Esto es importante para el frenado en AcelerateMovement
            playerMovement.MovePlayer(0);
        }
    }
}