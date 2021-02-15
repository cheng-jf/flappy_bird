using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround : MonoBehaviour
{
    private const float width = 15.2f;//第二个草地位置
    private Vector3 beginPos = new Vector3(0, 0, 0);//最初背景的位置
    public static float speed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);//向左移动

        if (transform.localPosition.x <= -width)// 超出视野移到最初的位置
        {
            transform.localPosition = beginPos;
        }
    }
}

