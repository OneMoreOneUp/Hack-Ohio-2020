using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;      //Used for working with Scenes.

public class LoadScene : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        //Load scene based on the sceneIndex integer, which is set in editor.
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadNext()
    {
        //Load scene based on the next scene index.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Reload()
    {
        //Reload the scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLast()
    {
        //Load the last scene.
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
}
