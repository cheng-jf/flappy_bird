using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int Birdnum = 0;//计算通过该管子的小鸟数量
    public AudioClip[] addaudio;
    private AudioSource addaudioSource;
    // Start is called before the first frame update
    void Start()
    {
        addaudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addScore()
    {
        Birdnum++;
        //print("AddScore: die1:" + GamePlayer.die1 + ",die2:" + GamePlayer.die2+",Birdnum:"+Birdnum);
        addaudioSource.clip = addaudio[0];
        addaudioSource.Play();
        GamePlayer.instance.AddScore(1);

        // 如果有鸟死亡，重置
        if (GamePlayer.die1 || GamePlayer.die2)
        {
            Birdnum = 0;
        }

        if (Birdnum == 2) //两只鸟都通过额外加2分
        {
            addaudioSource.clip = addaudio[1];
            addaudioSource.Play();
            GamePlayer.instance.AddScore(2);
            Birdnum = 0;
        }
    }
}
