using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform playerTransform; //跟随的对象transform组件
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.position = new Vector3(playerTransform.position.x,playerTransform.position.y,-10f);
    }
}
