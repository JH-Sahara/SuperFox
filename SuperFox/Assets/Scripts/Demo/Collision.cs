using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    [Header("Layers")]
    public LayerMask groundLayer;

    [Space]

    public bool onGround; //是否在碰撞面上
    private bool changeGround;
    public bool onWall; //是否在墙上
    public bool onLeftWall; 
    public bool onRightWall; 
    public int wallSide; //在墙的那一边，和onLeftWall、onRightWall挂钩

    [Space]

    [Header("Collision")]
    public float collisionRadius = 0.25f; //碰撞检测的半径范围
    public Vector2 bottomOffset,leftOffset,rightOffset;
    public Color debugCollisionColor = Color.red;

    private float groundTime = 0f; //容错时间
    private float maxGroundTime = .3f; //最大容错时间

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        changeGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset,collisionRadius,groundLayer);
        if (changeGround)
        {
            onGround = changeGround;
        }else{
            groundTime += Time.deltaTime;
            if (groundTime > maxGroundTime)
            {
                onGround = changeGround;
                groundTime = 0f;
            }
        }
        
        onWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset,collisionRadius,groundLayer)
            || Physics2D.OverlapCircle((Vector2)transform.position + rightOffset,collisionRadius,groundLayer);
        
        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset,collisionRadius,groundLayer);
        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset,collisionRadius,groundLayer);

        wallSide = onRightWall ? -1 : 1; 
    }

    //调试方法，绘制检测范围
    private void OnDrawGizmos() {
        Gizmos.color = debugCollisionColor;

        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset,collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset,collisionRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset,collisionRadius);
    }
}
