using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;

public class PlayerPortrait : MonoBehaviour
{
    public Sprite[] mains;
    public Sprite[] hairs;
    public Sprite[] eyes;
    public Sprite[] eyebrows;
    public Sprite[] ears;
    public Sprite[] noses;
    public Sprite[] mouthes;
    public Image main;
    public Image hair;
    public Image eye;
    public Image brows;
    public Image ear;
    public Image nose;
    public Image mouth;
    [SerializeField] private Sprite mainSprite;
    [SerializeField] private Sprite hairSprite;
    [SerializeField] private Sprite eyeSprite;
    [SerializeField] private Sprite browsSprite;
    [SerializeField] private Sprite earSprite;
    [SerializeField] private Sprite noseSprite;
    [SerializeField] private Sprite mouthSprite;
    [SerializeField] private ChangeParameter mainChange;
    [SerializeField] private ChangeParameter hairChange;
    [SerializeField] private ChangeParameter eyeChange;
    [SerializeField] private ChangeParameter browsChange;
    [SerializeField] private ChangeParameter earChange;
    [SerializeField] private ChangeParameter noseChange;
    [SerializeField] private ChangeParameter mouthChange;
    void OnEnable(){
        if(mainChange != null){
            mainChange.SetMax(mains.Length - 1);
            ChangePlayerMain change = mainChange.gameObject.AddComponent<ChangePlayerMain>();
            change.changeParameter = mainChange;
            change.playerPortrait = this;
            change.Initialize();

        }
        if(hairChange != null){
            hairChange.SetMax(hairs.Length - 1);
            ChangePlayerHair change = hairChange.gameObject.AddComponent<ChangePlayerHair>();
            change.changeParameter = hairChange;
            change.playerPortrait = this;
            change.Initialize();
        }
        if(eyeChange != null){
            eyeChange.SetMax(eyes.Length - 1);
            ChangePlayerEyes change = eyeChange.gameObject.AddComponent<ChangePlayerEyes>();
            change.changeParameter = eyeChange;
            change.playerPortrait = this;
            change.Initialize();
        }
        if(browsChange != null){
            browsChange.SetMax(eyebrows.Length - 1);
            ChangePlayerBrows change = browsChange.gameObject.AddComponent<ChangePlayerBrows>();
            change.changeParameter = browsChange;
            change.playerPortrait = this;
            change.Initialize();
        }
        if(earChange != null){
            earChange.SetMax(ears.Length - 1);
            ChangePlayerEars change = earChange.gameObject.AddComponent<ChangePlayerEars>();
            change.changeParameter = earChange;
            change.playerPortrait = this;
            change.Initialize();
        }
        if(noseChange != null){
            noseChange.SetMax(noses.Length - 1);
            ChangePlayerNose change = noseChange.gameObject.AddComponent<ChangePlayerNose>();
            change.changeParameter = noseChange;
            change.playerPortrait = this;
            change.Initialize();
        }
        if(mouthChange != null){
            mouthChange.SetMax(mouthes.Length - 1);
            ChangePlayerMouth change = mouthChange.gameObject.AddComponent<ChangePlayerMouth>();
            change.changeParameter = mouthChange;
            change.playerPortrait = this;
            change.Initialize();
        }
        ChangeImage();
    }

    void ChangeImage(){
        main.sprite = mainSprite;
        hair.sprite = hairSprite;
        eye.sprite = eyeSprite;
        brows.sprite = browsSprite;
        ear.sprite = earSprite;
        nose.sprite = noseSprite;
        mouth.sprite = mouthSprite;
    }

    public void SetMain(int index){
        mainSprite = mains[index];
        ChangeImage();
    }
    public void SetHair(int index){
        hairSprite = hairs[index];
        ChangeImage();
    }
    public void SetEye(int index){
        eyeSprite = eyes[index];
        ChangeImage();
    }
    public void SetBrows(int index){
        browsSprite = eyebrows[index];
        ChangeImage();
    }
    public void SetEar(int index){
        earSprite = ears[index];
        ChangeImage();
    }
    public void SetNose(int index){
        noseSprite = noses[index];
        ChangeImage();
    }
    public void SetMouth(int index){
        mouthSprite = mouthes[index];
        ChangeImage();
    }

