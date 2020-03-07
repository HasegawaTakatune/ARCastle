using GoogleARCore;
using System.Collections.Generic;
using UnityEngine;

public class ARTracker : MonoBehaviour
{
    private List<AugmentedImage> augmentedImages = new List<AugmentedImage>();

    [SerializeField] private GameObject prefab = default;

    void Update()
    {
        if (Session.Status != SessionStatus.Tracking)
        {
            return;
        }

        Session.GetTrackables<AugmentedImage>(augmentedImages, TrackableQueryFilter.Updated);

        foreach (AugmentedImage image in augmentedImages)
        {
            if (image.TrackingState == TrackingState.Tracking)
            {
                if (!prefab.activeSelf)
                {
                    Anchor anchor = image.CreateAnchor(image.CenterPose);
                    prefab.transform.parent = anchor.transform;
                    prefab.transform.position = image.CenterPose.position + (image.CenterPose.forward * -3);
                    prefab.transform.rotation = image.CenterPose.rotation;
                    prefab.SetActive(true);
                }
            }
        }
    }
}
