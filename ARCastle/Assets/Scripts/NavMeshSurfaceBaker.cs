using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ナビメッシュを動的に生成する
/// </summary>
[RequireComponent(typeof(NavMeshSurface))]
public class NavMeshSurfaceBaker : MonoBehaviour
{
    /// <summary>
    /// ナビメッシュサーフェス
    /// </summary>
    NavMeshSurface surface;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        StartCoroutine(TimeUpdate());
    }

    /// <summary>
    /// 一定間隔でメッシュの生成を繰り返す
    /// </summary>
    IEnumerator TimeUpdate()
    {
        while (true)
        {
            surface.BuildNavMesh();
            yield return new WaitForSeconds(5.0f);
        }
    }
}