using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class sacaleUIManager : MonoBehaviour
{
    public ScalingManager scalingManager;
    public TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Current Scale"+ scalingManager.scaleFactor.ToString());
        text.SetText( ((int)(scalingManager.scaleFactor * 100F)).ToString() + "%");
    }
}
