using UnityEngine;
using UnityEngine.Rendering;

public class CameraRenderer
{

    ScriptableRenderContext context;

    Camera camera;

    public void Render(ScriptableRenderContext context, Camera camera)
    {
        this.context = context;
        this.camera = camera;

        Setup();
        DrawVisiableGeometry();
        Submit();
    }

    private void DrawVisiableGeometry()
    {
        context.DrawSkybox(camera);
    }

    private void Setup()
    {
        context.SetupCameraProperties(camera);
    }

    private void Submit()
    {
        context.Submit();
    }
}