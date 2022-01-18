using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialog : MonoBehaviour
{
    public GameObject enterDialog;
    public Animator ani;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            enterDialog.SetActive(true);
            ani.SetBool("exiting",false);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            ani.SetBool("exiting",true);
        }
    }
}
