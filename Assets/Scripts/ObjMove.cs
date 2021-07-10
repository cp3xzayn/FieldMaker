using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    /// <summary> 選択されたObject </summary>
    GameObject m_selectObject;

    void Update()
    {
        switch (FieldMaker.Instance.State)
        {
            case FieldMakeState.SelectObject:
                ObjectSelect();
                break;
            case FieldMakeState.ChangeState:
                ObjectSelect();
                break;
            default:
                break;
        }
    }


    /// <summary>
    /// Objectを選択する処理
    /// </summary>
    void ObjectSelect()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10.0f))
        {
            if (Input.GetMouseButtonDown(0))
            {
                m_selectObject = hit.collider.gameObject;
                m_selectObject.GetComponent<Renderer>().material.color = Color.red;
                Debug.Log("選択" + m_selectObject.name);
                FieldMaker.Instance.SetState(FieldMakeState.ChangeState);
            }
        }
    }

    /// <summary>
    /// 選択したObjectを移動する処理
    /// </summary>
    void ObjectMove()
    {

    }
}

