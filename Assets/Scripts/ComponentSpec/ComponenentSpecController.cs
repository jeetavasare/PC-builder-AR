using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class ComponenentSpecController : MonoBehaviour
{
    

    public GameObject MotherBoard;
    public ImageTargetBehaviour OfMotherBoard;

    public GameObject CPU;
    public ImageTargetBehaviour OfCPU;


    // Start is called before the first frame update
    public GameObject Ram;
    public ImageTargetBehaviour OfRam; // First Image Target Behaviour
    public UnityEngine.UI.Image backdrop;
    public TextMeshProUGUI textbox;
    bool motherboardPassed = false;
    bool componentPassed = false;
    void Start()
    {
        
        Debug.Log("-----------HRERERERE: "+DataHolder.Mode);
        BottomUIController.Instance.SetTitle("Waiting for MotherBoard");
    }

    // Update is called once per frame
    void Update()
    {
        if (!motherboardPassed)
        {
            CheckMotherBoardType();
        }
        else
        {
            CheckComponentType();
        }
    }

    public void CheckMotherBoardType()
    {
        if (OfMotherBoard.TargetStatus.Status == Status.TRACKED)
        {
            //BottomUIController.Instance.SetTitle("Waiting for RAM...");
            BottomUIController.Instance.SetDescription("Laptop MotherBoard -> ");
            BottomUIController.Instance.SetSuccess();
            CheckComponentType();
            //Helper.DelayedSceneSwitch(3, "ARVuScene");
            motherboardPassed=true;
        }
    }

    public void CheckComponentType()
    {
        if (componentPassed) {
            return;
        }
        BottomUIController.Instance.SetLog();
        if (DataHolder.Mode == "Ram")
        {
            //Ram.SetActive(true);
            BottomUIController.Instance.SetTitle("Waiting for RAM");
            if (OfRam.TargetStatus.Status == Status.TRACKED)
            {
                componentPassed=true;
                BottomUIController.Instance.SetTitle("Switching to next mode in 3 seconds");
                BottomUIController.Instance.SetDescription("Laptop MotherBoard -> SODIMM Laptop RAM");
                BottomUIController.Instance.SetSuccess();

                Helper.DelayedSceneSwitch(3, "ARVuScene");
            }
        }
        else if (DataHolder.Mode == "CPU")
        {
            //CPU.SetActive(true);
            BottomUIController.Instance.SetTitle("Waiting for CPU");
            if (OfCPU.TargetStatus.Status == Status.TRACKED)
            {
                componentPassed = true;
                BottomUIController.Instance.SetTitle("Switching to next mode in 3 seconds");
                BottomUIController.Instance.SetDescription("Laptop MotherBoard -> Intel I9 CPU");
                BottomUIController.Instance.SetSuccess();

                Helper.DelayedSceneSwitch(3, "ARVuScene");
            }
        }
        
        else
        {
            BottomUIController.Instance.SetTitle("Unknown Mode");
            BottomUIController.Instance.SetFailure();
        }
    }
}
