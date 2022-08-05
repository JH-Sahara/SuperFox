using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oppossum_Dash : MonoBehaviour
{
    public GameObject dashGameObject;
    public float dashFar;
    private float time = 0;
    public float maxTime;//dash创建时间
    private float dashTime = 0;
    public float maxDashTime; //dash时间
    private bool flag = true;

    public bool onDash;
    private Oppossum_Input input;
    private Rigidbody2D rb;

    private void Start() {
        input = GetComponent<Oppossum_Input>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        onDash = input.GetKeyDown(input.dash) || dashTime>0;
        Debug.Log(onDash+":"+input.GetKeyDown(input.dash));

        if (onDash)
        {
            if (flag)
            {
                rb.velocity = new Vector2(transform.localScale.x>0?rb.velocity.x-dashFar:rb.velocity.x+dashFar,rb.velocity.y);
                dashTime = maxDashTime;
                flag = false;
            }
            if (time <= 0)
            {
                Instantiate(dashGameObject,transform.position,Quaternion.identity);
                time = maxTime;
            }
            dashTime -= Time.deltaTime;
            time -= Time.deltaTime;
        }
        else
        {
            dashTime = 0;
            flag = true;
        }
    }
}
