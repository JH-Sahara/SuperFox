using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  public Rigidbody2D rb; //Player刚体组件
  public int speed = 10; //角色速度

  private Vector2 dir; //接收输入
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        Walk(dir);
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");   
        dir = new Vector2(x,y);
    }

    private void Walk(Vector2 dir)
    {
        rb.velocity = new Vector2(dir.x * speed,rb.velocity.y);
    }
}
