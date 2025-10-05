using System;
using UnityEngine;

public class SmoothMovement : IMovementStrategy
{
    public void Move(Transform transform, Player player, float input)
    {
        float moveInX = input * player.Velocity * Time.deltaTime;
        transform.Translate(moveInX, 0, 0);
        Debug.Log($"SmoothMovement - Input: {input}, MoveX: {moveInX}");
    }
}