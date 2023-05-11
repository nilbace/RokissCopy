using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;

public class UI_Button : MonoBehaviour
{   
    Dictionary<Type, UnityEngine.Object[]> _objeects = new Dictionary<Type, UnityEngine.Object[]>();


    enum Buttons{
        PointButton,
    }
    enum Texts{
        PointText,
        ScoreText,
    }

    private void Start() {
        Bind<Button>(typeof(Buttons));
        Bind<TMP_Text>(typeof(Texts));

        Get<TMP_Text>((int)Texts.ScoreText).text = "Bind Test";
    }

    void Bind<T>(Type type) where T : UnityEngine.Object
    {
        string[] names = Enum.GetNames(type);

        UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
        _objeects.Add(typeof(T), objects);

        for(int i = 0; i < names.Length; i++)
        {
            objects[i] = Util.FindChild<T>(gameObject, names[i], true);
        }
    }

    T Get<T>(int idx) where T : UnityEngine.Object
    {
        UnityEngine.Object[] objects = null;
        if(_objeects.TryGetValue(typeof(T), out objects) == false)
            return null;

        return objects[idx] as T;
    }

    int _score = 0;
}
