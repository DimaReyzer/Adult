using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml.Linq;

public class PlayerPortrait : MonoBehaviour
{
    public bool male;
    public Sprite[] mMains;
    public Sprite[] mHairs;
    public Sprite[] mEyes;
    public Sprite[] mEyebrows;
    public Sprite[] mEars;
    public Sprite[] mNoses;
    public Sprite[] mMouthes;
    public Sprite[] fMains;
    public Sprite[] fHairs;
    public Sprite[] fEyes;
    public Sprite[] fEyebrows;
    public Sprite[] fEars;
    public Sprite[] fNoses;
    public Sprite[] fMouthes;
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
        if(!male){
            if(mainChange != null){
                mainChange.SetMax(mMains.Length - 1);
                ChangePlayerMain change = mainChange.gameObject.AddComponent<ChangePlayerMain>();
                change.changeParameter = mainChange;
                change.playerPortrait = this;
                change.Initialize();

            }
            if(hairChange != null){
                hairChange.SetMax(mHairs.Length - 1);
                ChangePlayerHair change = hairChange.gameObject.AddComponent<ChangePlayerHair>();
                change.changeParameter = hairChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(eyeChange != null){
                eyeChange.SetMax(mEyes.Length - 1);
                ChangePlayerEyes change = eyeChange.gameObject.AddComponent<ChangePlayerEyes>();
                change.changeParameter = eyeChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(browsChange != null){
                browsChange.SetMax(mEyebrows.Length - 1);
                ChangePlayerBrows change = browsChange.gameObject.AddComponent<ChangePlayerBrows>();
                change.changeParameter = browsChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(earChange != null){
                earChange.SetMax(mEars.Length - 1);
                ChangePlayerEars change = earChange.gameObject.AddComponent<ChangePlayerEars>();
                change.changeParameter = earChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(noseChange != null){
                noseChange.SetMax(mNoses.Length - 1);
                ChangePlayerNose change = noseChange.gameObject.AddComponent<ChangePlayerNose>();
                change.changeParameter = noseChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(mouthChange != null){
                mouthChange.SetMax(mMouthes.Length - 1);
                ChangePlayerMouth change = mouthChange.gameObject.AddComponent<ChangePlayerMouth>();
                change.changeParameter = mouthChange;
                change.playerPortrait = this;
                change.Initialize();
            }
        }else{
            if(mainChange != null){
                mainChange.SetMax(fMains.Length - 1);
                ChangePlayerMain change = mainChange.gameObject.AddComponent<ChangePlayerMain>();
                change.changeParameter = mainChange;
                change.playerPortrait = this;
                change.Initialize();

            }
            if(hairChange != null){
                hairChange.SetMax(fHairs.Length - 1);
                ChangePlayerHair change = hairChange.gameObject.AddComponent<ChangePlayerHair>();
                change.changeParameter = hairChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(eyeChange != null){
                eyeChange.SetMax(fEyes.Length - 1);
                ChangePlayerEyes change = eyeChange.gameObject.AddComponent<ChangePlayerEyes>();
                change.changeParameter = eyeChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(browsChange != null){
                browsChange.SetMax(fEyebrows.Length - 1);
                ChangePlayerBrows change = browsChange.gameObject.AddComponent<ChangePlayerBrows>();
                change.changeParameter = browsChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(earChange != null){
                earChange.SetMax(fEars.Length - 1);
                ChangePlayerEars change = earChange.gameObject.AddComponent<ChangePlayerEars>();
                change.changeParameter = earChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(noseChange != null){
                noseChange.SetMax(fNoses.Length - 1);
                ChangePlayerNose change = noseChange.gameObject.AddComponent<ChangePlayerNose>();
                change.changeParameter = noseChange;
                change.playerPortrait = this;
                change.Initialize();
            }
            if(mouthChange != null){
                mouthChange.SetMax(fMouthes.Length - 1);
                ChangePlayerMouth change = mouthChange.gameObject.AddComponent<ChangePlayerMouth>();
                change.changeParameter = mouthChange;
                change.playerPortrait = this;
                change.Initialize();
            }
        }
        SetMain(0);
        SetEar(0);
        SetEye(0);
        SetHair(0);
        SetMain(0);
        SetMouth(0);
        SetNose(0);
        SetBrows(0);
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
        if(!male){
            mainSprite = fMains[index];
        }else{
            mainSprite = mMains[index];
        }
        ChangeImage();
    }
    public void SetHair(int index){
        if(!male){
            hairSprite = fHairs[index];
        }else{
            hairSprite = mHairs[index];
        }
        ChangeImage();
    }
    public void SetEye(int index){
        if(!male){
            eyeSprite = fEyes[index];
        }else{
            eyeSprite = mEyes[index];
        }
        ChangeImage();
    }
    public void SetBrows(int index){
        if(!male){
            browsSprite = fEyebrows[index];
        }else{
            browsSprite = mEyebrows[index];
        }
        ChangeImage();
    }
    public void SetEar(int index){
        if(!male){
            earSprite = fEars[index];
        }else{
            earSprite = mEars[index];
        }
        ChangeImage();
    }
    public void SetNose(int index){
        if(!male){
            noseSprite = fNoses[index];
        }else{
            noseSprite = mNoses[index];
        }
        ChangeImage();
    }
    public void SetMouth(int index){
        if(!male){
            mouthSprite = fMouthes[index];
        }else{
            mouthSprite = mMouthes[index];
        }
        ChangeImage();
    }

    public XElement GetElement(){
        string mainAttribute = null;
        if(!male){
            for(int i = 0;i < fMains.Length;i++)
            {
                if(mainSprite == fMains[i]){
                    mainAttribute = i.ToString();
                    break;
                }
            }
        }else{
            for(int i = 0;i < mMains.Length;i++)
            {
                if(mainSprite == mMains[i]){
                    mainAttribute = i.ToString();
                    break;
                }
            }
        }
        XAttribute main = new XAttribute("main",mainAttribute);
        string hairAttribute = null;
        if(!male){
            for(int i = 0;i < fHairs.Length;i++)
            {
                if(hairSprite == fHairs[i]){
                    hairAttribute = i.ToString();
                    break;
                }
            }
        }else{
            for(int i = 0;i < mHairs.Length;i++)
            {
                if(hairSprite == mHairs[i]){
                    hairAttribute = i.ToString();
                    break;
                }
            }
        }
        XAttribute hair = new XAttribute("hair",hairAttribute);
        string eyeAttribute = null;
        if(!male){
            for(int i = 0;i < fEyes.Length;i++)
            {
                if(eyeSprite == fEyes[i]){
                    eyeAttribute = i.ToString();
                    break;
                }
            }
        }else{
            for(int i = 0;i < mEyes.Length;i++)
            {
                if(eyeSprite == mEyes[i]){
                    eyeAttribute = i.ToString();
                    break;
                }
            }
        }
        XAttribute eye = new XAttribute("eyes",eyeAttribute);
        string browsAttribute = null;
        if(!male){
            for(int i = 0;i < fEyebrows.Length;i++)
            {
                if(browsSprite == fEyebrows[i]){
                    browsAttribute = i.ToString();
                    break;
                }
            }
        }else{
            for(int i = 0;i < mEyebrows.Length;i++)
            {
                if(browsSprite == mEyebrows[i]){
                    browsAttribute = i.ToString();
                    break;
                }
            }
        }
        XAttribute brows = new XAttribute("brows",browsAttribute);
        string earsAttribute = null;
        if(!male){
            for(int i = 0;i < fEars.Length;i++)
            {
                if(earSprite == fEars[i]){
                    earsAttribute = i.ToString();
                    break;
                }
            }
        }else{
            for(int i = 0;i < mEars.Length;i++)
            {
                if(earSprite == mEars[i]){
                    earsAttribute = i.ToString();
                    break;
                }
            }
        }
        XAttribute ear = new XAttribute("ear",earsAttribute);
        string noseAttribute = null;
        if(!male){
            for(int i = 0;i < fNoses.Length;i++)
            {
                if(noseSprite == fNoses[i]){
                    noseAttribute = i.ToString();
                    break;
                }
            }
        }else{
            for(int i = 0;i < mNoses.Length;i++)
            {
                if(noseSprite == mNoses[i]){
                    noseAttribute = i.ToString();
                    break;
                }
            }
        }
        XAttribute nose = new XAttribute("nose",noseAttribute);
        string mouthAttribute = null;
        if(!male){
            for(int i = 0;i < fMouthes.Length;i++)
            {
                if(mouthSprite == fMouthes[i]){
                    mouthAttribute = i.ToString();
                    break;
                }
            }
        }else{
            for(int i = 0;i < mMouthes.Length;i++)
            {
                if(mouthSprite == mMouthes[i]){
                    mouthAttribute = i.ToString();
                    break;
                }
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