using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float _speed = 10.0f;
    bool _moveToDest = false;
    Vector3 _destPoz;
    Animator _anim;
    void Start()
    {
        _anim = GetComponent<Animator>();
        Managers.input.KeyAction -= OnKeyBoard;
        Managers.input.KeyAction += OnKeyBoard;
        Managers.input.MouseAction -= OnMouseClicked;
        Managers.input.MouseAction += OnMouseClicked;
    }

    private void Update() {
        if(_moveToDest)
        {
            Vector3 dir = _destPoz - transform.position;
            if(dir.magnitude < 0.01f)
            {
                _moveToDest = false;
            }
            else
            {
                float _moveDist = Mathf.Clamp(_speed * Time.deltaTime,0,dir.magnitude);
                transform.position = transform.position + dir.normalized*_speed*Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), 10*Time.deltaTime);
            }
        }

        if(_moveToDest)
        {
            _anim.Play("Run");
        }
        else
        {
            _anim.Play("Wait");
        }
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

        _moveToDest = false;
    }


    void OnMouseClicked(Define.MouseEvent evt)
    {
        /* if(evt != Define.MouseEvent.Click)
            return;
 */

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(Camera.main.transform.position, ray.direction*100f, Color.red, 1.0f);

        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, 100f, LayerMask.GetMask("Wall")))
        {
            _destPoz = hit.point;
            _moveToDest = true;
        }
    }
}
