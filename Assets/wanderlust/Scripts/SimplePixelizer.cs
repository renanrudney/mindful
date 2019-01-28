//SimplePixelizer

using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
[AddComponentMenu("Image Effects/SimplePixelizer")]
public class SimplePixelizer : MonoBehaviour
{

    public bool colorBlending = false;
    public int pixelize = 25;

    //Fixed Resolution
    //Enabling fixed resolution will ignore the pixelize variable.
    //It won't ignore colorBlending
    public bool useFixedResolution = false;
    public int fixedHeight = 640;
    public int fixedWidth = 480;

    //Check if image effects are supported
    protected void Start()
    {
        if (!SystemInfo.supportsImageEffects)
        {
            enabled = false;
            return;
        }
    }

    //Downgrade the image
    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Create the buffer
        RenderTexture buffer = null;

        //Set the resolution of the buffer
        if (useFixedResolution)
        {
            buffer = RenderTexture.GetTemporary(fixedWidth, fixedHeight, 0);
        }
        else
        {
            buffer = RenderTexture.GetTemporary(source.width / pixelize, source.height / pixelize, 0);
        }

        //Change filter mode of buffer to create the pixel effect
        buffer.filterMode = FilterMode.Point;

        //Change filter mode of source to disable color blending/merging
        if (!colorBlending)
        {
            source.filterMode = FilterMode.Point;
        }

        //Copy source to buffer to create the final image
        Graphics.Blit(source, buffer);

        //Copy buffer to destination so it renders on screen
        Graphics.Blit(buffer, destination);

        //Release buffer
        RenderTexture.ReleaseTemporary(buffer);
    }
}