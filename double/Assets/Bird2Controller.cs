﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird2Controller : MonoBehaviour
{
    public float force;
    private Animator anim;
    private Rigidbody2D rig;
    public AudioClip[] birdAudio;
    private AudioSource birdAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        force = GamePlayer.stantard_force;
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        birdAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//A控制第二只鸟
        {
            anim.SetTrigger("fly");
            rig.velocity = Vector2.zero;
            rig.AddForce(new Vector2(0, force));
            birdAudioSource.clip = birdAudio[0];//添加飞翔音效
            birdAudioSource.Play();
        }
    }

    void OnTriggerEnter2D(Collider2D other)//阻碍
    {
        if (other.tag == "addscore" && !GamePlayer.die2)//加分
        {
            other.SendMessage("addScore");
        }

        if (other.tag == "obstacle")//遇到阻碍停止画面调用gameover方法
        {
            if (!GamePlayer.die2)
            {
                birdAudioSource.clip = birdAudio[2];//添加hit音效
                birdAudioSource.Play();
                rig.velocity = Vector2.zero;
                GameObject.Find("Bird2").GetComponent<Bird2Controller>().enabled = false;
                anim.SetTrigger("die");
                birdAudioSource.clip = birdAudio[3];//fall音效
                birdAudioSource.Play();
                GamePlayer.die2 = true;
                GamePlayer.instance.GameOver();
            }
        }
    }
    void OnCollisionEnter2D()//地板
    {
        if (!GamePlayer.die2)
        {
            birdAudioSource.clip = birdAudio[2];//hit音效
            birdAudioSource.Play();
            rig.velocity = Vector2.zero;
            anim.SetTrigger("die");
            GameObject.Find("Bird2").GetComponent<Bird2Controller>().enabled = false;
            GamePlayer.die2 = true;
            GamePlayer.instance.GameOver();
        } 
    }
}

