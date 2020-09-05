using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillsLayoutUI : MonoBehaviour
{
    public FightCharacter character;
    private HorizontalLayoutGroup layoutGroup;
    private List<SkillUI> skillsUI;
    void OnEnable(){
        if(layoutGroup == null) layoutGroup = GetComponent<HorizontalLayoutGroup>();
        if(character == null) character = GetComponentInParent<FightCharacter>();
        layoutGroup.spacing = -2.0f;
        Initialize();
    }
    void Initialize(){
        
    }
    void Update(){
        layoutGroup.spacing = Mathf.Lerp(layoutGroup.spacing,0.25f,0.125f);
    }
}
