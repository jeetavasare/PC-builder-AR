using UnityEngine;
using Vuforia;

public class OrientationChecker : MonoBehaviour
{
    public ImageTargetBehaviour imageTarget1Behaviour; // First Image Target Behaviour
    public ImageTargetBehaviour imageTarget2Behaviour; // Second Image Target Behaviour
    public UIMessage uiMessage;                        // Reference to UIMessage for displaying messages

    public float maxAngleDifference = 10f; // Maximum allowed angle difference

    private Quaternion referenceRotation1;
    private Quaternion referenceRotation2;

    void Start()
    {
        // Initialize reference orientations when the targets are in the correct position
        referenceRotation1 = imageTarget1Behaviour.transform.rotation;
        referenceRotation2 = imageTarget2Behaviour.transform.rotation;

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
        // Check if both image targets are being tracked (visible)
        if (imageTarget1Behaviour.TargetStatus.Status == Status.TRACKED &&
            imageTarget2Behaviour.TargetStatus.Status == Status.TRACKED)
        {
            // Calculate the angle difference between the current and reference rotation for both targets
            float angleDifference1 = Quaternion.Angle(imageTarget1Behaviour.transform.rotation, referenceRotation1);
            float angleDifference2 = Quaternion.Angle(imageTarget2Behaviour.transform.rotation, referenceRotation2);

            // Check if either target's angle difference exceeds the threshold
            if (angleDifference1 > maxAngleDifference || angleDifference2 > maxAngleDifference)
            {
                uiMessage.DisplayMessage("Warning: One or both objects are out of orientation!");
            }
            else
            {
                uiMessage.DisplayMessage("Orientation is correct.");
            }
        }
        else
        {
            uiMessage.DisplayMessage("Waiting for both targets to be visible...");
        }
    }
}
