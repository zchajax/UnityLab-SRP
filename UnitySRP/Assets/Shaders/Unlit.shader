Shader "Custom RP/Unlit"
{
    Properties
    {
       
    }
    SubShader
    {
        Pass
        {
            Tags { "LightMode" = "SRPDefaultUnlit" }

            HLSLPROGRAM
			#pragma vertex UnlitPassVertex
			#pragma fragment UnlitPassFragment
			#include "UnlitPass.hlsl"
            ENDHLSL
        }
    }
}
