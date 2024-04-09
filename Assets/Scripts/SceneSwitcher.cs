using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Name of the scene to switch to
    [SerializeField]
    private string sceneName;

    // Function to be called when the button is clicked
    public void SwitchScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }
}
