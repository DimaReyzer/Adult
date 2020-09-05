using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SkillsData", menuName = "SkillsData", order = 55)]
public class SkillsData : ScriptableObject
{
    public SkillData[] skills;
    public void GiveSkills(Character character){
        foreach(SkillData skill in skills){
            if(character.race == skill.skillRace && character.characterClass == skill.skillClass){
                character.AddSkill(skill);
            }
        }
    }
}
