using UnityEngine;
using Vuforia;

public class OrientationChecker : MonoBehaviour
{
    public ImageTargetBehaviour Ram; // First Image Target Behaviour
    public ImageTargetBehaviour RamSlot; // Second Image Target Behaviour
    public UIMessage uiMessage;                        // Reference to UIMessage for displaying messages

    public float maxAngleDifference = 45f; // Maximum allowed angle difference

    private Quaternion referenceRotation1;
    private Quaternion referenceRotation2;

    void Start()
    {
        // Initialize reference orientations when the targets are in the correct position
        referenceRotation1 = Ram.transform.rotation;
        referenceRotation2 = RamSlot.transform.rotation;

        // Find UIMessage if it's not assigned in the Inspector
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
            // Check if both image targets are being tracked (visible)
            if (Ram.TargetStatus.Status == Status.TRACKED &&
                RamSlot.TargetStatus.Status == Status.TRACKED)
            {
                // Calculate the relative rotation difference between Ram and RamSlot
                Quaternion relativeRotation = Quaternion.Inverse(RamSlot.transform.rotation) * Ram.transform.rotation;
                float angleDifference = Quaternion.Angle(Quaternion.identity, relativeRotation);

                // Check if the relative angle difference exceeds the threshold
                if (angleDifference > maxAngleDifference)
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
