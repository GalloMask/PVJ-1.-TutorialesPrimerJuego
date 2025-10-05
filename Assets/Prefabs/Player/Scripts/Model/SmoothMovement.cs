using System;
using UnityEngine;

public class SmoothMovement : IMovementStrategy
{
    public void Move(Transform transform, Player player, float direccion)
    {
        float moveInX = direccion * player.Velocity * Time.deltaTime;
        transform.Translate(moveInX, 0, 0);
    }
}