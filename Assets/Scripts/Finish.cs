using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    [SerializeField] string sceneName;
    public Score varscore;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (varscore.score == 100)
        {
            SceneManager.LoadScene(sceneName);

        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
        
    }
}
