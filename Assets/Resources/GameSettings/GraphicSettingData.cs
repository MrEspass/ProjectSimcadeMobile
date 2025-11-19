using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GraphicSettingData", menuName = "GraphicSetting/Graphic Setting Data")]
public class GraphicSettingData : ScriptableObject
{
    public enum GraphicsPreset
    {
        VeryLow = 0, Low = 1, Medium = 2, High = 3, VeryHigh = 4, Ultra = 5
    }
    public enum FramerateTarget
    {
        VeryLow = 20, Low = 30, Medium = 40, High = 60, VeryHigh = 90, Ultra = 120
    }
    public GraphicsPreset graphicsPreset;
    public FramerateTarget framerateTarget;
}
