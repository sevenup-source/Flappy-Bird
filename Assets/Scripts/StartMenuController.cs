using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{

    public void onStartClick()
    {
        // Load the main game scene
        SceneManager.LoadScene("Game");
    }

    public void onExitClick()
    {
        // Exit the application
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #endif
        Application.Quit();

    }


}
