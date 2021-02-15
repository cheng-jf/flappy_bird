using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    public static float speed = 3f;
    Vector3 pipePos;    //获取当前的位置

    // Use this for initialization
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);//每一帧向左移动
        /*pipePos = transform.position;//获取当前帧的图片的位置
        
        if (pipePos.x < -15f)//当移出画面外时销毁
        {
            Destroy(gameObject);
        }*/
    }
}
