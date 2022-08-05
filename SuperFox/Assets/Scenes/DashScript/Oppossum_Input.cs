using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oppossum_Input : MonoBehaviour
{
    public readonly KeyCode jump = KeyCode.Space;
    public readonly KeyCode dash = KeyCode.LeftShift;
    public float Horizontal
    {
        get => Input.GetAxis("Horizontal");
    }
    public float Vertical
    {
        get => Input.GetAxis("Vertical");
    }

    public bool GetKeyDown(KeyCode key)
    {
        return Input.GetKeyDown(key);
    }
}
