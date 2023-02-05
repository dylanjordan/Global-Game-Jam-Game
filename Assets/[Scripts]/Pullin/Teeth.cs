using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teeth : MonoBehaviour
{

    public Sprite fixedSprite;

    ScoreManager scoreManager;

    public enum ToothType
    {
        GOOD,
        BAD
    }

    public ToothType type;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();    
    }

    public void IsSaved()
    {
        if (type == ToothType.GOOD)
        {
            scoreManager.GoodPull();
        }
        if (type == ToothType.BAD)
        {
            scoreManager.BadPull();
        }
    }

    public void IsPulled()
    {
        if (type == ToothType.GOOD)
        {
            scoreManager.BadPull();
        }
        if (type == ToothType.BAD)
        {
            scoreManager.GoodPull();
        }
    }

    public Sprite GetFixedTooth()
    {
        return fixedSprite;
    }
}
