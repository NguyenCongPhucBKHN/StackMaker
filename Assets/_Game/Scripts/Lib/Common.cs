using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Common {
    public static int MathMod(int a, int b) 
    {
        return (Mathf.Abs(a * b) + a) % b;
    }
   
}
