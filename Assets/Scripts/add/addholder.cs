using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class addholder : MonoBehaviour
{
    [SerializeField] Holder holderprefap;
    Holder[,] holder = new Holder[5, 2];
    
    Vector3 hold = new Vector3(-2, 1.3f,0);
    int m = 0, n = 0,z=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnClickAdd()
    {
        if (n == 2) return;
        holder[m, n] = Instantiate(holderprefap, hold, Quaternion.identity);
        hold.x++;
        m++;
        if (m == 5)
        {
            hold.x = -2;
            hold.y = -1.5f;
            m = 0;
            n++;
        }

        z++;
        Debug.Log(m+","+n+","+z);
    }
    
}
