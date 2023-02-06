using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public Animator transition;
    
    public void LoadScene1()
    {
        StartCoroutine(LoadLevel("Level 1"));
        
    }

    public void LoadScene2()
    {
        StartCoroutine(LoadLevel("Level 2"));


    }

    public void LoadScene3()
    {
       StartCoroutine(LoadLevel("Level 3"));
       

    }

    public void Return()
    {
        SceneManager.LoadScene("OpenWideMenu");
    }

    IEnumerator LoadLevel(string name)
    {
        
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene(name);
    }

    
}
