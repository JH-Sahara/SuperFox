using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody2D rb; //Player刚体组件

  [Space]

  [Header("State")]
  public int speed = 10; //角色速度
  public int jumpForce = 10; //角色跳跃力度
  public float slideSpeed = 5; //角色撞墙滑动速度

  [Space]

  [Header("Bolleans")]
  public bool canMove; //是否移动
  public bool wallGrab; //抓墙
  public bool wallJumped; //墙跳
  public bool wallSlide; //墙上滑动
  public bool isDashing; //疾跑

  [Space]
  public int side = 1; //墙的那一边

  private Vector2 dir; //接收输入
  private Collision coll; //获取角色碰撞状态
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collision>();
    }

    
    void FixedUpdate()
    {
        Walk(dir);

        if (wallGrab && !wallJumped)
        {
            rb.velocity = new Vector2(rb.velocity.x,dir.y * speed);
            rb.gravityScale = 0;
        }else{
            rb.gravityScale = 1;
        }
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");   
        dir = new Vector2(x,y);

        wallGrab = coll.onWall && Input.GetKey(KeyCode.LeftShift);

        if (coll.onWall && !coll.onGround && rb.velocity.y<.1f)
        {
            WallSlide();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (coll.onGround)
            {
                Jump(Vector2.up);
            }  
            if (coll.onWall && !coll.onGround)
            {
                WallJump();
            }
        }
    }

    //左右行走
    private void Walk(Vector2 dir)
    {
        if (wallJumped)
            return;//TODO:何时修改wall Jumped的值来恢复左右控制权
        rb.velocity = new Vector2(dir.x * speed,rb.velocity.y);
    }

    //跳跃
    private void Jump(Vector2 dir)
    {
        rb.velocity = new Vector2(rb.velocity.x,0);
        rb.velocity += dir * jumpForce;
        Debug.Log(rb.velocity);
    }

    private void WallSlide()
    {
        bool pushingWall = false;
        if ((rb.velocity.x > 0 && coll.onRightWall) || (rb.velocity.x < 0 && coll.onLeftWall))
        {
            pushingWall = true;
        }

        float push = pushingWall ? 0 : rb.velocity.x;
        rb.velocity = new Vector2(push,-slideSpeed);
    }

    //墙跳
    private void WallJump()
    {
        Vector2 wallDir = coll.onRightWall ? Vector2.left : Vector2.right;

        wallJumped = true;
        Jump(Vector2.up + wallDir);
    }
}
