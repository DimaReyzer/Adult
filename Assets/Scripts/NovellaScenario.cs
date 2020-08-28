using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New novella scenario", menuName = "Novella scenario", order = 54)]
public class NovellaScenario : ScriptableObject
{
    [System.Serializable]
    public struct answer
    {
        public string text;
        public NovellaScenario scenario;
    }
    [System.Serializable]
    public struct MessageStruct
    {
        public NovellaCharacter character;
        [Multiline(8)]
        public string message;
        public string pause;
        public answer[] answers;
    }
    public List<MessageStruct> dialog;
}
