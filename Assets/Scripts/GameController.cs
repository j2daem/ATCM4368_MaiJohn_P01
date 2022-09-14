using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    private void Update()
    {
        ResetScene();
        ExitGame();
    }

    #region Scene Controls
    public void ResetScene()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Debug.Log("Reset level.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void ExitGame()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Exited game.");
            Application.Quit();
        }
    }
    #endregion
}
