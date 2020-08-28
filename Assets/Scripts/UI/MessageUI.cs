using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageUI : MonoBehaviour
{
    public CanvasUI canvas;
    public string message;
    public Color textColor;
    public Vector2 pos;
    public float timeOut = 5;
    public bool goTime = true;
    private Text text;
    private RectTransform RT;
    private Image image;
    private float timer = 0;
    public MessageUI(string text, Color color){
        message = text;
        textColor = color;
    }
    void OnEnable(){
        text = GetComponentInChildren<Text>();
        RT = GetComponent<RectTransform>();
        image = GetComponent<Image>();
        text.text = message;
        text.color = textColor;
        timer = 0;
    }
    void Update(){
        if(goTime){
            RT.transform.position = Vector2.Lerp(RT.transform.position,pos,0.25f);
            timer += Time.deltaTime;
            image.color = new Color(image.color.r,image.color.g,image.color.b,timer);
            if(timer >= 1.0f){
                timeOut -= Time.deltaTime;
                if(timeOut <= 1.0f){
                    image.color = new Color(image.color.r,image.color.g,image.color.b,timeOut);
                    if(timeOut <= 0.0f){
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
    void OnDisable(){
        //canvas.CalculateMessages();
    }
}
