using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balltest : MonoBehaviour
{
    GameObject Ball;
    void Start()
    {
        Ball = Managers.Resource.Instantiate("Ball");
        Destroy(Ball, 3.0f);
    }

    void Update()
    {
        
    }
}
