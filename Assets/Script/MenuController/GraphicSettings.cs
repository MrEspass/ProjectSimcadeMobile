using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicSettings : MonoBehaviour
{
    [SerializeField] GraphicSettingData graphicSetting;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = (int)graphicSetting.framerateTarget;
        QualitySettings.SetQualityLevel((int)graphicSetting.graphicsPreset);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
