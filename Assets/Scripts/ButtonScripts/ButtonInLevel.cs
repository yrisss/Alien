using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    
    public void Helper(GameObject HelpPanel)
    {
        Instantiate(HelpPanel);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
