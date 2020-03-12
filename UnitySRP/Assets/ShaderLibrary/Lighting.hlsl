#ifndef CUSTOM_LIGHTING_INCLUDE
#define CUSTOM_LIGHTING_INCLUDE

float3 GetIncomingLight(Surface surface, Light light)
{
    return saturate(dot(light.direction, surface.normal)) * light.color;
}

float3 GetLighting (Surface surface, Light light)
{
    return GetIncomingLight(surface, light) * surface.color;
}

float3 GetLighting(Surface surface)
{
    float3 color = 0.0;
    int lightCount = GetDirectionalLightCount();
    for (int i = 0; i < lightCount; i++)
    {
        Light light = GetDirectionLight(i);

        color += GetLighting(surface, light);
    }

    return color;
}

#endif