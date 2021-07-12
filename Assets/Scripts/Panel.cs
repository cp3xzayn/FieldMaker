using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{

    /// <summary>
    /// Panelの処理
    /// </summary>
    void IndicatePanels()
    {

    }

    /// <summary>
    /// Panelのサイズを取得する
    /// </summary>
    /// <param name="gameObject"></param>
    /// <returns>Objectのサイズ</returns>
    Vector3 GetPanelSize(GameObject gameObject)
    {
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
        Bounds bounds = mesh.bounds;
        Vector3 objSize = bounds.size;

        return objSize;
    }
    
    /// <summary>
    /// 2つのObjectの距離を取得し返す
    /// </summary>
    /// <param name="baseObjSize">起点となるObject</param>
    /// <param name="objSize">距離を測るためのObject</param>
    /// <returns>距離</returns>
    float DistanceFromTo(float baseObjSize, float objSize)
    {
        float distance = (baseObjSize + objSize) / 2;
        return distance;
    }
}