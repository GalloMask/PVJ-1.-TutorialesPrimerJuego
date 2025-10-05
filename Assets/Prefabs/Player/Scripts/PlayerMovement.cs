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

        player = new Player(2f, 5f);
        SetMovementStrategy(new SmoothMovement());
    }

    private void FixedUpdate()
    {
        tiempoUltimaFuerza += Time.fixedDeltaTime;
        if(tiempoUltimaFuerza >= intervaloTiempo){
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar);
            tiempoUltimaFuerza = 0f;
        }
    }

    public void MovePlayer(float input)
    {
        movementStrategy.Move(transform, player, input);
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
    }
}