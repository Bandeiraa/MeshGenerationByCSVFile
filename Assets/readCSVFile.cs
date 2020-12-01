using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class readCSVFile : MonoBehaviour
{

    [SerializeField] float offset = 30;
    Mesh mesh;
    List<Vector3> vertices;
    List<int> triangles;

    List<Data> datas = new List<Data>();

    void Start()
    { 
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        TextAsset graphdata = Resources.Load<TextAsset>("Graph");     

        string[] data = graphdata.text.Split(new char[] { '\n' });

        vertices = new List<Vector3>();
        triangles = new List<int>();
    
        for(int i = 1; i < data.Length - 1; i++) {
            string[] row = data[i].Split(new char[]{','});
            
            Data d = new Data();
            /*
            //X, Y and Z 1    
            int.TryParse(row[0], out d.x1);
            int.TryParse(row[1], out d.y1);
            int.TryParse(row[2], out d.z1);

            //X, Y and Z 2
            int.TryParse(row[3], out d.x2);
            int.TryParse(row[4], out d.y2);
            int.TryParse(row[5], out d.z2); 

            //X, Y and Z 3
            int.TryParse(row[6], out d.x3);
            int.TryParse(row[7], out d.y3);
            int.TryParse(row[8], out d.z3);

            //X, Y and Z 4
            int.TryParse(row[9], out d.x4);
            int.TryParse(row[10], out d.y4);
            int.TryParse(row[11], out d.z4);
            */

            int.TryParse(row[0], out d.x1);
            int.TryParse(row[1], out d.y1);
            int.TryParse(row[2], out d.x2);
            int.TryParse(row[3], out d.y2);

            datas.Add(d);
            
            /*
            Vector3 p1 = new Vector3(d.x1, 0, d.z1);
            Vector3 p2 = new Vector3(d.x2, 0, d.z2);
            Vector3 p3 = new Vector3(d.x3, 0, d.z3);
            Vector3 p4 = new Vector3(d.x4, 0, d.z4);
            */

            //print(p1);
            //print(result);
            
            //print(teste);

            Vector3 x = new Vector3(d.x1, 0, d.y1);
            //print(x);    
            Vector3 x2 = new Vector3(d.x2, 0, d.y2);
            Vector3 aux = new Vector3(1, 0, 0);
            Vector3 targetDir = x - x2;

            Vector3 y = new Vector3(d.x1, 70, d.y1); 
            Vector3 y2 = new Vector3(d.x2, 70, d.y2);
            Vector3 targetDirAux = y - y2;

            Vector3 result = Vector3.Cross(targetDir.normalized, Vector3.up) * offset;
            Vector3 resultAux = Vector3.Cross(targetDirAux.normalized, Vector3.up) * offset;
            Vector3 negativeOffset1 = x - result;
            Vector3 positiveOffset1 = x + result;
            Vector3 teste1 = negativeOffset1 + positiveOffset1;
            Vector3 negativeOffset2 = x2 - result;
            Vector3 positiveOffset2 = x2 + result;
            Vector3 teste2 = negativeOffset2 + positiveOffset2;
            Vector3 teste3 = teste1 - teste2;
            Vector3 testeCrossP = Vector3.Cross(teste3.normalized, Vector3.up) * offset;
            //print(teste);
            /*Vector3 xAux = new Vector3(d.x1, 0, d.y1 - 10); 
            Vector3 x2Aux = new Vector3(d.x2, 0, d.y2 - 10);
            Vector3 y2aux = new Vector3(d.x1, 70, d.y1 - 10); 
            Vector3 y2aux2 = new Vector3(d.x2, 70, d.y2 - 10);
            Vector3 targetDirAuxX = xAux - x2Aux;
            Vector3 targetDirAux2 = y2aux - y2aux2;



            Vector3 resultx2Aux = Vector3.Cross(targetDirAuxX.normalized, Vector3.up) * offset;
            Vector3 resulty2Aux = Vector3.Cross(targetDirAux2.normalized, Vector3.up) * offset;
            */

            //print(targetDirXAux);

            //print(xAux);

            /*Vector3 negativeValue = x - result;
            Vector3 positiveValue = x + result;
            Vector3 auxOffset = Vector3.Cross(result.normalized, Vector3.up) * offset;
            Vector3 auxOffsetPos = Vector3.Cross(positiveValue.normalized, Vector3.up) * offset;
            */

            //Base Vertices
            
            vertices.Add(x);
            vertices.Add(x2);
            vertices.Add(x + testeCrossP);
            vertices.Add(x2 + testeCrossP);

            
            //Top Vertices
            vertices.Add(y); 
            vertices.Add(y2);
            vertices.Add(y + resultAux);
            vertices.Add(y2 + resultAux);
            
            
            
                                        
            //Chão 
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(2 + (i - 1) * 8);
            //1st triangle
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);    
            //2nd triangle
            
            
            
            /*//Chão 
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);
            triangles.Add(0 + (i - 1) * 8);
            //1st triangle
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);    
            //2nd triangle
            */
            
            
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
            
            
               
        }
        //print(vertices.Count);
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals(); 
        

        /*foreach(Vector3 v in vertices){
            Debug.Log("V: " + v.x + ", VY1: " + v.z);
        }*/   
    }
}
