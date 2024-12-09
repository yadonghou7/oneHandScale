using UnityEngine;

public class ScalingManager : MonoBehaviour
{
    public objTracker objTracker;
    private bool isScaling = false;
    private Vector3 initialHandPosition;
    private Vector3 initialObjectScale;
    private Camera mainCamera;
    public Transform currentHandTransform;

    private float maxDistance = 0.3f; // 30 cm
    private float firstThreshold = 0.1f; // 10 cm
    private float minScale = 0.1f;
    private float maxScale = 5.0f; // 500%
    private float firstThresholdScale = 2.0f; // 200%

    public float scaleFactor; // Current scale

    void Start()
    {
        Debug.Log("Initialize scaling manager");
        mainCamera = Camera.main;
    }

    public void ActivateScaling(Transform handTransform)
    {
        Debug.Log("Scaling started");
        if (objTracker.hoveredObject == null)
        {
            Debug.Log("There is no hovered object");
            return;
        }

        isScaling = true;
        initialHandPosition = handTransform.position;
        initialObjectScale = objTracker.hoveredObject.transform.localScale;
    }

    public void DeactivateScaling()
    {
        Debug.Log("Scaling ended");
        isScaling = false;
    }

    void FixedUpdate()
    {
        if (!isScaling || objTracker.hoveredObject == null) return;

        Vector3 currentHandPos = currentHandTransform.position;
        Vector3 delta = currentHandPos - initialHandPosition;
        float movement = delta.x - delta.y;

        // Normalize movement to -1 to 1 range based on maxDistance
        float normalizedMovement = Mathf.Clamp(movement / maxDistance, -1f, 1f);

        // Apply asymmetric scaling
        if (Mathf.Abs(movement) <= firstThreshold)
        {
            // First 10cm: Map to 20%-200% scale (0.2 to 2.0)
            float t = Mathf.Abs(movement) / firstThreshold;
            scaleFactor = movement >= 0 ?
                Mathf.Lerp(1f, firstThresholdScale, t) :
                Mathf.Lerp(1f, 1f / firstThresholdScale, t);
        }
        else
        {
            // Remaining 20cm: Map to 200%-500% scale (2.0 to 5.0)
            float t = (Mathf.Abs(movement) - firstThreshold) / (maxDistance - firstThreshold);
            scaleFactor = movement >= 0 ?
                Mathf.Lerp(firstThresholdScale, maxScale, t) :
                Mathf.Lerp(1f / firstThresholdScale, 1f / maxScale, t);
        }

        scaleFactor = Mathf.Max(minScale, scaleFactor);

        objTracker.hoveredObject.transform.localScale = Vector3.Lerp(
            objTracker.hoveredObject.transform.localScale,
            initialObjectScale * scaleFactor,
            Time.fixedDeltaTime * 10f
        );
    }
}