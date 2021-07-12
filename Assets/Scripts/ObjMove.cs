using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMove : MonoBehaviour
{
    /// <summary> 選択されたObject </summary>
    GameObject m_selectObject;
    /// <summary> 選択されたObjectのポジション </summary>
    private Vector3 m_objectPos;
    public Vector3 ObjectPos => m_objectPos;
    /// <summary> 選択されたObjectのサイズ </summary>
    Vector3 m_objectSize;

    /// <summary> Objectが選択されたかどうか </summary>
    bool isGrabbing = false;
    /// <summary> 現在のSetPhaseの状態 </summary>
    private SetPhase m_phase;
    /// <summary> 現在のSetPhaseの状態 </summary>
    public SetPhase Phase => m_phase;

    void Start()
    {
        SetSetPhase(SetPhase.Initialize);
    }

    void Update()
    {
        ObjectMove();
    }

    /// <summary>
    /// SetPhaseの変更を行う
    /// </summary>
    /// <param name="phase"></param>
    public void SetSetPhase(SetPhase phase)
    {
        m_phase = phase;
        OnChangeSetPhase(phase);
    }

    /// <summary>
    /// SetPhaseが変わったとき一度だけ呼ばれる処理
    /// </summary>
    /// <param name="phase"></param>
    void OnChangeSetPhase(SetPhase phase)
    {
        switch (phase)
        {
            case SetPhase.Initialize:
                Debug.Log(m_phase);
                SetSetPhase(SetPhase.XYSet);
                break;
            case SetPhase.XYSet:
                Debug.Log(m_phase);
                break;
            case SetPhase.YZSet:
                break;
            case SetPhase.SetEnd:
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// 選択したObjectを移動する処理
    /// </summary>
    void ObjectMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Object")
                {
                    m_selectObject = hit.collider.gameObject;
                    m_selectObject.GetComponent<Renderer>().material.color = Color.red;
                    Debug.Log("選択" + m_selectObject.name);
                    isGrabbing = true;
                }
            }
        }

        if (isGrabbing)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Panel")
                {
                    if (m_phase == SetPhase.XYSet)
                    {
                        m_selectObject.transform.position
                            = new Vector3(hit.point.x, hit.point.y,
                            hit.point.z - ObjectSize(m_selectObject).z / 2);
                    }
                    else if (m_phase == SetPhase.YZSet)
                    {
                        m_selectObject.transform.position
                            = new Vector3(hit.point.x - ObjectSize(m_selectObject).x / 2,
                            hit.point.y, hit.point.z);
                    }
                }

                if (Input.GetMouseButtonUp(0))
                {
                    Debug.Log("Objectを離しました。");
                    m_objectPos = m_selectObject.transform.position;
                    isGrabbing = false;
                }
            }
        }
    }

    /// <summary>
    /// Objectのサイズを返す
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    Vector3 ObjectSize(GameObject obj)
    {
        MeshRenderer mesh = obj.GetComponent<MeshRenderer>();
        Bounds bounds = mesh.bounds;
        m_objectSize = bounds.size;
        return m_objectSize;
        
    }

    public void OnClickXYSet()
    {

    }

    public void OnClickYZSet()
    {

    }
}


/// <summary>
/// Objectを設置するときの状態
/// </summary>
public enum SetPhase
{
    Initialize,
    XYSet,
    YZSet,
    SetEnd
}

