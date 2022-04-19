using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject Target;
    public float Size;
    public float RespawnPos;
    public Vector3 Offset;
    private GameObject Ground0;
    private GameObject Ground1;

    private bool OutOfBounds(GameObject ground) 
    {
        return ground.transform.position.x < RespawnPos;
    }

    void Start()
    {
        Ground0 = Instantiate(Target);
        Ground0.transform.position = Offset;
        Ground1 = Instantiate(Ground0);
        Ground1.transform.position += new Vector3(Size, 0, 0);
    }

    void Update()
    {
        if (GameLoop.Paused) return;
        var offset = Vector3.left * GameLoop.Speed * Time.deltaTime;
        Ground0.transform.position += offset;
        Ground1.transform.position += offset;

        if (OutOfBounds(Ground0))
            Ground0.transform.position = Ground1.transform.position + new Vector3(Size, 0, 0);
        if (OutOfBounds(Ground1))
            Ground1.transform.position = Ground0.transform.position + new Vector3(Size, 0, 0);
    }
}
