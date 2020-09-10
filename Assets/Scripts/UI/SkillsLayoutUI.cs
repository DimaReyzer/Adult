using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsLayoutUI : MonoBehaviour
{
    public FightCharacter character;
    public Battle battle;
    private HorizontalLayoutGroup layoutGroup;
    private List<SkillUI> skillsUI;
    [SerializeField] private SkillUI skillUI;
    void OnEnable(){
        if(layoutGroup == null) layoutGroup = GetComponent<HorizontalLayoutGroup>();
        if(character == null) character = GetComponentInParent<FightCharacter>();
        layoutGroup.spacing = -2.0f;
    }
    public void Initialize(List<SkillData> skills, FightCharacter target){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
        foreach(SkillData skill in skills){
            if(target.enemy && skill.attitude == SkillData.Attitude.enemy){
                SkillUI instSkill = Instantiate<SkillUI>(skillUI);
                instSkill.transform.SetParent(transform);
                instSkill.GetComponent<Image>().sprite = skill.icon;
                instSkill.skill = skill;
                instSkill.fightCharacter = character;
                instSkill.battle = battle;
            }else if(!target.enemy && skill.attitude == SkillData.Attitude.friend){
                SkillUI instSkill = Instantiate<SkillUI>(skillUI);
                instSkill.transform.SetParent(transform);
                instSkill.GetComponent<Image>().sprite = skill.icon;
                instSkill.skill = skill;
                instSkill.fightCharacter = character;
                instSkill.battle = battle;
            }else if(target == character && skill.attitude == SkillData.Attitude.self){
                SkillUI instSkill = Instantiate<SkillUI>(skillUI);
                instSkill.transform.SetParent(transform);
                instSkill.GetComponent<Image>().sprite = skill.icon;
                instSkill.skill = skill;
                instSkill.fightCharacter = character;
                instSkill.battle = battle;
            }
        }
    }
    void Update(){
        layoutGroup.spacing = Mathf.Lerp(layoutGroup.spacing,0.25f,0.125f);
    }
    void OnDisable(){
        foreach(Transform child in transform){
            Destroy(child.gameObject);
        }
    }
}
