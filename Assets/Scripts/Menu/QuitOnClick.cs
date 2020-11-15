using UnityEngine;

public class QuitOnClick : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        //If it is playing in the Unity Editor then stop playing.
        UnityEditor.EditorApplication.isPlaying = false;
#else
        //If it is playing in an application then close the applicaiton.
        Application.Quit();
#endif
    }
}
