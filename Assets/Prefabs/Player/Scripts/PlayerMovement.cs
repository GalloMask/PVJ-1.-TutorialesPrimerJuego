using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //ATRIBUTOS
    private Vector3 fuerzaPorAplicar;
    private float tiempoUltimaFuerza;
    private float intervaloTiempo;

    private float velocidadLateral;

    private IMovementStrategy strategy;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        fuerzaPorAplicar = new Vector3(0, 0, 300f);
        tiempoUltimaFuerza = 0f;
        intervaloTiempo = 2f;
        velocidadLateral = 2f;

        setStrategy(new MovimientoLateral());
    }

    public void Update()
    {
        strategy.Move(transform, velocidadLateral);
    }

    private void FixedUpdate()
    {
        tiempoUltimaFuerza += Time.fixedDeltaTime;
        if(tiempoUltimaFuerza >= intervaloTiempo){
            gameObject.GetComponent<Rigidbody>().AddForce(fuerzaPorAplicar);
            tiempoUltimaFuerza = 0f;
        }
    }

    public void setStrategy(IMovementStrategy strategy)
    {
        this.strategy = strategy;
    }
}
