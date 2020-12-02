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
            Vector3 x2 = new Vector3(d.x2, 0, d.y2);
            Vector3 xAux = new Vector3(d.x1 - 10, 0, d.y1);
            Vector3 targetDirX = x - x2;

            Vector3 y = new Vector3(d.x1, 70, d.y1); 
            Vector3 y2 = new Vector3(d.x2, 70, d.y2);
            Vector3 yAux = new Vector3(d.x1 - 10, 70, d.y1);
            Vector3 targetDirY = y - y2;

            Vector3 result = Vector3.Cross(targetDirX.normalized, Vector3.up) * offset;
            Vector3 resultXAux = result + result;
            Vector3 resultAux = Vector3.Cross(targetDirY.normalized, Vector3.up) * offset;
            Vector3 resultYAux = resultAux + resultAux;
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
            
            vertices.Add(x - resultXAux);
            vertices.Add(x2 - resultXAux);
            vertices.Add(x);
            vertices.Add(x2);

            
            //Top Vertices
            vertices.Add(y - resultYAux); 
            vertices.Add(y2 - resultYAux);
            vertices.Add(y);
            vertices.Add(y2);
                        
            //Chão 
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(2 + (i - 1) * 8);
            //1st triangle
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);    
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
               
        }
        mesh.Clear();
        mesh.vertices = vertices.ToArray();
        mesh.triangles = triangles.ToArray();
        mesh.RecalculateNormals();   
    }

    private void OnDrawGizmos()
    {   
        //Gizmos - > Green Spheres are X and Z Initial and Final Points
        //Gizmos - > Red Spheres and Lines(Always in Left) are values from negative offset of Green Spheres
        //Gizmos - > Blue Spheres and Lines(Always in Right) are values from positive offset of Green Spheres

            GetComponent<MeshFilter>().mesh = mesh;
            TextAsset graphdata = Resources.Load<TextAsset>("Graph");     

            string[] data = graphdata.text.Split(new char[] { '\n' });

            for(int i = 1; i < data.Length - 1; i++) {
                string[] row = data[i].Split(new char[]{','});

                //Parsing CSV Values from string to int values

                Data d = new Data();
                int.TryParse(row[0], out d.x1);
                int.TryParse(row[1], out d.y1);
                int.TryParse(row[2], out d.x2);
                int.TryParse(row[3], out d.y2);

                //Creating Vectors with x, y and z values from the current CSV File Points

                Vector3 x1 = new Vector3(d.x1, 0, d.y1); //Base X and Z First values
                Vector3 x2 = new Vector3(d.x2, 0, d.y2); //Base X and Z Second values
                Vector3 x1Aux = new Vector3(d.x1 - 10, 0, d.y1);
                Vector3 x2Aux = new Vector3(d.x2, 0, d.y2);

                Vector3 y1 = new Vector3(d.x1, 70, d.y1); //Top X and Z First values
                Vector3 y2 = new Vector3(d.x2, 70, d.y2); //Top X and Z Second values
                Vector3 y1Aux = new Vector3(d.x1 - 10, 70, d.y1);
                Vector3 y2Aux = new Vector3(d.x2 , 70, d.y2);
                
                Vector3 targetDirX = x1 - x2; // First - Second Base values to do Cross Product(Right hand rule)
                Vector3 targetDirY = y1 - y2; // First - Second Top values to do Cross Product(Right hand rule)

                Vector3 resultX = Vector3.Cross(targetDirX.normalized, Vector3.up) * offset; //Base Cross product to get an offset value
                Vector3 resultY = Vector3.Cross(targetDirY.normalized, Vector3.up) * offset; //Top Cross product to get an offset value
                //Creating Gizmos

                Gizmos.color = Color.green; //Sphere Color
                Gizmos.DrawSphere(x1, 1f); //Base X and Z First values Sphere Gizmos
                Gizmos.DrawSphere(x2, 1f); //Base X and Z Second values Sphere Gizmos

                Gizmos.DrawSphere(y1, 1f); //Top X and Z First values Sphere Gizmos
                //Gizmos.DrawSphere(y2, 1f); //Top X and Z Second values Sphere Gizmos                

                Gizmos.color = Color.red; //Negative Spheres and Lines Color
                
                //Negative Base Offset Values
                Gizmos.DrawSphere(x1, 1f);
                Gizmos.DrawSphere(x2, 1f);
                Gizmos.DrawLine  (x1, x2);
                
                
                //Negative Top Offset Values
                Gizmos.DrawSphere(y1, 1f);
                Gizmos.DrawSphere(y2, 1f);
                Gizmos.DrawLine  (y1, y2);

                Gizmos.color = Color.blue; //Positive Spheres and Lines Color

                //Positive Base Offset Values
                Gizmos.DrawSphere(x1 - resultX, 1f);
                Gizmos.DrawSphere(x2 - resultX, 1f);
                Gizmos.DrawLine  (x1 - resultX, x2 - resultX);
                
                //Positive Top Offset Values
                Gizmos.DrawSphere(y1Aux - resultY, 1f);
                Gizmos.DrawSphere(y2 - resultY, 1f);
                Gizmos.DrawLine(y1Aux - resultY, y2 - resultY);
                
            } 
    }
}
