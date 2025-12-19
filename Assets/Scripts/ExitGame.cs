using UnityEngine;

public class ExitGame : MonoBehaviour
{
    public void Exit()
    {
        // Quits the application
        Application.Quit();
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
