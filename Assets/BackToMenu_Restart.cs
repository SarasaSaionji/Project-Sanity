using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenu_Restart : MonoBehaviour
{
    public void GoToMainMenu()
    {

        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync(0);
    }
}
