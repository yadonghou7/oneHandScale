using UnityEngine;


public class GazeVisualizer : MonoBehaviour
{
    public float maxRaycastDistance = 10f;
    public GameObject reticle;
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rayInteractor;

    void Start()
    {
        //rayInteractor = GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor>();
    }

    void Update()
    {
        if (reticle && rayInteractor)
        {
            RaycastHit hit;
            if (rayInteractor.TryGetCurrent3DRaycastHit(out hit))
            {
                reticle.SetActive(true);
                reticle.transform.position = hit.point;
                //reticle.transform.rotation = Quaternion.LookRotation(hit.normal);
                reticle.transform.LookAt(Camera.main.transform);
                reticle.transform.Rotate(0, 180, 0);
            }
            else
            {
                reticle.SetActive(false);
            }
        }
    }
}