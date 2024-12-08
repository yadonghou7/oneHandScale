using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class gazeManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        Debug.Log($"Gaze Selected object: {args.interactableObject.transform.gameObject.name}");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
