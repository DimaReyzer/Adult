using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarUI : MonoBehaviour
{
    public float max = 1;
    public float value = 0;
    public bool showMax = true;
    public RectTransform bar;
    private RectTransform RT;
    private Text text;
    private float width;
    void OnEnable(){
        text = GetComponentInChildren<Text>();
        RT = GetComponent<RectTransform>();
        width = RT.sizeDelta.x;
    }
    void Update(){
        value = Mathf.Clamp(value,0,max);
        if(showMax){
            text.text = max.ToString() + "/" + value.ToString();
        }else{
            text.text = value.ToString();
        }
        float localFloat = value/max;
        if(localFloat > 0){
            bar.localPosition = new Vector2((width / 2) * localFloat - width/2,bar.localPosition.y);
        }else{
            bar.localPosition = new Vector2(0,bar.localPosition.y);
        }
        bar.sizeDelta = new Vector2(width * localFloat,bar.sizeDelta.y);
    }
}
