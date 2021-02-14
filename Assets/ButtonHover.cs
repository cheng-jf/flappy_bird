using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonHover : MonoBehaviour
{
    public Image image;
    bool flag = false;
    float ColorAlpha = 0f;//图片透明程度
    public float speed = 0.75f;

    void Start()
    {
        image.GetComponent<Image>().color = new Color(255, 255, 255, ColorAlpha);
    }
    void Update()
    {
        if (flag == true)
        {
            if (ColorAlpha <= 0.75)
            {
                ColorAlpha += Time.deltaTime * speed;
                image.GetComponent<Image>().color = new Color(255, 255, 255, ColorAlpha);
            }
        }
    }
    private void OnMouseEnter()
    {
        flag = true;
    }
    private void OnMouseExit()
    {
        flag = false;
        flag = false;
        ColorAlpha = 0;
        image.GetComponent<Image>().color = new Color(255, 255, 255, ColorAlpha);

    }
}
