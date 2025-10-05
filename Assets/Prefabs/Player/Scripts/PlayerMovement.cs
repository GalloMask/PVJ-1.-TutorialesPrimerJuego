using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //ATRIBUTOS
    private Vector3 fuerzaPorAplicar;
    private float tiempoUltimaFuerza;
    private float intervaloTiempo;

    private IMovementStrategy movementStrategy;
    private Player player;

    private void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 300f);
        tiempoUltimaFuerza = 0f;
        intervaloTiempo = 2f;

        // Inicializar el player con valores
        player = new Player(5f, 10f); // velocidad, aceleración
        
        // Asegurar que hay una estrategia por defecto
        SetMovementStrategy(new SmoothMovement());
        
        Debug.Log("PlayerMovement inicializado correctamente");
    }

    private void FixedUpdate()
    {
        tiempoUltimaFuerza += Time.fixedDeltaTime;
        if(tiempoUltimaFuerza >= intervaloTiempo){
            Rigidbody rb = gameObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(fuerzaPorAplicar);
            }
            tiempoUltimaFuerza = 0f;
        }
    }

    public void MovePlayer(float input)
    {
        if (movementStrategy != null)
        {
            movementStrategy.Move(transform, player, input);
        }
        else
        {
            Debug.LogError("No hay estrategia de movimiento asignada!");
        }
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
        Debug.Log($"Estrategia cambiada a: {strategy.GetType().Name}");
    }
}