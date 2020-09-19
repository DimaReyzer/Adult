using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using UnityEditor;

[CreateAssetMenu(fileName = "New player character", menuName = "Player character", order = 56)]
public class PlayerCharacter : Character
{
    public GameObject portrait;

    protected override void Initialize()
    {
        base.Initialize();
        portrait = Resources.Load<GameObject>("PlayerPortrait");
    }
    /*public override XElement GetElement(){
        base.GetElement();
        string portraitElement = AssetDatabase.GetAssetPath(portrait);
        XElement element = new XElement("playerCharacter",);

        return element;
    }*/
}
