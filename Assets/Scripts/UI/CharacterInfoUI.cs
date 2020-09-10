using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoUI : MonoBehaviour
{
    public Character character;
    public RectTransform RT;
    [SerializeField] private Text fullName;
    [SerializeField] private Text phyProtection;
    [SerializeField] private Text magProtection;
    [SerializeField] private Text phyStrength;
    [SerializeField] private Text magStrength;
    [SerializeField] private Text vitality;
    [SerializeField] private Text charisma;
    [SerializeField] private Text agility;
    [SerializeField] private Text intelligence;
    [SerializeField] private FillBarUI hp;

    void OnEnable(){
        RT = GetComponent<RectTransform>();
        Vector2 pos = new Vector2(Input.mousePosition.x + RT.rect.size.x / 2,Input.mousePosition.y - RT.rect.size.y / 2);
        transform.position = pos;
    }

    void Update(){
        Vector2 pos = new Vector2(Input.mousePosition.x + RT.rect.size.x / 2,Input.mousePosition.y - RT.rect.size.y / 2);
        transform.position = Vector2.Lerp(transform.position,pos,0.25f);
    }

    public void Initialize(Character newCharacter)
    {
        character = newCharacter;
        fullName.text = character.firstName + " " + character.secondName;
        GetComponent<Image>().sprite = character.portrait;
        phyProtection.text = character.phyProtection.ToString();
        magProtection.text = character.magProtection.ToString();
        phyStrength.text = character.phyStrength.ToString();
        magStrength.text = character.magStrength.ToString();
        vitality.text = character.vitality.ToString();
        charisma.text = character.charisma.ToString();
        agility.text = character.agility.ToString();
        intelligence.text = character.intelligence.ToString();
        hp.showMax = true;
        hp.max = character.vitality * 12;
        hp.fillValue = hp.max;
    }
    public void Initialize(FightCharacter newCharacter,bool enemy)
    {
        Initialize(newCharacter.character);

        phyProtection.text = newCharacter.phyProtection.ToString();
        magProtection.text = newCharacter.magProtection.ToString();
        phyStrength.text = newCharacter.phyStrength.ToString();
        magStrength.text = newCharacter.magStrength.ToString();
        vitality.text = newCharacter.vitality.ToString();
        charisma.text = newCharacter.charisma.ToString();
        agility.text = newCharacter.agility.ToString();
        intelligence.text = newCharacter.intelligence.ToString();
        hp.fillValue = newCharacter.HP;

        if(enemy){
            hp.bar.GetComponent<Image>().color = new Color(0.75f,0.0f,0.0f,1.0f);
        }else{
            hp.bar.GetComponent<Image>().color = new Color(0.0f,0.75f,0.0f,1.0f);
        }
    }
}
