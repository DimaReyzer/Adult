using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBarUI : MonoBehaviour
{
    public float max = 1;
    public float fillValue{
        get{
            return fValue;
        }set{
            fValue = value;
            fValue = Mathf.Clamp(fValue,0,max);
            if(text != null){
                if(showMax){
                    text.text = fValue.ToString() + "/" + max.ToString();
                }else{
                    text.text = fValue.ToString();
                }
            }
        }
    }
    public bool showMax = true;
    public RectTransform bar;
    private RectTransform RT;
    private Text text;
    private float width;
    private float fValue = 0;
    void OnEnable(){
        text = GetComponentInChildren<Text>();
        RT = GetComponent<RectTransform>();
        width = RT.rect.size.x;
    }
    void Update(){
        float localFloat = fValue/max;
        Vector2 locPos = new Vector2();
        Vector2 locSize = new Vector2();
        if(localFloat > 0){
            locPos = new Vector2((width / 2) * localFloat - width/2,bar.localPosition.y);
        }else{
            locPos = new Vector2(0,bar.localPosition.y);
        }
        locSize = new Vector2(width * localFloat,bar.sizeDelta.y);
        bar.localPosition = Vector3.Lerp(bar.localPosition,locPos,0.25f);
        bar.sizeDelta = Vector3.Lerp(bar.sizeDelta,locSize,0.25f);
    }
}
