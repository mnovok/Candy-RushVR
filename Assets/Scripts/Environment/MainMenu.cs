using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadDifficulty(int difficultyIndex)
    {
        SceneManager.LoadScene(difficultyIndex);
    }
}
