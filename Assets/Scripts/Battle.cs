using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public List<CardUI> cards;
    public Text battleText;
    public FillBarUI FriendHP;
    public FillBarUI EnemyHP;
    private float timer;
    private CardUI move;
    public List<CardUI> turn;
    public GameObject enemy;
    public GameObject friendly;
    void OnEnable(){
        timer = 0;
        CardUI[] locCardsE = enemy.GetComponentsInChildren<CardUI>();
        for (int i = 0;i < locCardsE.Length;i++)
        {
            locCardsE[i].enemy = true;
            cards.Add(locCardsE[i]);
        }
        CardUI[] locCardsF = friendly.GetComponentsInChildren<CardUI>();
        FriendHP.max = 0;
        for (int i = 0;i < locCardsF.Length;i++)
        {
            locCardsF[i].enemy = false;
            cards.Add(locCardsF[i]);
        }
        
        for(int i = 0;i < cards.Count;i++){
            //cards[i].index = i;
            cards[i].battle = this;
        }
        
        EnemyHP.showMax = true;
        FriendHP.showMax = true;
    }
    void Update(){
        if(turn.Count == 0){
            battleText.text = "Who goes first?";
            timer += Time.deltaTime;
            if(timer > 3.0f){
                CreateTurn();
                timer = 0;
            }
        }else{
            move = turn[0];
            battleText.text = move.character.firstName + " is going!";
            if(Input.GetMouseButtonUp(0)){
                move.Attack(FindRandomAttacking(move.enemy));
                turn.RemoveAt(0);
                CalculateHP();
            }
        }
    }
    void CreateTurn(){
        List<CardUI> locInt = new List<CardUI>();
        FriendHP.max = 0;
        EnemyHP.max = 0;
        foreach(CardUI card in cards){
            locInt.Add(card);
        }
        for (int i = 0; i < locInt.Count-1; i++)
        {
            int min = i;
            for (int j = i + 1; j < locInt.Count; j++)
            {
                if (locInt[j].character.intelligence > locInt[min].character.intelligence)
                {
                    min = j;
                }
            }
            CardUI dummy = locInt[i];
            locInt[i] = locInt[min];
            locInt[min] = dummy;
        }
        turn = locInt;
        CalculateHP();
    }
    CardUI FindRandomAttacking(bool enemyChar){
        CardUI answer = null;
        CardUI[] locCardsE = enemy.GetComponentsInChildren<CardUI>();
        CardUI[] locCardsF = friendly.GetComponentsInChildren<CardUI>();
        if(enemyChar){
            answer = locCardsF[Random.Range(0,locCardsF.Length)];
        }else{
            answer = locCardsE[Random.Range(0,locCardsE.Length)];
        }
        return answer;
    }
    void CalculateHP(){
        EnemyHP.max = 0;
        FriendHP.max = 0;
        FriendHP.value = 0;
        EnemyHP.value = 0;
        foreach(CardUI card in cards){
            if(card.enemy){
                EnemyHP.max += card.character.vitality * 12;
            }else{
                FriendHP.max += card.character.vitality * 12;
            }
        }
        foreach(CardUI card in cards){
            if(card.enemy){
                EnemyHP.value += card.hp;
            }else{
                FriendHP.value += card.hp;
            }
        }
    }
}
