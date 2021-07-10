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

    private FieldMakeState m_state;

    public FieldMakeState State => m_state;

    void Awake()
    {
        m_instance = this;
        m_state = FieldMakeState.SelectObject;
    }

    /// <summary>
    /// GameObjectを生成するボタンが押された時の処理
    /// </summary>
    /// <param name="objName"></param>
    public void OnClickInstantiate(string objName)
    {
        Instantiate(Resources.Load<GameObject>(objName));
    }

    /// <summary>
    /// stateを変更する
    /// </summary>
    /// <param name="state"></param>
    public void SetState(FieldMakeState state)
    {
        m_state = state;
        OnChangeState(state);
    }

    /// <summary>
    /// stateが変わったときに一度だけ呼ばれる処理
    /// </summary>
    /// <param name="state"></param>
    public void OnChangeState(FieldMakeState state)
    {
        switch (state)
        {
            case FieldMakeState.SelectObject:
                Debug.Log("FieldMakeState.SelectObject");
                break;
            case FieldMakeState.ChangeState:
                Debug.Log("FieldMakeState.ChangeState");
                break;
            default:
                break;
        }
    }
}

/// <summary>
/// 現在の状態
/// </summary>
public enum FieldMakeState
{
    /// <summary> Objectを選択するState </summary>
    SelectObject,
    /// <summary> Objectの大きさ、位置を変更する </summary>
    ChangeState
}
