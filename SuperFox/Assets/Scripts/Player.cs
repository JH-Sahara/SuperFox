using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody; //角色的刚体组件
    public Animator playerAnimator; //角色动画控制器
    public LayerMask ground;
    public int speed = 10; //初始速度
    public int jumpForce = 50; //初始力
    public int score = 0; //吃掉食物的得分
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
         ChangeAnimation();
        Change();
    }

    void FixedUpdate()
    {
        Move();
    }

    //角色的移动函数
    void Move()
    {
        //首先获取玩家的输入
        float input = Input.GetAxisRaw("Horizontal");

        //角色动画的控制
        playerAnimator.SetFloat("running",Mathf.Abs(input));

        //角色移动
        if (input != 0)
        {
            playerRigidbody.velocity = new Vector2(input*speed*Time.fixedDeltaTime,playerRigidbody.velocity.y);
            if (input > 0)
            {
                transform.localScale = new Vector3(1,1,1);
            }else{
                transform.localScale = new Vector3(-1,1,1);
            }
        }

        //判断是否跳跃
        if (Input.GetButton("Jump") && playerAnimator.GetBool("idling"))
        {
            playerAnimator.SetBool("idling",false);
            playerAnimator.SetBool("jumping",true);
            playerRigidbody.velocity = new Vector2(playerRigidbody.velocity.x,jumpForce*Time.fixedDeltaTime);
        }
        
    }

    //角色移动等动画的更新
    void ChangeAnimation()
    {
        if (playerAnimator.GetBool("jumping"))
        {
            if (playerRigidbody.velocity.y < 0)
            {
                playerAnimator.SetBool("jumping",false);
                playerAnimator.SetBool("falling",true);
            }
        }else if (playerRigidbody.IsTouchingLayers(ground) && playerRigidbody.velocity.y<=0){
            playerAnimator.SetBool("falling",false);
            playerAnimator.SetBool("idling",true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            score ++;
        }
    }

    //一般性输入改变状态的函数
    private void Change()
    {
        //判断是否下蹲
        if (Input.GetKeyDown(KeyCode.C) && playerAnimator.GetBool("idling"))
        {
            bool isCrouching = playerAnimator.GetBool("crouching");
            playerAnimator.SetBool("crouching",!isCrouching);
            gameObject.GetComponent<BoxCollider2D>().enabled = isCrouching;
        }
    }
}
