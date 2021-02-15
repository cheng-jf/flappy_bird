using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipeline : MonoBehaviour
{
    public GameObject pipe;   //获取障碍
    public int num = 5;
    public float time = 2f;  //记录创建障碍的间隔

    private GameObject[] pipes;           
    private Vector2 startSpawnPos = new Vector2(1f, 0f);//最开始出现的位置
    private int index = 0;
    private float lastTime = 0;
    // Use this for initialization
    void Start()
    {
      
        pipes = new GameObject[num];  
        for (int i = 0; i < num; i++)
        {
            pipes[i] = (GameObject)Instantiate(pipe, startSpawnPos, Quaternion.identity);
            pipes[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GamePlayer.die1 && GamePlayer.die2)
        {
            return;
        }
        if (Time.time - time > lastTime)
        {
            lastTime = Time.time;
            pipes[index].transform.position = new Vector2(13f, Random.Range(3f,6f));
            pipes[index].SetActive(true);        
            index++;                                 

            if (index >= num)
            {                 
                index = 0;
            }
        }
    }

}
