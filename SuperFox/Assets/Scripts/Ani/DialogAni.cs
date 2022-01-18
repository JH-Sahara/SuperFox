using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogAni : MonoBehaviour
{
    //将Dialog对象的激活状态设置为false
    public void SetDialogState()
    {
        gameObject.SetActive(false);
    }
}
