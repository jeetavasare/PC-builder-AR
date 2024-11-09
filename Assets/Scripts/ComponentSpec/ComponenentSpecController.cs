using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class ComponenentSpecController : MonoBehaviour
{
    // Start is called before the first frame update
    public ImageTargetBehaviour ram; // First Image Target Behaviour
    public UnityEngine.UI.Image backdrop;
    public TextMeshProUGUI textbox;
    void Start()
    {
        BottomUIController.SetLog(textbox,backdrop,"Waiting...");
    }

    // Update is called once per frame
    void Update()
    {
        CheckComponentType();
    }

    public void CheckComponentType()
    {
        if(ram.TargetStatus.Status == Status.TRACKED)
        {
            BottomUIController.SetSuccess(textbox, backdrop, "RAM FOUND, Switching to next mode in 3 seconds");
            
            Helper.DelayedSceneSwitch(3,"ARVuScene");
        }
    }
}
