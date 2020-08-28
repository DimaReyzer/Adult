using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New novella character", menuName = "Novella character", order = 53)]
public class NovellaCharacter : ScriptableObject
{
    public string firstName;
    public string secondName;
    public Sprite portrait;
}
