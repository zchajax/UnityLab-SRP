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

    [SerializeField]
    ShadowSettings shadows = default;

    protected override RenderPipeline CreatePipeline()
    {
        return new CustomRP(useDynamicBatching, useGPUInstancing, useSRPBatcher, shadows);
    }
}

public class CustomRP : RenderPipeline
{
    CameraRenderer renderer = new CameraRenderer();
    bool useDynamicBatching;
    bool useGPUInstancing;
    ShadowSettings shadowSettings;

    public CustomRP(bool useDynamicBatching, bool useGPUInstancing, bool useSRPBatcher,
        ShadowSettings shadowSettings)
    {
        this.useDynamicBatching = useDynamicBatching;
        this.useGPUInstancing = useGPUInstancing;
        this.shadowSettings = shadowSettings;

        GraphicsSettings.useScriptableRenderPipelineBatching = useSRPBatcher;
        GraphicsSettings.lightsUseLinearIntensity = true;
    }

    protected override void Render(ScriptableRenderContext context, Camera[] cameras)
    {
        foreach (var camera in cameras)
        {
            renderer.Render(context, camera, this.useDynamicBatching, this.useGPUInstancing,
                shadowSettings);
        }
    }
}
