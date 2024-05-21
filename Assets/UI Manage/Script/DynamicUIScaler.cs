using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasScaler))]
public class DynamicUIScaler : MonoBehaviour
{
    CanvasScaler canvasScaler;
    public float referenceWidth = 1080f;
    public float referenceHeight = 1920f;

    void Start()
    {
        canvasScaler = GetComponent<CanvasScaler>();

        if (canvasScaler == null)
        {
            Debug.LogError("CanvasScaler reference is missing!");
            return;
        }

        // Set the CanvasScaler to Scale With Screen Size
        canvasScaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;

        // Set the reference resolution to a common mobile resolution (portrait)
        canvasScaler.referenceResolution = new Vector2(referenceWidth, referenceHeight);

        // Calculate the screen aspect ratio
        float screenAspectRatio = (float)Screen.width / Screen.height;
        float referenceAspectRatio = referenceWidth / referenceHeight;

        // Adjust matchWidthOrHeight based on the screen aspect ratio
        if (screenAspectRatio > referenceAspectRatio)
        {
            // Screen is wider than reference
            canvasScaler.matchWidthOrHeight = 1.0f; // Match width
        }
        else if (screenAspectRatio < referenceAspectRatio)
        {
            // Screen is taller than reference
            canvasScaler.matchWidthOrHeight = 0.0f; // Match height
        }
        else
        {
            // Screen aspect ratio matches reference
            canvasScaler.matchWidthOrHeight = 0.5f; // Balanced
        }
    }
}
