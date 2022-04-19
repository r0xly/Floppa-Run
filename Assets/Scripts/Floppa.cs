using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floppa : MonoBehaviour
{
    public float JumpPower;
    private float GroundHeight;
    private Rigidbody2D RigidBody;
    private AudioSource CollisonSound;

    void Start() 
    {
        GroundHeight = transform.position.y;
        RigidBody = GetComponent<Rigidbody2D>();
        CollisonSound = GetComponent<AudioSource>();
    }

    void Update() 
    {
        if (Input.GetKey(KeyCode.Space) && IsGrounded() && !GameLoop.Paused) 
        {
            RigidBody.velocity = new Vector2(0, JumpPower);
        }
    }
     
    bool IsGrounded() {
        return transform.position.y <= GroundHeight;
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if (collider.tag == "Mouse") {
            GameLoop.HealPlayer();
            Destroy(collider.gameObject);
        } 
        else 
        {
            GameLoop.DamagePlayer();
            Destroy(collider);
        }

        CollisonSound.Play(0);

    }
}
