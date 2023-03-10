using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] int goodTeeth = 0;
    [SerializeField] int badTeeth = 0;
    public int goodScene;
    public int midScene;
    public int badScene;


    private void Update()
    {
        if ((goodTeeth + badTeeth) == 3)
        {
            StartCoroutine(ToothDelay());
        }
    }

    public void GoodPull()
    {
        goodTeeth++;
    }

    public void BadPull()
    {
        badTeeth++;
    }

    public void PickEnding()
    {
        if (goodTeeth == 3)
        {
            SceneManager.LoadScene(goodScene);
        }
        if (goodTeeth >= 1 && badTeeth >= 1)
        {
            SceneManager.LoadScene(midScene);
        }
        if (badTeeth == 3)
        {
            SceneManager.LoadScene(badScene);
        }
    }

    IEnumerator ToothDelay()
    {
        yield return new WaitForSeconds(1f);
        PickEnding();
    }
}
