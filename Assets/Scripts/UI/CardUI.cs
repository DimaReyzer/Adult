using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class CardUI : MonoBehaviour
{
    public Battle battle;
    public Character character;
    public Text charName;
    public Text parameters;
    public Text phy;
    public Text mag;
    public FillBarUI hpText;
    public int hp;
    public bool enemy;
    void OnEnable(){
        charName.text = character.firstName;
        parameters.text = "Vitality(" + character.vitality.ToString() + ")\n"
        + "Charisma(" + character.charisma.ToString() + ")\n"
        + "Agility(" + character.agility.ToString() + ")\n"
        + "Intelligence(" + character.intelligence.ToString() + ")";
        phy.text = "Strength(" + character.phyStrength.ToString() + ")\n"
        + "Protection(" + character.phyProtection.ToString() + ")";
        mag.text = "Strength(" + character.magStrength.ToString() + ")\n"
        + "Protection(" + character.magProtection.ToString() + ")";
        GetComponent<Image>().sprite = character.portrait;
        hp = character.vitality * 12;
        hpText.max = hp;

        /*if(enemy){
            battle.EnemyHP.max += hp;
            battle.EnemyHP.value += hp;
        }else{
            battle.FriendHP.max += hp;
            battle.FriendHP.value += hp;
        }*/
    }
    void Update(){
        hpText.value = hp;
        if(hp <= 0){
            Destroy(gameObject);
        }
    }
    public void Attack(CardUI attackCard){
        float evasion = 0.001f * attackCard.character.agility;
        if(Random.Range(0.0f,1.0f) > evasion){
            int phyDamage = Mathf.RoundToInt(character.phyStrength - character.phyStrength * (0.005f * attackCard.character.phyProtection));
            int magDamage = Mathf.RoundToInt(character.magStrength - character.magStrength * (0.005f * attackCard.character.magProtection));
            float crit = 0.001f * character.agility;
            int damage = (phyDamage + magDamage) + Mathf.RoundToInt(Random.Range(-(phyDamage + magDamage) * 0.1f,(phyDamage + magDamage) * 0.1f));
            if(Random.Range(0.0f,1.0f) > crit){
                attackCard.hp -= damage;
                Debug.Log(attackCard.character.firstName + " - получает " + damage.ToString() + " урона!");
            }else{
                attackCard.hp -= damage * 3;
                Debug.Log(attackCard.character.firstName + " - получает " + (damage * 3).ToString() + " критического урона!");
            }
        }else{
            Debug.Log(attackCard.character.firstName + " - уклонился!");
        }
    }
    void OnDisable(){
        battle.cards.Remove(this);
        battle.turn.Remove(this);
    }
}
