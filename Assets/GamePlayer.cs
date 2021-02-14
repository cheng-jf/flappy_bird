using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlayer : MonoBehaviour
{
    public static GamePlayer instance;             // 创建单例
    public GameObject gameOver; 
    public Text scoreDisplay;
    private AudioSource bgm;
    private bool die = false;                 
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
        if (die == true && Input.GetMouseButtonDown(0))//鸟死并且点击了重新开始
        {         
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            BackGround.speed = 3f;
            PipeController.speed = 3f;
        }
    }
    public void AddScore()                        
    {
        if (die)
            return;

        score += 1;
        scoreDisplay.text = "Score: " + score.ToString();
    }

    public void GameOver()                         
    {
        gameOver.SetActive(true);
        die = true;
        bgm.Stop();
    }
}
