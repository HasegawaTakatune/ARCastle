using UnityEngine;

/// <summary>
/// ドアアニメーション制御
/// </summary>
public class DoorAnimator : MonoBehaviour
{
    /// <summary>
    /// コール判定
    /// </summary>
    private bool isCalled = false;

    /// <summary>
    /// ドアアニメータを格納
    /// </summary>
    [SerializeField] private Animator[] door = new Animator[2];

    /// <summary>
    /// ドアを開く
    /// </summary>
    public void OpenDoor()
    {
        if (isCalled) return;

        foreach (Animator animator in door)
            animator.SetBool("Open", true);

        openCallBack();
        isCalled = true;
    }

    /// <summary>
    /// ドアを開く
    /// </summary>
    private void OnTriggerEnter()
    {
        OpenDoor();
    }

    /// <summary>
    /// ドアを開いた後のコールバックイベント
    /// </summary>
    public delegate void OpenCallBack();
    private OpenCallBack openCallBack;

    /// <summary>
    /// ドアを開いた後に呼ばれる処理の追加
    /// </summary>
    public void AddOpenCallback(OpenCallBack callBack)
    {
        openCallBack += callBack;
    }

}
