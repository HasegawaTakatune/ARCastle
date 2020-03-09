using GoogleARCore;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ARトラッキング処理
/// </summary>
public class ARTracker : MonoBehaviour
{
    /// <summary>
    /// 座標調整値
    /// </summary>
    private const int ABJUST = 4;

    /// <summary>
    /// マーカーを格納する
    /// </summary>
    private List<AugmentedImage> augmentedImages = new List<AugmentedImage>();

    /// <summary>
    /// マーカー認識時に表示する
    /// </summary>
    [SerializeField] private GameObject prefab = default;

    /// <summary>
    /// 生成判定
    /// </summary>
    private bool isCreated = false;

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {
        if (Session.Status != SessionStatus.Tracking) return;

        Session.GetTrackables(augmentedImages, TrackableQueryFilter.Updated);

        foreach (AugmentedImage image in augmentedImages)
        {
            if (image.TrackingState == TrackingState.Tracking)
            {
                Pose center = image.CenterPose;
                if (!isCreated)
                {
                    isCreated = true;
                    prefab.transform.position = center.position + (center.forward * -3) + (center.up / ABJUST) + (center.right / ABJUST);
                    prefab.transform.rotation = Quaternion.Euler(new Vector3(0, center.rotation.eulerAngles.y, 0));
                    prefab.SetActive(true);
                }
                else
                {
                    prefab.transform.position = center.position + (center.forward * -3) + (center.up / ABJUST) + (center.right / ABJUST);
                    prefab.transform.rotation = Quaternion.Euler(new Vector3(0, center.rotation.eulerAngles.y, 0));
                }
            }
        }
    }
}
