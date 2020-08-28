using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightCharacter : MonoBehaviour
{
    public Character character;
    public int HP{
        get{
            return healthPoints;
        }set{
            healthPoints = Mathf.Clamp(healthPoints + value,0,character.vitality * 12);
        }
    }
    public int phyStrength;
    public int magStrength;
    public int phyProtection;
    public int magProtection;
    public int vitality;
    public int charisma;
    public int agility;
    public int intelligence;

    private int healthPoints;
    private SpriteRenderer sprite;
    private bool enemy;

    public FightCharacter(Character newCharacter,bool newEnemy){
        character = newCharacter;
        enemy = newEnemy;
    }

    void OnEnable(){
        sprite = GetComponent<SpriteRenderer>();
        sprite.sprite =character.fightExample;
        InitializeParameters();
    }

    void InitializeParameters(){
        healthPoints = character.vitality * 12;
        phyStrength = character.phyStrength;
        magStrength = character.magStrength;
        phyProtection = character.phyProtection;
        magProtection = character.magProtection;
        vitality = character.vitality;
        charisma = character.charisma;
        agility = character.agility;
        intelligence = character.intelligence;
    }
}
