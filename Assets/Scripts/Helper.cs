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
                DontDestroyOnLoad(helperObject);
            }
            return _instance;
        }
    }

    
    public static void DelayedSceneSwitch(float delay, string sceneName)
    {
        Instance.StartCoroutine(Instance.SwitchSceneAfterDelay(delay, sceneName));
    }

    
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
