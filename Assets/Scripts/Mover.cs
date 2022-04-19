using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    void Update()
    {
        if (GameLoop.Paused) return;
        transform.position += Vector3.left * GameLoop.Speed * Time.deltaTime;    
    }
}
