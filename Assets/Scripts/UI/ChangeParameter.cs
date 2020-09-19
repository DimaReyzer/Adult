using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeParameter : PlusMinusParameter
{
    void OnEnable(){
        plus.onClick.RemoveAllListeners();
        minus.onClick.RemoveAllListeners();
        plus.onClick.AddListener(Plus);
        minus.onClick.AddListener(Minus);
    }
    void Update(){

    }
}
