using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public List<FightCharacter> friends;
    public List<FightCharacter> enemies;
    public Text battleText;
    public FillBarUI FriendHP;
    public FillBarUI EnemyHP;
    public FightCharacter move{
        get{
            return moving;
        }set{
            SetCharactersPositions();
            if(value != null){
                moving = value;
                moving.pos = Vector2.zero;
                if(moving.enemy){
                    moving.AttackFriend();
                }
            }
        }
    }
    private FightCharacter moving;
    public List<FightCharacter> turn;
    /*public Battle(List<Character> friends, List<Character> enemies){
        AddFriends(friends);
        AddEnemies(enemies);
    }*/
    [SerializeField] private FightCharacter fightCharExample;
    [SerializeField] private List<Character> startFriends;
    [SerializeField] private List<Character> startEnemies;
    void OnEnable(){
        AddFriends(startFriends);
        AddEnemies(startEnemies);
        SetCharactersPositions();
        StartCoroutine(WaitMove());
    }
    void Update(){

    }
    void CreateTurn(){
        List<FightCharacter> locInt = new List<FightCharacter>();
        foreach(FightCharacter card in FightCharacters()){
            locInt.Add(card);
        }
        for (int i = 0; i < locInt.Count-1; i++)
        {
            int min = i;
            for (int j = i + 1; j < locInt.Count; j++)
            {
                if (locInt[j].character.intelligence * Random.Range(0.9f,1.1f) > locInt[min].character.intelligence * Random.Range(0.9f,1.1f))
                {
                    min = j;
                }
            }
            FightCharacter dummy = locInt[i];
            locInt[i] = locInt[min];
            locInt[min] = dummy;
        }
        turn = locInt;
        CalculateHP();
    }
    FightCharacter FindRandomAttacking(bool enemyChar){
        List<FightCharacter> characters = FightCharacters();
        foreach(FightCharacter character in characters){
            if(character.enemy != enemyChar){
                characters.Remove(character);
            }
        }
        FightCharacter answer = characters[Random.Range(0,characters.Count)];
        return answer;
    }
    void CalculateHP(){
        EnemyHP.max = 0;
        FriendHP.max = 0;
        FriendHP.value = 0;
        EnemyHP.value = 0;
        foreach(FightCharacter card in FightCharacters()){
            if(card.enemy){
                EnemyHP.max += card.character.vitality * 12;
            }else{
                FriendHP.max += card.character.vitality * 12;
            }
        }
        foreach(FightCharacter card in FightCharacters()){
            if(card.enemy){
                EnemyHP.value += card.HP;
            }else{
                FriendHP.value += card.HP;
            }
        }
    }

    void AddFriends(List<Character> characters){
        for(int i = 0;i < Mathf.Clamp(characters.Count,0,4);i++){
            FightCharacter instChar = Instantiate<FightCharacter>(fightCharExample);
            instChar.Initialize(characters[i],false);
            instChar.transform.SetParent(transform);
            friends.Add(instChar);
            instChar.battle = this;
            instChar.name = instChar.character.firstName;
        }
    }

    void AddEnemies(List<Character> characters){
        for(int i = 0;i < Mathf.Clamp(characters.Count,0,4);i++){
            FightCharacter instChar = Instantiate<FightCharacter>(fightCharExample);
            instChar.Initialize(characters[i],true);
            instChar.transform.SetParent(transform);
            enemies.Add(instChar);
            instChar.battle = this;
            instChar.name = instChar.character.firstName;
        }
    }
    IEnumerator WaitMove(){
        SetCharactersPositions();
        yield return new WaitForSeconds(2.0f);
        if(turn.Count == 0){
            CreateTurn();
        }
        move = turn[0];
        if(!move.enemy){
            foreach(FightCharacter friend in friends){
                if(friend != move){
                    friend.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,0.5f);
                }else{
                    friend.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            foreach(FightCharacter enemy in enemies){
                enemy.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }else{
            foreach(FightCharacter enemy in enemies){
                if(enemy != move){
                    enemy.GetComponent<SpriteRenderer>().color = new Color(1.0f,1.0f,1.0f,0.5f);
                }else{
                    enemy.GetComponent<SpriteRenderer>().color = Color.white;
                }
            }
            foreach(FightCharacter friend in friends){
                friend.GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }

    public void OnAttack(){
        turn.Remove(move);
        moving = null;
        StartCoroutine(WaitMove());
    }

    List<FightCharacter> FightCharacters(){
        List<FightCharacter> answer = new List<FightCharacter>();
        foreach(FightCharacter character in friends){
            answer.Add(character);
            if(answer.Count >= 4){
                break;
            }
        }
        foreach(FightCharacter character in enemies){
            answer.Add(character);
            if(answer.Count >= 8){
                break;
            }
        }
        return answer;
    }

    void SetCharactersPositions(){
        //Enemies
        for(int i = 0;i < Mathf.Clamp(enemies.Count,0,4);i++){
            FightCharacter instChar = enemies[i];
            if(enemies.Count >= 4){
                if(i == 0){
                    instChar.pos = new Vector2(10,-3);
                }else if(i == 1){
                    instChar.pos = new Vector2(10,3);
                }else if(i == 2){
                    instChar.pos = new Vector2(5,-7);
                }else if(i == 3){
                    instChar.pos = new Vector2(5,7);
                }
            }else if(enemies.Count == 3){
                if(i == 0){
                    instChar.pos = new Vector2(5,0);
                }else if(i == 1){
                    instChar.pos = new Vector2(5,-7);
                }else if(i == 2){
                    instChar.pos = new Vector2(5,7);
                }
            }else if(enemies.Count == 2){
                if(i == 0){
                    instChar.pos = new Vector2(5,3.5f);
                }else if(i == 1){
                    instChar.pos = new Vector2(5,-3.5f);
                }
            }else{
                instChar.pos = new Vector2(5,0);
            }
        }
        //Friends
        for(int i = 0;i < Mathf.Clamp(friends.Count,0,4);i++){
            FightCharacter instChar = friends[i];
            if(friends.Count >= 4){
                if(i == 0){
                    instChar.pos = new Vector2(-10,-3);
                }else if(i == 1){
                    instChar.pos = new Vector2(-10,3);
                }else if(i == 2){
                    instChar.pos = new Vector2(-5,-7);
                }else if(i == 3){
                    instChar.pos = new Vector2(-5,7);
                }
            }else if(friends.Count == 3){
                if(i == 0){
                    instChar.pos = new Vector2(-5,0);
                }else if(i == 1){
                    instChar.pos = new Vector2(-5,-7);
                }else if(i == 2){
                    instChar.pos = new Vector2(-5,7);
                }
            }else if(friends.Count == 2){
                if(i == 0){
                    instChar.pos = new Vector2(-5,3.5f);
                }else if(i == 1){
                    instChar.pos = new Vector2(-5,-3.5f);
                }
            }else{
                instChar.pos = new Vector2(-5,0);
            }
        }
    }
}
