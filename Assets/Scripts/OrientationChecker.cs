using UnityEngine;

public class OrientationChecker : MonoBehaviour
{
    public Transform imageTarget1; // First Image Target
    public Transform imageTarget2; // Second Image Target
    public UIMessage uiMessage;    // Reference to UIMessage for displaying messages

    public float maxAngleDifference = 10f; // Maximum allowed angle difference

    private Quaternion referenceRotation1;
    private Quaternion referenceRotation2;

    void Start()
    {
        // Initialize reference orientations when the targets are in the correct position
        referenceRotation1 = imageTarget1.rotation;
        referenceRotation2 = imageTarget2.rotation;

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
        // Calculate the angle difference between the current and reference rotation for both targets
        float angleDifference1 = Quaternion.Angle(imageTarget1.rotation, referenceRotation1);
        float angleDifference2 = Quaternion.Angle(imageTarget2.rotation, referenceRotation2);

        // Check if either target's angle difference exceeds the threshold
        if (angleDifference1 > maxAngleDifference || angleDifference2 > maxAngleDifference)
        {
            uiMessage.DisplayMessage("Warning: One or both objects are out of orientation!");
        }
        else
        {
            uiMessage.DisplayMessage(""); // Clear the message if everything is aligned
        }
    }
}
