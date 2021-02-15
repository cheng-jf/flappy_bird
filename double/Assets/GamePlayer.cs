using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayer : MonoBehaviour
{
    public static GamePlayer instance;
    public GameObject gameOver;
    public GameObject Score;
    public Text scoreDisplay;
    public Text TotalScore;
    private AudioSource bgm;
    public static bool die1 = false;
    public static bool die2 = false;
    public static float stantard_force = 150f;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        bgm = GetComponent<AudioSource>();
        bgm.Play();
    }
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
    public void init()
    {
        die2 = false;
        die1 = false;
        score = 0;
        BackGround.speed = 3f;
        PipeController.speed = 3f;
        bgm.Play();
    }
    public void AddScore(int n)
    {
        /*if (die1&&die2)//两只鸟都死了
        {        
            return;
        }*/
        score += n;
        scoreDisplay.text = "Score: " + score.ToString();
           
    }

    public void GameOver()                         
    {   
        if (die1&&die2)
        { 
            TotalScore.text = "Your Score: " + score.ToString();
            gameOver.SetActive(true);
            Score.SetActive(false);
            BackGround.speed = 0f;
            PipeController.speed = 0f;
            bgm.Stop();
        }
       //print("die1:" + die1 + ",die2:" + die2);
    }
}
