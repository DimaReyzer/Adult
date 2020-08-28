using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class CreatingPersonUI : MonoBehaviour
{
    public Character currCharacter;
    public Text fname;
    public Text sName;
    public Slider gender;
    public Dropdown race;
    public Dropdown charClass;
    public PlusMinusParameter[] parameters;
    public CounterUI pointCounter;
    private bool parametersReady = false;
    void OnEnable(){
        race.options.Clear();
        var races = Enum.GetValues(typeof(Character.Race));   
        foreach (var item in races)
        {
            string newStr = FirstUpper(item.ToString());
            race.options.Add(new Dropdown.OptionData(newStr));
        }

        charClass.options.Clear();
        var classes = Enum.GetValues(typeof(Character.Class));   
        foreach (var item in classes)
        {
            string newStr = FirstUpper(item.ToString());
            charClass.options.Add(new Dropdown.OptionData(newStr));
        }
        for(int i = 0;i < parameters.Length;i++){
            parameters[i].value = 16;
        }
        /*for (int i = 0;i < parameters.Length;i++)
        {
            Button[] buttons = parameters[i].GetComponentsInChildren<Button>();
            buttons[0].onClick.AddListener(ChangeParameter(true,i));
        }*/
        for(int i = 0;i < parameters.Length;i++){
            parameters[i].onClick.RemoveAllListeners();
            parameters[i].onClick.AddListener(SetParameterLimit);
        }
        pointCounter.value = 8;
    }
    void OnDisable(){
        for(int i = 0;i < parameters.Length;i++){
            parameters[i].onClick.RemoveAllListeners();
        }
        pointCounter.value = 8;
    }
    void Update(){

    }
    public void CreatePerson(){
        int allValue = 0;
        if(true){
            currCharacter.firstName = fname.text;
            currCharacter.secondName = sName.text;
            if(gender.value == 1){
                currCharacter.male = true;
            }else if(gender.value == 0){
                currCharacter.male = false;
            }
            currCharacter.race = (Character.Race)Enum.Parse(typeof(Character.Race), SmallLeters(race.GetComponentInChildren<Text>().text));
            currCharacter.characterClass = (Character.Class)Enum.Parse(typeof(Character.Class), SmallLeters(charClass.GetComponentInChildren<Text>().text));
            foreach (var item in parameters)
            {
                allValue += item.value;
            }
        }
        if(allValue >= 16*8+8){
            currCharacter.phyStrength = parameters[0].value;
            currCharacter.phyProtection = parameters[1].value;
            currCharacter.magStrength = parameters[2].value;
            currCharacter.magProtection = parameters[3].value;
            currCharacter.vitality = parameters[4].value;
            currCharacter.charisma = parameters[5].value;
            currCharacter.agility = parameters[6].value;
            currCharacter.intelligence = parameters[7].value; 
        }   
        else{
            Debug.Log("Вы заполнили не все поля!");
        }
    }
    public static string FirstUpper(string str)
    {
        string[] s = str.Split(' ');
 
         for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Length > 1)
                 s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
            else s[i] = s[i].ToUpper();
        }
        return string.Join(" ", s);
    }
    public static string SmallLeters(string str)
    {
        string[] s = str.Split(' ');
 
         for (int i = 0; i < s.Length; i++)
        {
            if (s[i].Length > 1)
                 s[i] = s[i].Substring(0, 1).ToLower() + s[i].Substring(1, s[i].Length - 1).ToLower();
            else s[i] = s[i].ToLower();
        }
        return string.Join(" ", s);
    }
    int GetParametersValue(){
        int answer = 0;
        for(int i = 0;i < parameters.Length;i++){    
            answer += parameters[i].value;
        }
        return answer;
    }
    void SetParameterLimit(){
        pointCounter.value = ((16*8)+8) - GetParametersValue();
        for(int i = 0;i < parameters.Length;i++){
            if(pointCounter.value <= 0){
                parameters[i].plus.enabled = false;
                parameters[i].minus.enabled = true;
            }else{
                parameters[i].plus.enabled = true;
                parameters[i].minus.enabled = true;
            }
        }
    }
    /*public void PlusParameter(int index){
        Text localText = parameters[index];
        int localInt =  intParameters[index];
        if(localInt < 24){
            localInt++;
        }
        localText.text = localInt.ToString();
        intParameters[index] = localInt;
    }
    public void MinusParameter(int index){
        Text localText = parameters[index];
        int localInt =  intParameters[index];
        if(localInt > 8){
            localInt--;
        }
        localText.text = localInt.ToString();
        intParameters[index] = localInt;
    }*/
}
