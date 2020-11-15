using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    //Declare Global Variables.
    private bool isPaused;              //Holds whether or not the game is currently paused.
    public GameObject pauseMenuUI;     //Holds the Pause Menu panel.


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //Set isPaused to it's opposite.
            isPaused = !isPaused;

            if (isPaused)
            {
                ActivateMenu();
            }
            else
            {
                DeactivateMenu();
            }
        }
    }

    private void ActivateMenu()
    {
        //Set the time scale to 0.
        Time.timeScale = 0;

        //Pause the audio.
        AudioListener.pause = true;

        //ActivateMenu the panel.
        pauseMenuUI.SetActive(true);
    }

    public void DeactivateMenu()
    {
        //Set the time scale back to 1.
        Time.timeScale = 1;

        //Resume the audio.
        AudioListener.pause = false;

        //ActivateMenu the panel.
        pauseMenuUI.SetActive(false);

        //Set the isPaused boolean to false to allow the pause menu to activate again.
        isPaused = false;
    }
}
