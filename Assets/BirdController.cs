using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{
    public float force=200f;
    private bool die = false;
    private Animator anim;
    private Rigidbody2D rig;
    public AudioClip[] birdAudio;
    private AudioSource birdAudioSource;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rig = GetComponent<Rigidbody2D>();
        birdAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (die == false)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))//空格或者鼠标左键触发小鸟飞
            {
                anim.SetTrigger("fly");
                rig.velocity = Vector2.zero;
                rig.AddForce(new Vector2(0, force));
                birdAudioSource.clip = birdAudio[0];//添加飞翔音效
                birdAudioSource.Play();

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)//阻碍
    {
        if (other.tag == "addscore")//加分
        {
            birdAudioSource.clip = birdAudio[1];//添加加分音效
            birdAudioSource.Play();
            GamePlayer.instance.AddScore();
        }

        if (other.tag == "obstacle")//遇到阻碍停止画面调用gameover方法
        {
            birdAudioSource.clip = birdAudio[2];//添加hit音效
            birdAudioSource.Play();
            rig.velocity = Vector2.zero;
            die = true;
            GameObject.Find("Bird").GetComponent<BirdController>().enabled = false;
            //GameObject.Find("bird").GetComponent<AudioSource>().enabled = false;
            anim.SetTrigger("die");
            birdAudioSource.clip = birdAudio[3];//gameover音效
            birdAudioSource.Play();
            GamePlayer.instance.GameOver();
            BackGround.speed = 0f;
            PipeController.speed = 0f;
            /* GameObject.Find("GameOver").GetComponent<Image>().enabled = true;
             Invoke("ReStart", 5);*/
        }
    }
    void OnCollisionEnter2D()//地板
    {
        birdAudioSource.clip = birdAudio[2];//添加hit音效
        birdAudioSource.Play();
        rig.velocity = Vector2.zero;
        die = true;
        anim.SetTrigger("die");                        // change current animation clip to Die
        GameObject.Find("Bird").GetComponent<BirdController>().enabled = false;
        //GameObject.Find("bird").GetComponent<AudioSource>().enabled = false;
        anim.SetTrigger("die");
        /*birdAudioSource.clip = birdAudio[3];//gameover音效
        birdAudioSource.Play();*/
        GamePlayer.instance.GameOver();
        BackGround.speed = 0f;
        PipeController.speed = 0f;

    }
}

