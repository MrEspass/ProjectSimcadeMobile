using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GraphicSettingData", menuName = "GraphicSetting/Graphic Setting Data")]
public class GraphicSettingData : ScriptableObject
{
    public enum Resolution 
    {
        SD = 480, HD = 720, FullHD = 1080, QuadHD = 1440, UltraHD = 2160
    }
    public enum GraphicsPreset
    {
        VeryLow = 0, Low = 1, Medium = 2, High = 3, VeryHigh = 4, Ultra = 5
    }
    public enum FramerateTarget
    {
        VeryLow = 25, Low = 30, Medium = 40, High = 60, VeryHigh = 90, Ultra = 120
    }
    public enum VSyncTarget
    {
        Off = 0, VSync = 1, HalfVSync = 2
    }
    public Resolution resolution;
    public GraphicsPreset graphicsPreset;
    public FramerateTarget framerateTarget;
    public VSyncTarget VSync;
}
