using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FightCharacter : MonoBehaviour
{
    public Battle battle;
    public Character character;
    public int HP{
        get{
            return healthPoints;
        }set{
            healthPoints = Mathf.Clamp(value,0,character.vitality * 12);
            barUI.value = healthPoints;
            if(healthPoints <= 0){
                Die();
            }
        }
    }
    public bool enemy{
        get{
            return en;
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
    public Vector2 pos;

    [SerializeField] private int healthPoints;
    private SpriteRenderer sprite;
    [SerializeField] private bool en;
    [SerializeField] private FillBarUI barUI;
    [SerializeField] private Interface playerInterface;
    [SerializeField] private SkillsLayoutUI skills;

    public void Initialize(Character newCharacter,bool newEnemy){
        character = newCharacter;
        en = newEnemy;
        sprite = GetComponent<SpriteRenderer>();
        barUI = GetComponentInChildren<FillBarUI>();
        barUI.max = character.vitality * 12;
        HP = character.vitality * 12;
        sprite.sprite = character.fightExample;
        InitializeParameters();
        if(enemy){
            sprite.flipX = true;
            barUI.bar.GetComponent<Image>().color = new Color(0.75f,0.0f,0.0f,1.0f);
        }else{
            barUI.bar.GetComponent<Image>().color = new Color(0.0f,0.75f,0.0f,1.0f);
        }
    }

    void OnEnable(){
        playerInterface = FindObjectOfType<Interface>();
    }

    void Update(){
        transform.position = Vector2.Lerp(transform.position,pos,0.25f);
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

    void Die(){
        Destroy(gameObject);
    }
    public void Attack(FightCharacter character){
        if(enemy != character.enemy){
            int damage = Damage(this, character);
            character.HP -= damage;
            battle.OnAttack();
        }
    }

    int Damage(FightCharacter character, FightCharacter target){
        float answer = 0;
        float phyAttack = (character.phyStrength * 3) * Random.Range(0.9f,1.1f);
        phyAttack = phyAttack - (phyAttack * target.phyProtection * 0.005f);
        float magAttack = (character.magStrength * 3) * Random.Range(0.9f,1.1f);
        magAttack = magAttack - (magAttack * target.magProtection * 0.005f);

        answer = phyAttack + magAttack;
        float evasion = Random.Range(0.0f,1.0f);
        if(evasion <= target.agility * 0.001f){
            Debug.Log(target.name + " dodged from " + character.name + " attack!");
            return 0;
        }else{
            float crit = Random.Range(0.0f,1.0f);
            if(crit <= character.agility * 0.001f){
                answer = answer * 3;
                int damage = Mathf.RoundToInt(answer);
                damage = Mathf.Abs(damage);
                Debug.Log(target.name + " has taken " + damage.ToString() + " critical damage from " + character.name + " attack!");
                return damage;
            }else{
                int damage = Mathf.RoundToInt(answer);
                damage = Mathf.Abs(damage);
                Debug.Log(target.name + " has taken " + damage.ToString() + " damage from " + character.name + " attack!");
                return damage;
            }
        }
    }

    int Damage(FightCharacter target){
        float answer = 0;
        float phyAttack = (character.phyStrength * 3) * Random.Range(0.9f,1.1f);
        phyAttack = phyAttack - (phyAttack * target.phyProtection * 0.005f);
        float magAttack = (character.magStrength * 3) * Random.Range(0.9f,1.1f);
        magAttack = magAttack - (magAttack * target.magProtection * 0.005f);

        answer = phyAttack + magAttack;
        float evasion = Random.Range(0.0f,1.0f);
        if(evasion <= target.agility * 0.001f){
            Debug.Log(target.name + " dodged from " + character.name + " attack!");
            return 0;
        }else{
            float crit = Random.Range(0.0f,1.0f);
            if(crit <= character.agility * 0.001f){
                answer = answer * 3;
                int damage = Mathf.RoundToInt(answer);
                damage = Mathf.Abs(damage);
                Debug.Log(target.name + " has taken " + damage.ToString() + " critical damage from " + character.name + " attack!");
                return damage;
            }else{
                int damage = Mathf.RoundToInt(answer);
                damage = Mathf.Abs(damage);
                Debug.Log(target.name + " has taken " + damage.ToString() + " damage from " + character.name + " attack!");
                return damage;
            }
        }
    }

    public void AttackFriend(){
        if(enemy){
            StartCoroutine(AI());
        }
    }

    IEnumerator AI(){
        yield return new WaitForSeconds(2.0f);
        List<int> ints = new List<int>(); 
        for(int i = 0;i < battle.friends.Count;i++){
            int answer = 0;
            FightCharacter friend = battle.friends[i];
            answer += Damage(friend);
            if(friend.HP >= Damage(friend)){
                answer = answer * 2;
            }

            int friendPower = battle.friends[i].phyStrength +
            battle.friends[i].phyProtection + 
            battle.friends[i].magStrength +
            battle.friends[i].magProtection + 
            battle.friends[i].vitality +
            battle.friends[i].charisma + 
            battle.friends[i].agility +
            battle.friends[i].intelligence;
            
            answer += friendPower / 4;
        }
        int target = 0;
        int score = 0;
        for(int i = 0;i < ints.Count;i++){
            if(ints[i] > score){
                score = ints[i];
                target = i;
            }
        }
        Attack(battle.friends[target]);
    }

    void OnMouseEnter()
    {
        playerInterface.ShowCharacterInfo(this,true);
    }
    void OnMouseExit()
    {
        playerInterface.ShowCharacterInfo(this,false);
    }
    void OnDisable(){
        playerInterface.ShowCharacterInfo(this,false);
        if(enemy){
            battle.enemies.Remove(this);
        }else{
            battle.friends.Remove(this);
        }
        battle.turn.Remove(this);
    }
    void OnMouseDown(){
        if(battle.move != null && !battle.move.enemy){
            battle.move.Attack(this);
        }
        if(!skills.gameObject.activeSelf){
            skills.gameObject.SetActive(true);
        }else{
            skills.gameObject.SetActive(false);
        }
    }
}
