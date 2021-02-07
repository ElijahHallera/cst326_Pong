using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
  public Ball ball;
  private Rigidbody rb;

    //set initial speed of ball
    public float speed = 5f;

    void Start()
    {
        rb = ball.gameObject.AddComponent<Rigidbody>();
        rb.useGravity = false;
    }
    
    //This releases the ball upon hitting spacebar. Randomizes tossing left or right.
    public void Release()
    {
        //Manually set position of ball so that it doesnt spawn high up in the air. "Y-axis".
        ball.transform.position = Vector3.zero;

        //This is a 50/50 chance to send ball to either left or right player.
        float ballx = Random.Range(0, 2) == 0 ? -1 : 1;
        float ballz = Random.Range(0, 2) == 0 ? -1 : 1;

        //Constrained the ball to travel along the x and z axis and leave the Y-axis alone so it doesn't go out of map.
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY;
        rb.velocity = new Vector3(speed * ballx, 0, speed * ballz);
    }

    public void Reset()
    {
      ball.transform.position = this.gameObject.transform.position;
      ball.ResetBallSpeed();
      rb.useGravity = false;
      rb.velocity = Vector3.zero;
    }
}
