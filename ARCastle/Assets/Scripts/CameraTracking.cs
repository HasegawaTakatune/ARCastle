using UnityEngine;

/// <summary>
/// カメラトラッキング
/// </summary>
public class CameraTracking : MonoBehaviour
{
    /// <summary>
    /// タグ　ドア
    /// </summary>
    private const string TAG_DOOR = "Door";

    /// <summary>
    /// タグ　ユニティちゃん
    /// </summary>
    private const string TAG_UNITYCHAN = "UnityChan";

    /// <summary>
    /// メインループ
    /// </summary>
    void Update()
    {
        OnTouchDown();
    }

    /// <summary>
    /// 画面タッチイベント
    /// </summary>
    void OnTouchDown()
    {
        if (Input.touchCount < 0)
            return;

        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(ray, out hit))
            {
                switch (hit.collider.gameObject.tag)
                {
                    case TAG_DOOR:
                        hit.collider.gameObject.GetComponent<DoorAnimator>().OpenDoor();
                        break;

                    case TAG_UNITYCHAN:
                        hit.collider.gameObject.GetComponent<Agent>().CallAppealTime();
                        break;
                }
            }
        }
    }
}
