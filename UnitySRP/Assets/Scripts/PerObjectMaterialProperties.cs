using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{

    static int baseColorId = Shader.PropertyToID("_BaseColor");
    static int baseTexSTId = Shader.PropertyToID("_BaseMap_ST");
    static int cutoffId = Shader.PropertyToID("_Cutoff");
    static int metallicId = Shader.PropertyToID("_Metallic");
    static int smoothnessId = Shader.PropertyToID("_Smoothness");

    static MaterialPropertyBlock block;

    [SerializeField]
    Color baseColor = Color.white;

    [SerializeField]
    Vector4 baseTexST = new Vector4(1, 1, 0, 0);

    [SerializeField, Range(0f, 1f)]
    float cutoff = 1.0f;

    [SerializeField, Range(0f, 1f)]
    float metallic = 0f;

    [SerializeField, Range(0f, 1f)]
    float smoothness = 0.5f;

    private void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }

        block.SetColor(baseColorId, baseColor);
        block.SetVector(baseTexSTId, baseTexST);
        block.SetFloat(cutoffId, cutoff);
        block.SetFloat(metallicId, metallic);
        block.SetFloat(smoothnessId, smoothness);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}