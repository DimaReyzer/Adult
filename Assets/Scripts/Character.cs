using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Linq;
using UnityEditor;
using System;

[CreateAssetMenu(fileName = "New character", menuName = "Character", order = 51)]
public class Character : ScriptableObject
{
    public string firstName = "First name";
    public string secondName = "Second name";
    public Sprite portrait;
    public Sprite fightExample;
    public bool male = false;
    public enum Race{
        human,
        elf
    }
    public enum Class{
        support,
        tank,
        karri
    }
    public Race race;
    public Class characterClass;
    public int phyStrength;
    public int magStrength;
    public int phyProtection;
    public int magProtection;
    public int vitality;
    public int charisma;
    public int agility;
    public int intelligence;
    public List<SkillData> skills;
    public void AddSkill(SkillData skill){
        skills.Add(skill);
    }
    void OnEnable(){
        Initialize();
    }
    protected virtual void Initialize(){
        skills.Clear();
        Resources.Load<SkillsData>("Skills").GiveSkills(this);
    }
    public virtual XElement GetElement(){
        XAttribute firstNameElement = new XAttribute("firstName",firstName);
        XAttribute secondNameElement = new XAttribute("secondName",secondName);
        XAttribute portraitElement = new XAttribute("portrait",AssetDatabase.GetAssetPath(portrait));
        XAttribute fightExampleElement = new XAttribute("fightExample",AssetDatabase.GetAssetPath(fightExample));
        XAttribute maleElement = new XAttribute("male",male);
        XAttribute raceElement = new XAttribute("race",race);
        XAttribute classElement = new XAttribute("characterClass",characterClass);
        XAttribute phyStrengthElement = new XAttribute("phyStrength",phyStrength);
        XAttribute magStrengthElement = new XAttribute("magStrength",magStrength);
        XAttribute phyProtectionElement = new XAttribute("phyProtection",phyProtection);
        XAttribute magProtectionElement = new XAttribute("magProtection",magProtection);
        XAttribute vitalityElement = new XAttribute("vitality",vitality);
        XAttribute charismaElement = new XAttribute("charisma",charisma);
        XAttribute agilityElement = new XAttribute("agility",agility);
        XAttribute intelligenceElement = new XAttribute("intelligence",intelligence);

        XElement element = new XElement("character",name,new XAttribute("firstName",firstName),new XAttribute("secondName",secondName),
        portraitElement,fightExampleElement,maleElement,raceElement,classElement,
        phyStrengthElement,magStrengthElement,phyProtectionElement,magProtectionElement,vitalityElement,charismaElement,agilityElement,intelligenceElement);

        return element;
    }
}
