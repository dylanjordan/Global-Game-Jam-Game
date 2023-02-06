using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    public static int levelsCompleted;

    private void Start()
    {
        //levelsCompleted = 0;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            levelsCompleted++;

            Debug.Log(levelsCompleted);

            if (levelsCompleted < 3)
                SceneManager.LoadScene("ChooseLevel");
            else
                SceneManager.LoadScene("TeethPulling");
        }
    }
}
