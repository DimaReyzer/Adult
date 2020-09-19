using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization; 
using System.Xml.Linq;
using System.IO;
using UnityEditor;
using System;

public class GameManager : MonoBehaviour
{
    private string savesPath;
    public static GameManager instance = null; // Экземпляр объекта

    // Метод, выполняемый при старте игры
    void Awake () {
        // Теперь, проверяем существование экземпляра
        if (instance == null) { // Экземпляр менеджера был найден
            instance = this; // Задаем ссылку на экземпляр объекта
        } else if(instance == this){ // Экземпляр объекта уже существует на сцене
            Destroy(gameObject); // Удаляем объект
        }
            // Теперь нам нужно указать, чтобы объект не уничтожался
            // при переходе на другую сцену игры
        DontDestroyOnLoad(gameObject);

        // И запускаем собственно инициализатор
        InitializeManager();

        savesPath = Application.dataPath + "/Saves";
    }

    void Update(){
        if(Input.GetKeyUp(KeyCode.F5)){
            Save("quickSave");
        }else if(Input.GetKeyUp(KeyCode.F8)){
            Load("quickSave");
        }
    }

    // Метод инициализации менеджера
    private void InitializeManager(){
        /* TODO: Здесь мы будем проводить инициализацию */
    }

    public void Save(string fileName){
        fileName = fileName + ".xml";
        XElement root = new XElement("data");
        root.Add(FindObjectOfType<PlayerPortrait>().GetElement());
        root.Add(Resources.Load<PlayerCharacter>("CurrCharacter").GetElement());

        Debug.Log(root);
        XDocument document = new XDocument(root);

        string path = savesPath + "/" + fileName;
        File.WriteAllText(path,document.ToString());
        Debug.Log(path);
    }
    
    public void Load(string fileName){
        fileName = fileName + ".xml";
        string path = savesPath + "/" + fileName;

        XElement data = null;
        if(File.Exists(path)){
            data = XDocument.Parse(File.ReadAllText(path)).Element("data");
            LoadData(data);
        }else{
            Debug.LogError("The file - " + path + " doesn't exists!");
        }

        Debug.Log(data);
    }

    private void LoadData(XElement data){
        PlayerPortrait portrait = FindObjectOfType<PlayerPortrait>();
        foreach(XElement element in data.Elements("playerPortrait")){
            int playerMain = int.Parse(element.Attribute("main").Value);
            int playerHair = int.Parse(element.Attribute("hair").Value);
            int playerEyes = int.Parse(element.Attribute("eyes").Value);
            int playerBrows = int.Parse(element.Attribute("brows").Value);
            int playerEar = int.Parse(element.Attribute("ear").Value);
            int playerNose = int.Parse(element.Attribute("nose").Value);
            int playerMouth = int.Parse(element.Attribute("mouth").Value);

            portrait.SetMain(playerMain);
            portrait.SetHair(playerHair);
            portrait.SetEye(playerEyes);
            portrait.SetBrows(playerBrows);
            portrait.SetEar(playerEar);
            portrait.SetNose(playerNose);
            portrait.SetMouth(playerMouth);
        }

        Character playerCharacter = Resources.Load<PlayerCharacter>("CurrCharacter");
        foreach(XElement element in data.Elements("character")){
            string firstName = element.Attribute("firstName").Value;
            string secondName = element.Attribute("secondName").Value;
            //Sprite characterPortrait = AssetDatabase.LoadAssetAtPath<Sprite>(element.Attribute("portrait").Value);
            //Sprite fightExample = AssetDatabase.LoadAssetAtPath<Sprite>(element.Attribute("fightExampleElement").Value);
            bool male = StringToBool(element.Attribute("male").Value);
            Character.Race race = (Character.Race) Enum.Parse(typeof(Character.Race),element.Attribute("race").Value);
            Character.Class characterClass = (Character.Class) Enum.Parse(typeof(Character.Class),element.Attribute("characterClass").Value);
            int phyStrength = int.Parse(element.Attribute("phyStrength").Value);
            int magStrength = int.Parse(element.Attribute("magStrength").Value);
            int phyProtection = int.Parse(element.Attribute("phyProtection").Value);
            int magProtection = int.Parse(element.Attribute("magProtection").Value);
            int vitality = int.Parse(element.Attribute("vitality").Value);
            int charisma = int.Parse(element.Attribute("charisma").Value);
            int agility = int.Parse(element.Attribute("agility").Value);
            int intelligence = int.Parse(element.Attribute("intelligence").Value);

            playerCharacter.firstName = firstName;
            playerCharacter.secondName = secondName;
            //playerCharacter.portrait = characterPortrait;
            //playerCharacter.fightExample = fightExample;
            playerCharacter.male = male;
            playerCharacter.race = race;
            playerCharacter.characterClass = characterClass;
            playerCharacter.phyStrength = phyStrength;
            playerCharacter.magStrength = magStrength;
            playerCharacter.phyProtection = phyProtection;
            playerCharacter.magProtection = magProtection;
            playerCharacter.vitality = vitality;
            playerCharacter.charisma = charisma;
            playerCharacter.agility = agility;
            playerCharacter.intelligence = intelligence;
        }
    }

    public static bool StringToBool(string word){
        bool answer = false;
        if(word == "true"){
            answer = true;
        }
        return answer;
    }
}