    public XElement GetElement(){
        string mainAttribute = null;
        for(int i = 0;i < mains.Length;i++)
        {
            if(mainSprite == mains[i]){
                mainAttribute = i.ToString();
                break;
            }
        }
        XAttribute main = new XAttribute("main",mainAttribute);
        string hairAttribute = null;
        for(int i = 0;i < hairs.Length;i++)
        {
            if(hairSprite == hairs[i]){
                hairAttribute = i.ToString();
                break;
            }
        }
        XAttribute hair = new XAttribute("hair",hairAttribute);
        string eyeAttribute = null;
        for(int i = 0;i < eyes.Length;i++)
        {
            if(eyeSprite == eyes[i]){
                eyeAttribute = i.ToString();
                break;
            }
        }
        XAttribute eye = new XAttribute("eyes",eyeAttribute);
        string browsAttribute = null;
        for(int i = 0;i < eyebrows.Length;i++)
        {
            if(browsSprite == eyebrows[i]){
                browsAttribute = i.ToString();
                break;
            }
        }
        XAttribute brows = new XAttribute("brows",browsAttribute);
        string earsAttribute = null;
        for(int i = 0;i < ears.Length;i++)
        {
            if(earSprite == ears[i]){
                earsAttribute = i.ToString();
                break;
            }
        }
        XAttribute ear = new XAttribute("ear",earsAttribute);
        string noseAttribute = null;
        for(int i = 0;i < noses.Length;i++)
        {
            if(noseSprite == noses[i]){
                noseAttribute = i.ToString();
                break;
            }
        }
        XAttribute nose = new XAttribute("nose",noseAttribute);
        string mouthAttribute = null;
        for(int i = 0;i < mouthes.Length;i++)
        {
            if(mouthSprite == mouthes[i]){
                mouthAttribute = i.ToString();
                break;
            }
        }
        XAttribute mouth = new XAttribute("mouth",mouthAttribute);

        XElement element = new XElement("playerPortrait",name,main,hair,eye,brows,ear,nose,mouth);

        return element;
    }
}
public class ChangePlayerMain : MonoBehaviour{
    public ChangeParameter changeParameter;
    public PlayerPortrait playerPortrait;
    public void Initialize(){
        changeParameter.onClick.AddListener(ChangeMain);
    }
    void ChangeMain(){
        playerPortrait.SetMain(changeParameter.value);
    }
}

public class ChangePlayerHair : MonoBehaviour{
    public ChangeParameter changeParameter;
    public PlayerPortrait playerPortrait;
    public void Initialize(){
        changeParameter.onClick.AddListener(ChangeMain);
    }
    void ChangeMain(){
        playerPortrait.SetHair(changeParameter.value);
    }
}


public class ChangePlayerEyes : MonoBehaviour{
    public ChangeParameter changeParameter;
    public PlayerPortrait playerPortrait;
    public void Initialize(){
        changeParameter.onClick.AddListener(ChangeMain);
    }
    void ChangeMain(){
        playerPortrait.SetEye(changeParameter.value);
    }
}
public class ChangePlayerBrows : MonoBehaviour{
    public ChangeParameter changeParameter;
    public PlayerPortrait playerPortrait;
    public void Initialize(){
        changeParameter.onClick.AddListener(ChangeMain);
    }
    void ChangeMain(){
        playerPortrait.SetBrows(changeParameter.value);
    }
}
public class ChangePlayerEars : MonoBehaviour{
    public ChangeParameter changeParameter;
    public PlayerPortrait playerPortrait;
    public void Initialize(){
        changeParameter.onClick.AddListener(ChangeMain);
    }
    void ChangeMain(){
        playerPortrait.SetEar(changeParameter.value);
    }
}
public class ChangePlayerNose : MonoBehaviour{
    public ChangeParameter changeParameter;
    public PlayerPortrait playerPortrait;
    public void Initialize(){
        changeParameter.onClick.AddListener(ChangeMain);
    }
    void ChangeMain(){
        playerPortrait.SetNose(changeParameter.value);
    }
}
public class ChangePlayerMouth : MonoBehaviour{
    public ChangeParameter changeParameter;
    public PlayerPortrait playerPortrait;
    public void Initialize(){
        changeParameter.onClick.AddListener(ChangeMain);
    }
    void ChangeMain(){
        playerPortrait.SetMouth(changeParameter.value);
    }
}