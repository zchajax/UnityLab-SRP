using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{

    static int baseColorId = Shader.PropertyToID("_BaseColor");

    static int baseTexSTId = Shader.PropertyToID("_BaseMap_ST");

    static int cutoffId = Shader.PropertyToID("_Cutoff");

    static MaterialPropertyBlock block;

    [SerializeField]
    Color baseColor = Color.white;

    [SerializeField]
    Vector4 baseTexST = new Vector4(1, 1, 0, 0);

    [SerializeField]
    float cutoff = 1.0f;

    private void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }

        block.SetColor(baseColorId, baseColor);
        block.SetVector(baseTexSTId, baseTexST);
        block.SetFloat(cutoffId, cutoff);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}