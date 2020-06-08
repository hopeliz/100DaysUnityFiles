using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera magentaCamera;
    public Material magentaCameraMaterial;

    public Camera blueCamera;
    public Material blueCameraMaterial;

    void Start()
    {
        if (magentaCamera.targetTexture != null)
        {
            magentaCamera.targetTexture.Release();
        }

        magentaCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        magentaCameraMaterial.mainTexture = magentaCamera.targetTexture;

        if (blueCamera.targetTexture != null)
        {
            blueCamera.targetTexture.Release();
        }

        blueCamera.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        blueCameraMaterial.mainTexture = blueCamera.targetTexture;

    }
}
