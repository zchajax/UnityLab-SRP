using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Rendering/Custom Render Pipeline")]
public class CustomRPAsset : RenderPipelineAsset
{
    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRP();
    }
}

public class CustomRP : RenderPipeline
{
    CameraRenderer renderer = new CameraRenderer();
    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        foreach (var camera in cameras)
        {
            renderer.Render(context, camera);
        }
    }
}
