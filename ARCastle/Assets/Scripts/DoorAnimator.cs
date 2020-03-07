using UnityEngine;

public class DoorAnimator : MonoBehaviour
{
    private bool isCalled = false;
    [SerializeField] private Animator[] door = new Animator[2];

    public void OpenDoor()
    {
        if (isCalled)
            return;

        foreach (Animator animator in door)
            animator.SetBool("Open", true);
        openCallBack();
        isCalled = true;
    }

    private void OnTriggerEnter(Collider collider)
    {
        OpenDoor();
    }

    public delegate void OpenCallBack();
    private OpenCallBack openCallBack;
    public void AddOpenCallback(OpenCallBack callBack)
    {
        openCallBack += callBack;
    }

}
