using System;
using System.Collections.Generic;
using System.Text;

namespace ShadowEngine.ContentLoading
{
    public struct Vertex
    {
        public float x, y, z;  //point coordenates
        public float u, v;     //texture coordinates
    }

    public struct Material
    {
        public string name;
        public byte[] ambient;
        public float[] ambientf;

        public byte[] diffuse;
        public float[] diffusef;

        public byte[] specular;
        public float[] specularf;

        public Material(string name)
        {
            this.name = name;
            ambient = new byte[3];
            ambientf = new float[4]; 
            diffuse = new byte[3];
            diffusef = new float[4]; 
            specular = new byte[3];
            specularf = new float[4]; 
        }
    }

    public struct Face
    {
        public Vertex[] vertex;
        public Vector3[] normal;
    }

    public struct MeshIndexed
    {
        public FaceIndexed[] faceList;
        public Vertex[] vertexList;
        public TextureCoord[] textures;
        public Vector3[] normals;
        public string meshName;
        public string textureName;
        public Material material;
        public Matrix matrix;

        public void Allocate(uint nVerts, uint nFaces)
        {
            vertexList = new Vertex[nVerts];
            faceList = new FaceIndexed[nFaces];
            normals = new Vector3[nFaces * 3];
            textures = new TextureCoord[nVerts * 2];
            material = new Material("null");
        }

        public void AddMaterialAmbient(byte ra, byte ga, byte ba)
        {
            material.ambient[0] = ra;
            material.ambient[1] = ga;
            material.ambient[2] = ba;
            material.ambientf[0] = (float)ra / 255f;
            material.ambientf[1] = (float)ga / 255f;
            material.ambientf[2] = (float)ba / 255f;
            material.ambientf[3] = 1;
            material.name = "notnull"; 
        }

        public void AddMaterialDifusse(byte ra, byte ga, byte ba)
        {
            material.diffuse[0] = ra;
            material.diffuse[1] = ga;
            material.diffuse[2] = ba;
            material.diffusef[0] = (float)ra / 255f;
            material.diffusef[1] = (float)ga / 255f;
            material.diffusef[2] = (float)ba / 255f;
            material.diffusef[3] = 1;
            material.name = "notnull";
        }

        public void AddMaterialSpecular(byte ra, byte ga, byte ba)
        {
            material.specular[0] = ra;
            material.specular[1] = ga;
            material.specular[2] = ba;
            material.specularf[0] = (float)ra / 255f;
            material.specularf[1] = (float)ga / 255f;
            material.specularf[2] = (float)ba / 255f;
            material.specularf[3] = 1;
            material.name = "notnull";
        }

        public void SetVertexPosition(uint i, Vector3 v)
        {
            Vertex vertex = new Vertex();
            vertex.x = v.X;
            vertex.y = v.Y;
            vertex.z = v.Z;
            vertexList[i] = vertex;
        }

        public void SetFaceIndicies(uint i, int a, int b, int c)
        {
            int[] indicies = { a, b, c };
            faceList[i].vertexIndexes = indicies;
        }

        public void SetVertexNormal(uint i, Vector3 v)
        {
            normals[i] = v;
        }
    }

    public struct FaceIndexed
    {
        public int[] vertexIndexes;
        public int[] textureIndexes;
        public Vector3[] normal;
    }

    public struct TexttureInfo
    {
        public int ID;
        public int width;
        public int height;
    };

    public struct TextureCoord
    {
        public float x;
        public float y;
    };
}
