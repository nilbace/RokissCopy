using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UI_Button : UI_Base
{   
    enum Buttons{
        PointButton,
    }
    enum Texts{
        PointText,
        ScoreText,
    }

    enum GameObjects{
        TestObject,
    }

    enum Images
    {
        ItemIcon,
    }

    private void Start() {
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));
        Bind<GameObject>(typeof(GameObjects));
        Bind<Image>(typeof(Images));

        GetText((int)Texts.ScoreText).text = "Bind Test";

        GameObject go = GetImage((int)Images.ItemIcon).gameObject;
        AddUIEvent(go, (PointerEventData data) => { go.transform.position = data.position; } , Define.UIEvent.Drag);
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objeects.Add(typeof(T), objects);

        for(int i = 0; i < names.Length; i++)
        {
            if(typeof(T)==typeof(GameObject))
                objects[i] = Util.FindChild(gameObject, names[i], true);
            else
                objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    

    int _score = 0;
}
