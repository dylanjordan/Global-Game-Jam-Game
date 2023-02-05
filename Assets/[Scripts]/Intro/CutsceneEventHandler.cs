using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneEventHandler : MonoBehaviour
{
    public void GoToLevelSelect()
    {
        SceneManager.LoadScene("OpenWideMenu");
    }
}
