using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public int wood{
        get{
            return woodResource;
        }set{
            woodResource = value;
        }
    }
    public int stone{
        get{
            return stoneResource;
        }set{
            stoneResource = value;
        }
    }
    public int food{
        get{
            return foodResource;
        }set{
            foodResource = value;
        }
    }
    public int metal{
        get{
            return metalResource;
        }set{
            metalResource = value;
        }
    }
    public int gold{
        get{
            return goldResource;
        }set{
            goldResource = value;
        }
    }

    [SerializeField] private int woodResource = 0;
    [SerializeField] private int stoneResource = 0;
    [SerializeField] private int foodResource = 0;
    [SerializeField] private int metalResource = 0;
    [SerializeField] private int goldResource = 0;
}
