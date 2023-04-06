using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10.0f;
    void Start()
    {
        Managers.input.KeyAction -= OnKeyBoard;
        Managers.input.KeyAction += OnKeyBoard;
    }

    void OnKeyBoard()
    {
        if(Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(Vector3.forward), 0.09f);
            transform.position += Vector3.forward*Time.deltaTime*_speed;
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(Vector3.back), 0.09f);
            transform.position += Vector3.back*Time.deltaTime*_speed;
        }

        if(Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(Vector3.left), 0.09f);
            transform.position += Vector3.left*Time.deltaTime*_speed;
        }

        if(Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, 
                Quaternion.LookRotation(Vector3.right), 0.09f);
            transform.position += Vector3.right*Time.deltaTime*_speed;
        }
    }
}
