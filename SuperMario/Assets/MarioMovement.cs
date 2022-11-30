using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarioMovement : MonoBehaviour
{
    public float MaxSpeed;
    public float JumpPower;
    Rigidbody2D rigid2D;
    SpriteRenderer spriteRenderer; 
    Animator anim;
    

    void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        //버튼을 누를때 좌우 반전 적용
        if(Input.GetButtonDown("Horizontal"))
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1; 

        //이동 애니메이션 전환
        //절대값 속도의 크기가 1보다 작아지면 Animator 파라미터의 isWalking값을 선택
        if(Mathf.Abs(rigid2D.velocity.x) < 1) 
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        //점프 시 JumpPower 힘으로 위쪽 방향으로 이동
        if(Input.GetButtonDown("Jump")){
            rigid2D.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
        }
    }

    
    void FixedUpdate()
    {
        //수평 이동으로 힘을 가한다
        float h = Input.GetAxisRaw("Horizontal");
        rigid2D.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if(rigid2D.velocity.x > MaxSpeed) //우측 최고 속력
            rigid2D.velocity = new Vector2(MaxSpeed, rigid2D.velocity.y);

        else if(rigid2D.velocity.x < MaxSpeed*(-1)) //좌측 최고 속력
            rigid2D.velocity = new Vector2(MaxSpeed*(-1), rigid2D.velocity.y);


        //if(rigid2D.velocity.y < 0) 
        //{
        Debug.DrawRay(rigid2D.position, Vector3.down, new Color(0,1,0)); //오브젝트의 레이져 발사

        RaycastHit2D rayHit = Physics2D.Raycast(rigid2D.position, Vector2.down, 6, LayerMask.GetMask("flat"));

        if(rayHit.collider != null)
            {
                if(rayHit.distance < 2.0f);
                    anim.SetBool("isJumping", false);
            }        
        //}   
    }
}
