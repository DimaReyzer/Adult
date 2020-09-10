using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillUI : MonoBehaviour, IPointerClickHandler
{
    public SkillData skill;
    public Battle battle;
    public FightCharacter fightCharacter;
    public int countdown = 0;
    [SerializeField] private Image image;
    void OnEnable(){
        if(image == null) image = GetComponent<Image>();
        image.color = new Color(1,1,1,0);
    }
    public void OnPointerClick(PointerEventData pointerEventData){
        Debug.Log("Clicked");
        Click();
    }
    void Update(){
        image.color = Color.Lerp(image.color,Color.white,0.125f);
    }
    void Click(){
        if(countdown <= 0){
            battle.move.Attack(fightCharacter,skill);
            countdown = skill.countdown;
            transform.parent.gameObject.SetActive(false);
        }
    }
}
