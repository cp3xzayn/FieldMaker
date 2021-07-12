using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMaker : MonoBehaviour
{
    /// <summary> FieldMakerのインスタンス </summary>
    private static FieldMaker m_instance;
    /// <summary> FieldMakerのインスタンス </summary>
    public static FieldMaker Instance => m_instance;

    private FieldMaker() { }
    /// <summary>
    /// GameObjectを生成するボタンが押された時の処理
    /// </summary>
    /// <param name="objName"></param>
    public void OnClickInstantiate(string objName)
    {
        Instantiate(Resources.Load<GameObject>(objName));
    }


}