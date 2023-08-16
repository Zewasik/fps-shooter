using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadLevel(string sceneToLoad)
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
