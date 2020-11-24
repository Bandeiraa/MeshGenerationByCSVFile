using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class readCSVFile : MonoBehaviour
{

    [SerializeField] float offset = 100;
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    List<Data> datas = new List<Data>();

    void Start()
    { 
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        TextAsset graphdata = Resources.Load<TextAsset>("Grafo");     

        string[] data = graphdata.text.Split(new char[] { '\n' });

        vertices = new List<Vector3>();
        triangles = new List<int>();
    
        for(int i = 1; i < data.Length - 1; i++) {
            string[] row = data[i].Split(new char[]{','});
            
            Data d = new Data();
            //X, Y and Z 1    
            d.x1 = row[0];
            d.y1 = row[1];
            d.z1 = row[2];

            //X, Y and Z 2
            d.x2 = row[3];
            d.y2 = row[4];
            d.z2 = row[5]; 

            //X, Y and Z 3
            d.x3 = row[6];
            d.y3 = row[7];
            d.z3 = row[8];

            //X, Y and Z 4
            d.x4 = row[9];
            d.y4 = row[10];
            d.z4 = row[11];

            datas.Add(d);

            //print(d.x1);
            Vector3 offset1 = new Vector3(float.Parse(d.x1), 0, float.Parse(d.z1));
            //Vector3 teste = new Vector3(d.x2, 0, d.z2);
            print(offset1);
            //print(teste);

            /*Vector3 x = new Vector3(d.p1, 0, d.p2);    
            Vector3 x2 = new Vector3(d.p3, 0, d.p4);
            Vector3 targetDir = x - x2;
            //print(targetDir);

            Vector3 y = new Vector3(d.p1, 70, d.p2); 
            Vector3 y2 = new Vector3(d.p3, 70, d.p4);
            
            Vector3 targetDirAux = y - y2;
  
            Vector3 result = Vector3.Cross(targetDir.normalized, Vector3.up) * offset;
            print(result);
            Vector3 resultAux = Vector3.Cross(targetDirAux.normalized, Vector3.up) * offset;

            Vector3 negativeValue = x - result;
            Vector3 positiveValue = x + result;
            Vector3 auxOffset = Vector3.Cross(result.normalized, Vector3.up) * offset;
            Vector3 auxOffsetPos = Vector3.Cross(positiveValue.normalized, Vector3.up) * offset;
            */

            //Base Vertices
            
            /*vertices.Add(d.p1);
            vertices.Add(d.p2);
            vertices.Add(d.p3);
            vertices.Add(d.p4);
            */
            
            /*
            //Top Vertices
            vertices.Add(y - resultAux); 
            vertices.Add(y2 - resultAux);
            vertices.Add(y + resultAux);
            vertices.Add(y2 + resultAux);
            */
            
            /*                            
            //Chão 
            triangles.Add(0 + (i - 1) * 4);
            triangles.Add(1 + (i - 1) * 4);
            triangles.Add(2 + (i - 1) * 4);
            //1st triangle
            triangles.Add(2 + (i - 1) * 4);
            triangles.Add(1 + (i - 1) * 4);
            triangles.Add(3 + (i - 1) * 4);    
            //2nd triangle
            */
            
            /*
            //Chão 
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);
            triangles.Add(0 + (i - 1) * 8);
            //1st triangle
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);    
            //2nd triangle
            
            
            //Topo da Parede
            triangles.Add(4 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(6 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(6 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(7 + (i - 1) * 8); 
            //2nd triangle  

            //Right Face
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(4 + (i - 1) * 8);
            triangles.Add(2 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(4 + (i - 1) * 8);
            triangles.Add(6 + (i - 1) * 8); 
            //2nd triangle  

            //Left Face
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(7 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(3 + (i - 1) * 8);
            triangles.Add(7 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8); 
            //2nd triangle
            
            // Face
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(0 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(4 + (i - 1) * 8); 
            //2nd triangle
            
            //Face
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(6 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(3 + (i - 1) * 8);
            triangles.Add(6 + (i - 1) * 8);
            triangles.Add(7 + (i - 1) * 8); 
            //2nd triangle
            */
            
               
            
        }
        //print(vertices.Count);
        /*mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals(); 
        */

        /*foreach(Vector3 v in vertices){
            Debug.Log("V: " + v.x + ", VY1: " + v.z);
        }*/   
    }
}
