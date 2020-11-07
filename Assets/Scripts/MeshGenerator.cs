using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshGenerator : MonoBehaviour
{
    Mesh mesh;

    Vector3[] vertices;
    int[] triangles;

    public bool isColider = false;
    public bool isStatic = false;
    bool update = true;
    public float YPos = 0;
    public int xSize = 20;
    public int zSize = 20;
    public float TriSize = 1f;


    public PerlinNoiseGen Filter1;
    public PerlinNoiseGen Filter2;
    public PerlinNoiseGen Filter3;


    // Start is called before the first frame update
    void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
    }


    // Update is called once per frame
    void Update()
    {
        if (update)
        {
            Filter1.updateMovement();
            Filter2.updateMovement();
            Filter3.updateMovement();
            transform.position = new Vector3(0 - (xSize * TriSize) / 2, YPos, 0 - (zSize * TriSize) / 2);
            CreateShape();
            UpdateMesh();
            if (isColider)
            {
                mesh.RecalculateBounds();
                MeshCollider meshCollider = gameObject.GetComponent<MeshCollider>();
                meshCollider.sharedMesh = mesh;
            }
            if (isStatic)
            {
                update = false;
            }
        }
    }
    void CreateShape()
    {
        vertices = new Vector3[(xSize + 1) * (zSize + 1)];
        int i = 0;
        for(int z = 0; z <= zSize; z++)
        {
            for (int x = 0; x <= xSize; x++)
            {
                float y = Filter1.getPerlin(x, z) + Filter2.getPerlin(x, z) + Filter3.getPerlin(x, z);
                vertices[i] = new Vector3(x * TriSize, y, z* TriSize);
                i++;
            }
        }

        triangles = new int[xSize * zSize * 6];

        int vert = 0;
        int tris = 0;

        for(int z = 0; z < zSize; z++)
        {
            for (int x = 0; x < xSize; x++)
            {
                triangles[tris + 0] = vert + 0;
                triangles[tris + 1] = vert + xSize + 1;
                triangles[tris + 2] = vert + 1;
                triangles[tris + 3] = vert + 1;
                triangles[tris + 4] = vert + xSize + 1;
                triangles[tris + 5] = vert + xSize + 2;

                vert++;
                tris += 6;
            }
            vert++;
        }
        
    }


    void UpdateMesh()
    {
        mesh.Clear();

        mesh.vertices = vertices;
        mesh.triangles = triangles;

        mesh.RecalculateNormals();
    }
}
