using UnityEngine;

public class CameraTracking : MonoBehaviour
{
    private const string TAG_DOOR = "Door";

    void Update()
    {
        OnTouchDown();
    }

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
                if (hit.collider.gameObject.tag == TAG_DOOR)
                {
                    hit.collider.gameObject.GetComponent<DoorAnimator>().OpenDoor();
                }
            }

        }
    }
}
