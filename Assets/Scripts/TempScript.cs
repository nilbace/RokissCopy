using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TempScript : MonoBehaviour
{
    public Transform ABCD;

    void Start()
    {
        print(ABCD.name);

        
        Transform[] tempArray = new Transform[ABCD.childCount];
        for(int i = 0; i<ABCD.childCount;i++)
        {
            tempArray[i] = ABCD.GetChild(i);
            print(tempArray[i].name);
        }
    }

    void Update()
    {
        
    }
}
