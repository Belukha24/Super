using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
     private new Rigidbody2D rigidbody;
     private Vector2 velocity;
     private float inputAxis;
     public float moveSpeed = 8f;

     SpriteRenderer spriteRenderer;

     private void Awake()
     {
          rigidbody = GetComponent<Rigidbody2D>();

          spriteRenderer = GetComponent<SpriteRenderer>();
     }

     private void Update()
     {
          Movement(); //캐릭터를 x축으로 이동

          spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
     }
     private void Movement()
     {
          inputAxis = Input.GetAxis("Horizontal");
          velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);//수평으로 
     }

     private void FixedUpdate()
     {
          Vector2 position = rigidbody.position;
          position += velocity * Time.fixedDeltaTime;

          rigidbody.MovePosition(position);
     }
}









/* {
     public float moveSpeed = 1.0f;
     public float jumpPower;
     Vector2 movement = new Vector2();
     Rigidbody2D rigid;
     
     void Start()
     {
          rigid = GetComponent<Rigidbody2D>();
     }

     void FixedUpdate()
     {
          Move();
          Jump();
     }

          void Move()
     {
          movement.x = Input.GetAxisRaw("Horizontal");

          movement.Normalize();

          rigid.velocity = movement * moveSpeed;
     }

     void Jump()
     {
          if(Input.GetKeyDown(KeyCode.Space))
          {
               rigid.AddForce(Vector3.up, ForceMode2D.Impulse);
          }
     }
} */



