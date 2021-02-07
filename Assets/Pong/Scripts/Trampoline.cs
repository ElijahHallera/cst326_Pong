using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trampoline : MonoBehaviour
{
  
  public float impulseStrength = 1f;

  void OnCollisionEnter(Collision collision)
  {
    Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
    rb.AddForce((transform.up * impulseStrength), ForceMode.Impulse);
  }
}
