using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillData", menuName = "SkillData", order = 54)]
public class SkillData : ScriptableObject
{
    public string skillName;
    public Sprite icon;
    [SerializeField]
    public Character.Class skillClass;
    [SerializeField]
    public Character.Race skillRace;
    [SerializeField]
    public enum Attitude {
        self,
        enemy,
        friend
    }
    public Attitude attitude;
    public int countdown = 0;
    public bool passMove = true;
    public float phyStrength;
    public float magStrength;
    public float phyProtection;
    public float magProtection;
    public float vitality;
    public float charisma;
    public float agility;
    public float intelligence;
    public float hp;
}
