using UnityEngine;

[DisallowMultipleComponent]
public class PerObjectMaterialProperties : MonoBehaviour
{

    static int baseColorId = Shader.PropertyToID("_BaseColor");

    static int baseTexSTId = Shader.PropertyToID("_BaseMap_ST");

    static MaterialPropertyBlock block;

    [SerializeField]
    Color baseColor = Color.white;

    [SerializeField]
    Vector4 baseTexST = new Vector4(1, 1, 0, 0);

    private void OnValidate()
    {
        if (block == null)
        {
            block = new MaterialPropertyBlock();
        }

        block.SetColor(baseColorId, baseColor);
        block.SetVector(baseTexSTId, baseTexST);
        GetComponent<Renderer>().SetPropertyBlock(block);
    }
}