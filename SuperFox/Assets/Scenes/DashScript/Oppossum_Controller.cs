using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oppossum_Controller : MonoBehaviour
{
    public float speed;
    public float jump;
    public LayerMask ground;
    public Vector2 bottomOffset;
    public float radius;
    private bool onGround;
    private Oppossum_Input input;
    private Oppossum_Dash dash;
    private Rigidbody2D rb;

    private void Start()
    {
        input = GetComponent<Oppossum_Input>();
        dash = GetComponent<Oppossum_Dash>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() 
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + bottomOffset,radius,ground);

        if (!onGround || dash.onDash)
        {
            //rb.velocity = new Vector2(0,rb.velocity.y);
            return;
        }
        rb.velocity = new Vector2(input.Horizontal * speed,rb.velocity.y);
        if (onGround && input.GetKeyDown(input.jump))
        {
            rb.velocity = new Vector2(0,jump);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere((Vector2)transform.position + bottomOffset,radius);
    }
}
