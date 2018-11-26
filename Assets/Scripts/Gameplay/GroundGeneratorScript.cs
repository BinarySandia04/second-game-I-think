using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]

public class GroundGeneratorScript : MonoBehaviour {

    public int testX;
    public int testY;
    [Space]
    public float noiseDetail = 0.1f;
    public float height = 1f;
    Vector3[] points;
    int[] tris;

    void Start()
    {
        definePointsAndTris(testX, testY);
        genMesh();
    }

    private void Update()
    {
        updatePointsAndTris(testX, testY);
        genMesh();
    }

    public void updatePointsAndTris(int ix, int iy)
    {
        points = new Vector3[(ix + 1) * (iy + 1)];

        // Define points
        for (int z = 0, i = 0; z <= iy; z++) for (int x = 0; x <= ix; x++, i++)
            {
                float y =  height * Mathf.Sin(Time.time + x + z);
                points[i] = new Vector3(x, y, z);
            }

        tris = new int[ix * iy * 6];
        for (int z = 0, vert = 0, trias = 0; z < iy; z++, vert++)
        {
            for (int x = 0; x < ix; x++, trias += 6, vert++)
            {
                tris[trias + 0] = vert + 0;
                tris[trias + 1] = vert + ix + 1;
                tris[trias + 2] = vert + 1;
                tris[trias + 3] = vert + 1;
                tris[trias + 4] = vert + ix + 1;
                tris[trias + 5] = vert + ix + 2;
            }

        }
    }

    public void genMesh()
    {
        Mesh m = new Mesh();
        m.vertices = points;
        m.triangles = tris;
        m.RecalculateNormals();
        GetComponent<MeshFilter>().mesh = m;
        MeshCollider mc = GetComponent<MeshCollider>();
        if(mc != null)
        {
            mc.sharedMesh = m;
        }
    }

    public void definePointsAndTris(int ix, int iy)
    {
        points = new Vector3[(ix + 1) * (iy + 1)];

        for(int z = 0, i = 0; z <= iy; z++) for(int x = 0; x <= ix; x++, i++) points[i] = new Vector3(x, 0 * height, z);

        tris = new int[ix * iy * 6];
        for(int z = 0, vert = 0, trias = 0; z < iy; z++, vert++)
        {
            for (int x = 0; x < ix; x++, trias += 6, vert++)
            {
                tris[trias + 0] = vert + 0;
                tris[trias + 1] = vert + ix + 1;
                tris[trias + 2] = vert + 1;
                tris[trias + 3] = vert + 1;
                tris[trias + 4] = vert + ix + 1;
                tris[trias + 5] = vert + ix + 2;
            }
            
        }

        for(int i = 0; i < tris.Length; i++)
        {
            Debug.Log(tris[i]);
        }
    }
    

}
