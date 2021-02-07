using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
  public Hand hand;
  public Trampoline leftPaddle;
  public Trampoline rightPaddle;


    void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space))
    {
      hand.Release();
    }

    if (Input.GetKeyDown(KeyCode.R))
    {
      hand.Reset();
    }

    if (Input.GetAxis("PaddleLeft") != 0)
    {
      leftPaddle.transform.Translate(Vector3.forward * Input.GetAxis("PaddleLeft"),Space.World);
    }

    if (Input.GetAxis("PaddleRight") != 0)
    {
      rightPaddle.transform.Translate(Vector3.forward * Input.GetAxis("PaddleRight"),Space.World);
    }
  }

}
