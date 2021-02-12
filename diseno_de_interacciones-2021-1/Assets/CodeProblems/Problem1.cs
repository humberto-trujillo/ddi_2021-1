using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Problem1 : MonoBehaviour
{
    void Start()
    {
        int[] nums = {8,1,2,2,3};
        int[] output = NumbersLessThan(nums);
        foreach (var num in output)
        {
            Debug.Log(num);
        }
    }

    //Investigar complejidad de tiempo - orden del algoritmo - tiempo de ejecución
    // time complexity
    // O(n) -> lineal
    // O(n^2) -> cuadratica 
    private int[] NumbersLessThan(int[] nums)
    {
        // generar output
        return nums;
    }
}
