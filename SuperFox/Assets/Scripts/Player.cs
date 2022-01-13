using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D playerRigidbody; //角色的刚体组件
    public int speed = 10; //初始速度
    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }
}
