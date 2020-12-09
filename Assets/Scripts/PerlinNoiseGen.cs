using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerlinNoiseGen : MonoBehaviour
{
    public float XSpeed = 0f;
    public float ZSpeed = 0f;
    public float Height = 0f;
    public float Size = 0f;
    float movementX = 0f;
    float movementZ = 0f;



    public float getPerlin(float x, float z)
    {
        return Mathf.PerlinNoise((x + movementX) * Size, (z + movementZ) * Size) * Height;
    }

    public float getPerlin(int x, int z)
    {
        return Mathf.PerlinNoise((x + movementX) * Size, (z + movementZ) * Size) * Height;
    }

    public void updateMovement()
    {
        movementX = movementX + (.01f * XSpeed);
        movementZ = movementZ + (.01f * ZSpeed);
    }
}
