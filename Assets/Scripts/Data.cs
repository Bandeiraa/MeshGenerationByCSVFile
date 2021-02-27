using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data 
{
    /*public int x1;
    public int y1;
    public int z1;

    public int x2;
    public int y2;
    public int z2;

    public int x3;
    public int y3;
    public int z3;

    public int x4;
    public int y4;
    public int z4;
    */
    public int x1;
    public int y1;
    public int x2;
    public int y2;

    public void ChangeScale(float newScale)
    {
        y1 = (int) ( y1 / newScale);
        x1 = (int) ( x1 / newScale);
        y2 = (int) ( y2 / newScale);
        x2 = (int) ( x2 / newScale); 
    }

}
