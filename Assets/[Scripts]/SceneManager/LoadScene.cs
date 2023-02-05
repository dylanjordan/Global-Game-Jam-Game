using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void LoadScene1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadScene2()
    {
        SceneManager.LoadScene("Level2");
    }

    public void LoadScene3()
    {
        SceneManager.LoadScene("Level3");
    }

    public void Return()
    {
        //SceneManager.LoadScene("");
    }

}
