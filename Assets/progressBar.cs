using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.XR.Hands.Samples.GestureSample;

public class progressBar : MonoBehaviour
{
    public Image progressbar;
    public StaticHandGesture gestureController;

    private float currentFillAmount;
    public float smoothSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //progressbar.fillAmount = gestureController.holdTimer / gestureController.minimumHoldTime;
        float targetFillAmount = gestureController.holdTimer / gestureController.minimumHoldTime;
        currentFillAmount = Mathf.Lerp(currentFillAmount, targetFillAmount, Time.deltaTime * smoothSpeed);
        progressbar.fillAmount = currentFillAmount;
    }
}
