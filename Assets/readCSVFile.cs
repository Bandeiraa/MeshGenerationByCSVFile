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
        TextAsset graphdata = Resources.Load<TextAsset>("Graph"); //Reading CSV File named as Graph     

        string[] data = graphdata.text.Split(new char[] { '\n' });

        vertices = new List<Vector3>();
        triangles = new List<int>();
    
        for(int i = 1; i < data.Length - 1; i++) {
            string[] row = data[i].Split(new char[]{','});
            
            Data d = new Data();
            
            int.TryParse(row[0], out d.x1);
            int.TryParse(row[1], out d.y1);
            int.TryParse(row[2], out d.x2);
            int.TryParse(row[3], out d.y2);
            
            //Parsing the CSV file values in 4 variables
            datas.Add(d);
 
            Vector3 x = new Vector3(d.x1, 0, d.y1);  //(Base) Creating a Vector3 with X and Z initial values
            Vector3 x2 = new Vector3(d.x2, 0, d.y2); //(Base) Creating a Vector3 with X and Z final values
            
            Vector3 targetDirX = x - x2; //(Base) Variable to store the difference between initial and final X and Z values

            Vector3 y = new Vector3(d.x1, 70, d.y1);  //(Top) Creating a Vector3 with X and Z initial values
            Vector3 y2 = new Vector3(d.x2, 70, d.y2); //(Top) Creating a Vector3 with X and Z final values
            
            Vector3 targetDirY = y - y2; //(Top) Variable to store the difference between initial and final X and Z values

            Vector3 result = Vector3.Cross(targetDirX.normalized, Vector3.up) * offset; //(Base) Cross product to get an offset value
            Vector3 resultXAux = result + result; //Multiplying Base Cross Product by two
            Vector3 resultAux = Vector3.Cross(targetDirY.normalized, Vector3.up) * offset;//(Top) Cross product to get an offset value
            Vector3 resultYAux = resultAux + resultAux; //Multiplying Top Cross Product by two
            
            //Creating 4 Base Vertices
            vertices.Add(x - resultXAux);
            vertices.Add(x2 - resultXAux);
            vertices.Add(x);
            vertices.Add(x2);
          
            //Creating 4 Top Vertices
            vertices.Add(y - resultYAux); 
            vertices.Add(y2 - resultYAux);
            vertices.Add(y);
            vertices.Add(y2);
                        
            //Base Face (Floor Image at Vertices Image Representation folder)
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(2 + (i - 1) * 8);
            //1st triangle
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(3 + (i - 1) * 8);    
            //2nd triangle
             
            //Top Face (Top Image at Vertices Image Representation folder)
            triangles.Add(4 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(6 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(6 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(7 + (i - 1) * 8); 
            //2nd triangle  

            //Back Face (Back Image at Vertices Image Representation folder)
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(4 + (i - 1) * 8);
            triangles.Add(2 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(2 + (i - 1) * 8);
            triangles.Add(4 + (i - 1) * 8);
            triangles.Add(6 + (i - 1) * 8); 
            //2nd triangle  

            //Front Face (Front Image at Vertices Image Representation folder)
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(7 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(3 + (i - 1) * 8);
            triangles.Add(7 + (i - 1) * 8);
            triangles.Add(1 + (i - 1) * 8); 
            //2nd triangle
            
            //Left Face (Left Image at Vertices Image Representation folder)
            triangles.Add(1 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(0 + (i - 1) * 8);
            //1st triangle 
            triangles.Add(0 + (i - 1) * 8);
            triangles.Add(5 + (i - 1) * 8);
            triangles.Add(4 + (i - 1) * 8); 
            //2nd triangle
            
            //Right Face (Right Image at Vertices Image Representation folder)
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
                
                //X
                Vector3 x1 = new Vector3(d.x1, 0, d.y1); //Base X and Z First values
                Vector3 x2 = new Vector3(d.x2, 0, d.y2); //Base X and Z Second values
                
                Vector3 targetDirX = x1 - x2; // First - Second Base values to do Cross Product(Right hand rule)

                Vector3 resultX = Vector3.Cross(targetDirX.normalized, Vector3.up) * offset; //Base Cross product to get an offset value
                Vector3 resultXAux = resultX + resultX; // Multiplying Base Cross Product by two

                //Y
                Vector3 y1 = new Vector3(d.x1, 70, d.y1); //Top X and Z First values
                Vector3 y2 = new Vector3(d.x2, 70, d.y2); //Top X and Z Second values

                Vector3 targetDirY = y1 - y2; // First - Second Top values to do Cross Product(Right hand rule)
                
                Vector3 resultY = Vector3.Cross(targetDirY.normalized, Vector3.up) * offset; //Top Cross product to get an offset value
                Vector3 resultYAux = resultY + resultY; // Multiplying Top Cross Product by two
                
                //Creating Gizmos
                Gizmos.color = Color.green; //Sphere Color
                Gizmos.DrawSphere(x1, 1f); //Base X and Z First values Sphere Gizmos
                Gizmos.DrawSphere(x2, 1f); //Base X and Z Second values Sphere Gizmos
                Gizmos.DrawSphere(y1, 1f); //Top X and Z First values Sphere Gizmos
               
                Gizmos.color = Color.red; //Spheres and Lines Color
    
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
                Gizmos.DrawSphere(x1 - resultXAux, 1f);
                Gizmos.DrawSphere(x2 - resultXAux, 1f);
                Gizmos.DrawLine  (x1 - resultXAux, x2 - resultXAux);
                
                //Positive Top Offset Values
                Gizmos.DrawSphere(y1 - resultYAux, 1f);
                Gizmos.DrawSphere(y2 - resultYAux, 1f);
                Gizmos.DrawLine(y1 - resultYAux, y2 - resultYAux);
            } 
    }
}
