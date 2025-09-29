using System;
using UnityEngine;

[System.Serializable]
public class Player
{
    [SerializeField] private float velocity;
    [SerializeField] private float acceleration;

    public float Velocity { get => velocity; set => velocity = value; }
    public float Acceleration { get => acceleration; set => acceleration = value; }

    public Player(float initialVelocity, float initialAcceleration)
    {
        velocity = initialVelocity;
        acceleration = initialAcceleration;
    }
}