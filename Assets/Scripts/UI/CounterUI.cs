using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CounterUI : MonoBehaviour
{
    public Text count;
    public int value;

    void Update(){
        count.text = value.ToString();
    }
}
