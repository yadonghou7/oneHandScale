using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class objTracker : MonoBehaviour
{
    public GameObject selectedObject;
    public GameObject hoveredObject;

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        hoveredObject = args.interactableObject.transform.gameObject;
        Debug.Log($"Hovered object: {hoveredObject.name}");
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        hoveredObject = null;
        Debug.Log("Hovered cleared");
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        selectedObject = args.interactableObject.transform.gameObject;
        Debug.Log($"Selected object: {selectedObject.name}");
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        selectedObject = null;
        Debug.Log("Selection cleared");
    }
}