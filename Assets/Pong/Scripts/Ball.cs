using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
   public Material[] material;
   Renderer rend;

   public float speed = 5f;

    void Start()
    {
        //Enables us to render different colors of the ball.
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];
    }

    void OnCollisionEnter(Collision collision)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;

        if (collision.collider.name.Equals("PaddleRight") || collision.collider.name.Equals("PaddleLeft"))
        {
            //Periodically increase the speed of the ball after each collision
            speed = speed + 3;
            Vector3 direction = rb.velocity.normalized;
            rb.velocity = direction * speed;

            //Generates a random number to pick a random material to change the Ball Color
            int randomNumber = Random.Range(0, 3);
            rend.sharedMaterial = material[randomNumber];
        }

    }

    public void ResetBallSpeed()
    {
        this.speed = 5f;
    }
}