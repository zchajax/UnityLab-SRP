#ifndef CUSTOM_LIGHTING_INCLUDE
#define CUSTOM_LIGHTING_INCLUDE

float3 GetIncomingLight(Surface surface, Light light)
{
    return saturate(dot(light.direction, surface.normal)) * light.color;
}

float3 GetLighting (Surface surface, BRDF brdf, Light light)
{
    return GetIncomingLight(surface, light) * DirectBRDF(surface, brdf, light);
}

float3 GetLighting(Surface surface, BRDF brdf)
{
    float3 color = 0.0;
    int lightCount = GetDirectionalLightCount();
    for (int i = 0; i < lightCount; i++)
    {
        Light light = GetDirectionLight(i);

        color += GetLighting(surface, brdf, light);
    }

    return color;
}

#endif