using UnityEngine;
using Vuforia;

public class OrientationChecker : MonoBehaviour
{
    public ImageTargetBehaviour Ram; 
    public ImageTargetBehaviour RamSlot; 
    public UIMessage uiMessage;          
    public ImageTargetBehaviour RamBackside;
    public float maxAngleDifference = 45f;

    private Quaternion referenceRotation1;
    private Quaternion referenceRotation2;

    void Start()
    {
        
        referenceRotation1 = Ram.transform.rotation;
        referenceRotation2 = RamSlot.transform.rotation;

        
        if (uiMessage == null)
        {
            uiMessage = FindObjectOfType<UIMessage>();
        }
    }

    void Update()
    {
        CheckOrientation();
    }

    void CheckOrientation()
    {
        if (DataHolder.Mode == "Ram")
        {
            
            if(RamBackside.TargetStatus.Status == Status.TRACKED)
            {
                BottomUIController.Instance.SetFailure();
                BottomUIController.Instance.SetTitle("The RAM is upside down. FLIP it SIDEWAYS!");
            }
            else if (Ram.TargetStatus.Status == Status.TRACKED &&
                RamSlot.TargetStatus.Status == Status.TRACKED)
            {
                Quaternion relativeRotation = Quaternion.Inverse(RamSlot.transform.rotation) * Ram.transform.rotation;
                float angleDifference = Quaternion.Angle(Quaternion.identity, relativeRotation);
                //BottomUIController.Instance.SetDescription(relativeRotation.x.ToString()+"angle diff: " + angleDifference.ToString());
                
                if (angleDifference < maxAngleDifference)
                {
                    BottomUIController.Instance.SetWarning();
                    BottomUIController.Instance.SetTitle("Warning: RAM is wrongly positioned orientation!");
                }
                else
                {
                    BottomUIController.Instance.SetSuccess();
                    BottomUIController.Instance.SetTitle("Orientation is correct.");
                }
            }
            else
            {
                BottomUIController.Instance.SetLog();
                BottomUIController.Instance.SetTitle("Waiting for both targets to be visible...");
            }
        }
    }
}
