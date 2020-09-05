using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface : MonoBehaviour
{
    public CharacterInfoUI characterInfoPanel;
    [SerializeField] private CharacterInfoUI currInfo;
    void OnEnable(){
        CharacterInfoUI instCharInfo = Instantiate<CharacterInfoUI>(characterInfoPanel);
        currInfo = instCharInfo;
        currInfo.transform.SetParent(transform);
        currInfo.gameObject.SetActive(false);
    }
    public void ShowCharacterInfo(FightCharacter character, bool open){
        if(character != null)
        {
            currInfo.gameObject.SetActive(open);
            currInfo.Initialize(character,character.enemy);
        }else{
            currInfo.gameObject.SetActive(false);
        }
    }
}
