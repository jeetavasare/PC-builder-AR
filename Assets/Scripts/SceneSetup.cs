using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Vuforia;
public class SceneSetup : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool AllGood;
    public GameObject RamSlot;
    public GameObject Ram;

    public TextMeshProUGUI modeName;
    void Start()
    {
        Debug.Log("new SCENE");
        string mode = DataHolder.Mode;
        Debug.Log(mode);
        modeName.SetText(mode);

        if(mode == "Ram" )
        {
            BottomUIController.Instance.SetWarning();
            BottomUIController.Instance.SetDescription("Samsung Ram - MSI Motherboard");
            Ram.SetActive(true);
            RamSlot.SetActive(true);
            AllGood = true;
        }
        else
        {
            BottomUIController.Instance.SetWarning();
            BottomUIController.Instance.SetDescription("Unknown Mode");

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
