using UnityEngine;

public class MovimientoLateral : IMovementStrategy
{
    public void Move(Transform transform, float velocidad)
    {
        float direccion = Input.GetAxis("Horizontal");
        transform.Translate(direccion * velocidad * Time.deltaTime, 0,0);
    }
}
