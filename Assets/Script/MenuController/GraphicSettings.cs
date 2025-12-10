using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphicSettings : MonoBehaviour
{
    [SerializeField] GraphicSettingData graphicSetting;
    [SerializeField] int width;
    [SerializeField] int height;
    [SerializeField] float resolution;
    [SerializeField] float resolutionScale;
    // Start is called before the first frame update
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
        resolution = (float)graphicSetting.resolution;
        resolutionScale = resolution / height;
        Application.targetFrameRate = (int)graphicSetting.framerateTarget;
        QualitySettings.SetQualityLevel((int)graphicSetting.graphicsPreset);
        QualitySettings.vSyncCount = (int)graphicSetting.VSync;
    }

    // Update is called once per frame
    void Update()
    {
        ScalableBufferManager.ResizeBuffers(resolutionScale, resolutionScale);
    }
}
