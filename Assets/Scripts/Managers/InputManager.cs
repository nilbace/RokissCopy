using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;
    public Action<Define.MouseEvent> MouseAction = null;

    bool _Pressed = false;

    public void OnUpdate() 
    {
        if(Input.anyKey && KeyAction != null)
            KeyAction.Invoke();

        if(MouseAction != null)
        {
            if(Input.GetMouseButton(0))
            {
                MouseAction.Invoke(Define.MouseEvent.Press);
                _Pressed = true;
            }
            else
            {
                if(_Pressed)
                    MouseAction.Invoke(Define.MouseEvent.Click);
                _Pressed = false;
            }
        }
    }
}
