using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New mob", menuName = "Mob", order = 52)]
public class Mob : Character
{
    public int range;
    void OnEnable(){
        phyStrength = phyStrength + Mathf.RoundToInt(Random.Range(-phyStrength * 0.1f,phyStrength * 0.1f));
        magStrength = magStrength + Mathf.RoundToInt(Random.Range(-magStrength * 0.1f,magStrength * 0.1f));
        phyProtection = phyProtection + Mathf.RoundToInt(Random.Range(-phyProtection * 0.1f,phyProtection * 0.1f));
        magProtection = magProtection + Mathf.RoundToInt(Random.Range(-magProtection * 0.1f,magProtection * 0.1f));
        vitality = vitality + Mathf.RoundToInt(Random.Range(-vitality * 0.1f,vitality * 0.1f));
        charisma = charisma + Mathf.RoundToInt(Random.Range(-charisma * 0.1f,charisma * 0.1f));
        agility = agility + Mathf.RoundToInt(Random.Range(-agility * 0.1f,agility * 0.1f));
        intelligence = intelligence + Mathf.RoundToInt(Random.Range(-intelligence * 0.1f,intelligence * 0.1f));
    }
}
