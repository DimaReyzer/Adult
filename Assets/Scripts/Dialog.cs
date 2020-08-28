using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    public Dialog(NovellaScenario novScenario){
        scenario = novScenario;
    }
    public NovellaScenario scenario;
    public int pageNumber{
        get{
            return page;
        }set{
            if(value < scenario.dialog.Count && !printing){
                page = value;
                ChangeMessage();
            }
        }
    }
    public float printingSpeed = 0.005f;
    public string localMessage{
        get{
            return locMessage;
        }set{
            if(!printing){
                locMessage = value;
                StartCoroutine(PrintingEffect(localMessage));
            }
        }
    }
    private int page = -1;
    private bool wait;
    private string locMessage;
    private bool printing;
    private Vector3 personPos;
    [SerializeField] private Image personImage;
    [SerializeField] private Text personText;
    [SerializeField] private Text message;
    [SerializeField] private Button answer;
    [SerializeField] private GameObject answers;
    [SerializeField] private Scrollbar scrollbar;
    [SerializeField] private ScrollRect scroll;

    void OnEnable(){
        Move();
        personPos = personImage.rectTransform.position;
        personImage.rectTransform.position = new  Vector3(-personImage.rectTransform.position.x,personImage.rectTransform.position.y,personImage.rectTransform.position.z);
    }

    void Update(){
        if(personImage.rectTransform.position != personPos){
            personImage.rectTransform.position = Vector3.Lerp(personImage.rectTransform.position,personPos,0.0625f);
        }
    }

    void Move(){
        if(!printing){
            StartCoroutine(WaitDialog());
        }
    }

    void ChangeMessage(){
        message.rectTransform.sizeDelta = new Vector2(message.rectTransform.sizeDelta.x,90);

        foreach(Transform child in answers.transform){
            Destroy(child.gameObject);
        }
        
        RectTransform locRect = message.GetComponent<RectTransform>();
        locRect.sizeDelta = new Vector2(locRect.sizeDelta.x,locRect.sizeDelta.y);
        NovellaCharacter character = scenario.dialog[pageNumber].character;
        personImage.sprite = character.portrait;
        personText.text = character.firstName + " " + character.secondName;
        string thisMessage = RemoveNewLines(scenario.dialog[pageNumber].message);
        localMessage = thisMessage;

        /*locRect.sizeDelta = new Vector2(locRect.sizeDelta.x,message.cachedTextGenerator.lineCount * 21);
        Debug.Log(message.cachedTextGenerator.lineCount);*/
    }

    IEnumerator WaitDialog(){
        if(pageNumber > -1){
            wait = (scenario.dialog[pageNumber].pause == "") ? false : true;
            if(wait){ 
                message.text = "(" + scenario.dialog[pageNumber].pause + ")";
                foreach(Transform child in answers.transform){
                    Destroy(child.gameObject);
                }
                yield return new WaitForSeconds(3);
                foreach(Transform child in answers.transform){
                    Destroy(child.gameObject);
                }
            }
        }
        pageNumber++;
    }

    public static string RemoveNewLines(string example){
        string answer = example.Replace("\n", "").Replace("\r", "");
        return answer;
    }
    public void ChangeScenario(int index){
        if(index != -1){
            NovellaScenario scen = scenario.dialog[pageNumber].answers[index].scenario;
            if(scen == null){
                if(pageNumber + 1 >= scenario.dialog.Count){
                    EndDialog();
                }else{
                    Move();
                }
            }else{
                scenario = scen;
                pageNumber = 0;
                GameObject thisGO = gameObject;
                GameObject newDialog = Instantiate<GameObject>(thisGO);
                thisGO.transform.SetParent(thisGO.transform.parent);
                Destroy(gameObject);
            }
        }else{
            if(pageNumber + 1 >= scenario.dialog.Count){
                EndDialog();
            }else{
                Move();
            }
        }
    }
    public IEnumerator PrintingEffect(string text)
    {
        message.text = "";
        foreach (char letter in text)
        {
            printing = true;
            yield return new WaitForSeconds(printingSpeed);
            message.text += letter;
        }
        InstAnswers();
        printing = false;
    }

    void EndDialog(){
        Debug.Log("Dialog is end");
    }

    void InstAnswers(){
        int lines = message.cachedTextGenerator.lineCount;
        //message.rectTransform.sizeDelta = new Vector2(message.rectTransform.sizeDelta.x,lines * 21);
        RectTransform RectT = scroll.GetComponent<RectTransform>();
        float height = Mathf.Clamp(90 - (lines - 1) * 21,30,90);
        RectT.sizeDelta = new Vector2(RectT.sizeDelta.x,height);
        
        foreach(Transform child in answers.transform){
            Destroy(child.gameObject);
        }

        NovellaScenario.answer[] localAnswers = scenario.dialog[page].answers;
        if(localAnswers.Length > 0){
            for(int i = 0;i < localAnswers.Length;i++){
                Button instButton = Instantiate<Button>(answer);
                instButton.transform.SetParent(answers.transform);
                Text localText = instButton.GetComponentInChildren<Text>();
                localText.text = localAnswers[i].text;
                RectTransform RT = instButton.GetComponent<RectTransform>();
                RT.sizeDelta = new Vector2(RT.sizeDelta.x,30);
                Answer ans = instButton.gameObject.AddComponent<Answer>();
                ans.index = i;
                ans.button = instButton;
                ans.dialog = this;
            }
            if(localAnswers.Length > 1){
                HideScrollbar(scrollbar,scroll,true);
            }else{
                HideScrollbar(scrollbar,scroll,false);
            }
        }else{
            Button instButton = Instantiate<Button>(answer);
            Text localText = instButton.GetComponentInChildren<Text>();
            localText.text = "...";
            instButton.transform.SetParent(answers.transform);
            RectTransform RT = instButton.GetComponent<RectTransform>();
            RT.sizeDelta = new Vector2(RT.sizeDelta.x,30);

            Answer ans = instButton.gameObject.AddComponent<Answer>();
            ans.index = -1;
            ans.button = instButton;
            ans.dialog = this;
        }
    }

    public class Answer : MonoBehaviour{
        public int index = -1;
        public Button button;
        public Dialog dialog;
        void OnEnable(){
            button = GetComponent<Button>();
            button.onClick.AddListener(ChangeNovScenario);
        }
        void ChangeNovScenario(){
            dialog.ChangeScenario(index);
        }
    }

    public void HideScrollbar(Scrollbar scrollbar, ScrollRect scrollRect, bool show){
        if(show){
            scrollRect.enabled = true;
            scrollbar.gameObject.SetActive(true);
        }else{
            scrollRect.enabled = false;
            scrollbar.gameObject.SetActive(false);
        }
    }
}
