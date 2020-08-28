using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class PlusMinusParameter : MonoBehaviour
{
    public Button plus;
    public Button minus;
    public int value;
    public Text valueText;
    public int min;
    public int max;
    public UnityEvent onClick;
    void OnEnable(){
        plus.onClick.RemoveAllListeners();
        minus.onClick.RemoveAllListeners();
        plus.onClick.AddListener(Plus);
        minus.onClick.AddListener(Minus);
    }
    void Update(){
        valueText.text = value.ToString();
        /*if(value == max){
            plus.enabled = false;
            minus.enabled = true;
        }else if(value == min){
            plus.enabled = true;
            minus.enabled = false;
        }else{
            plus.enabled = true;
            minus.enabled = true;
        }*/
    }
    public void Plus(){
        if(value < max)
        {
            value++;
        }
        onClick.Invoke();
    }
    private void Minus(){
        if(value > min)
        {
            value--;
        }
        onClick.Invoke();
    }
}
