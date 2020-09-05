using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    void Initialize(){
        skills.Clear();
        Resources.Load<SkillsData>("Skills").GiveSkills(this);
    }
}
