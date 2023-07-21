using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    [SerializeField] private Transform Player;
    [SerializeField] private float ParalaxAmount;
    [SerializeField] private Vector2 Position;

    private void Update()
    {
        transform.position = new Vector2(Player.transform.position.x / ParalaxAmount + Position.x, Player.transform.position.y / ParalaxAmount + Position.y);
    }
}
