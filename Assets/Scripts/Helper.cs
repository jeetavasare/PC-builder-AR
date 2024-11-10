using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Helper : MonoBehaviour
{
    public static string Mode;
    private static Helper _instance;

    // Singleton pattern to ensure only one instance of Helper
    public static Helper Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject helperObject = new GameObject("Helper");
                _instance = helperObject.AddComponent<Helper>();
                DontDestroyOnLoad(helperObject); // Keep the instance persistent between scenes
            }
            return _instance;
        }
    }

    // Public method to initiate the delayed scene switch
    public static void DelayedSceneSwitch(float delay, string sceneName)
    {
        Instance.StartCoroutine(Instance.SwitchSceneAfterDelay(delay, sceneName));
    }

    // Coroutine to handle delayed scene switching
    private IEnumerator SwitchSceneAfterDelay(float delay, string sceneName)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }

    public void ReturnToHome()
    {
        SceneManager.LoadScene("MainScene");
    }
}
