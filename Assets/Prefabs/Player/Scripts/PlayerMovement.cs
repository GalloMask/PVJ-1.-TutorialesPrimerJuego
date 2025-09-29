using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //ATRIBUTOS
    private Vector3 fuerzaPorAplicar;
    private float tiempoUltimaFuerza;
    private float intervaloTiempo;

    private IMovementStrategy movementStrategy;
    private Player player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 300f);
        tiempoUltimaFuerza = 0f;
        intervaloTiempo = 2f;

        player = new Player(2f, 5f);
        SetMovementStrategy(new SmoothMovement());
    }

    public void Update()
    {
        MovePlayer();
    }

    private void FixedUpdate()
    {
        tiempoUltimaFuerza += Time.fixedDeltaTime;
        if(tiempoUltimaFuerza >= intervaloTiempo){
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar);
            tiempoUltimaFuerza = 0f;
        }
    }

    public void MovePlayer()
    {
        movementStrategy.Move(transform, player);
    }

    public void SetMovementStrategy(IMovementStrategy strategy)
    {
        this.movementStrategy = strategy;
    }
}