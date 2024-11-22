using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public float moveSpeed = 5f;

  private Rigidbody2D rb;
  private Vector2 movement;

  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {

    float moveX = Input.GetAxisRaw("Horizontal");
    float moveY = Input.GetAxisRaw("Vertical");

    movement = new Vector2(moveX, moveY).normalized;
  }

  private void FixedUpdate()
  {

    rb.linearVelocity = movement * moveSpeed;
  }
}
