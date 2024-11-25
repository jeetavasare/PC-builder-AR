using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class MotherBoardIdentifier : MonoBehaviour
{
    // Start is called before the first frame update
    public ImageTargetBehaviour LaptopAUQR615B;
    public ImageTargetBehaviour LenovoLegion5;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if(LaptopAUQR615B != null && LaptopAUQR615B.TargetStatus.Status == Status.TRACKED)
        {
            BottomUIController.Instance.SetSuccess();
            BottomUIController.Instance.SetTitle("HP LaptopAUQR615B (2016)");
        }
        else if(LenovoLegion5 != null && LenovoLegion5.TargetStatus.Status == Status.TRACKED)
        {
            BottomUIController.Instance.SetSuccess();
            BottomUIController.Instance.SetTitle("Lenovo Legion 5 (2021)");
        }
        else
        {
            BottomUIController.Instance.SetLog();
            BottomUIController.Instance.SetTitle("Waiting to Detect .....");

        }
    }
}
