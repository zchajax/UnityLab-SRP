using UnityEngine;
using UnityEngine.Rendering;

[CreateAssetMenu(menuName = "Rendering/Custom Render Pipeline")]
public class CustomRPAsset : RenderPipelineAsset
{
    [SerializeField]
    bool useDynamicBatching = true;

    [SerializeField]
    bool useGPUInstancing = true;

    [SerializeField]
    bool useSRPBatcher = true;

    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRP(useDynamicBatching, useGPUInstancing, useSRPBatcher);
    }
}

public class CustomRP : RenderPipeline
{
    CameraRenderer renderer = new CameraRenderer();
    bool useDynamicBatching;
    bool useGPUInstancing;

    public CustomRP(bool useDynamicBatching, bool useGPUInstancing, bool useSRPBatcher)
    {
        this.useDynamicBatching = useDynamicBatching;
        this.useGPUInstancing = useGPUInstancing;

        GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher;
        GraphicsSettings.lightsUseLinearIntensity = true;
    }

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        foreach (var camera in cameras)
        {
            renderer.Render(context, camera, this.useDynamicBatching, this.useGPUInstancing);
        }
    }
}
