using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    public int birdNum = 0;//计算通过该管子的小鸟数量
    public AudioClip[] addAudio;
    private AudioSource addAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        addAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void addScore()
    {
        birdNum++;
        //print("AddScore: die1:" + GamePlayer.die1 + ",die2:" + GamePlayer.die2+",birdNum:"+birdNum);
        addAudioSource.clip = addAudio[0];
        addAudioSource.Play();
        GamePlayer.instance.AddScore(1);

        // 如果有鸟死亡，重置
        if (GamePlayer.die1 || GamePlayer.die2)
        {
            birdNum = 0;
        }

        if (birdNum == 2) //两只鸟都通过额外加2分
        {
            addAudioSource.clip = addAudio[1];
            addAudioSource.Play();
            GamePlayer.instance.AddScore(2);
            birdNum = 0;
        }
    }
}
