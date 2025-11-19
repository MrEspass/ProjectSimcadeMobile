using UnityEngine;

public class TransparentCameraView : MonoBehaviour
{
    [Header("Camera that will see transparent objects")]
    public Camera specialCamera;

    [Header("Shader to use for replacement")]
    public Shader transparentShader;

    void Start()
    {
        if (specialCamera != null && transparentShader != null)
        {
            // Apply replacement shader to objects with the "RenderType" tag
            specialCamera.SetReplacementShader(transparentShader, "RenderType");
        }
        else
        {
            Debug.LogWarning("TransparentCameraView: Missing camera or shader reference!");
        }
    }

    void OnDisable()
    {
        // Revert to normal rendering if script disabled
        if (specialCamera != null)
            specialCamera.ResetReplacementShader();
    }
}
