using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oppossum_Ani : MonoBehaviour
{
    private Oppossum_Input input;

    private void Start() 
    {
        input = GetComponent<Oppossum_Input>();
    }

    private void Update() 
    {
        if (input.Horizontal > 0)
        {
            transform.localScale = new Vector3(-1,1,1);
        }
        else if (input.Horizontal == 0)
        {
            
        }
        else
        {
            transform.localScale = new Vector3(1,1,1);
        }
    }
}
