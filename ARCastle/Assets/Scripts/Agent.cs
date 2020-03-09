using System.Collections;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// ナビメッシュエージェント制御
/// </summary>
public class Agent : MonoBehaviour
{
    /// <summary>
    /// パラメタ　スピード
    /// </summary>
    private const string PARAMETER_SPEED = "Speed";
    /// <summary>
    /// パラメタ　アピール
    /// </summary>
    private const string PARAMETER_LOOKME = "LookMe";

    /// <summary>
    /// ドア開閉アニメーション
    /// </summary>
    [SerializeField] private DoorAnimator door = default;

    /// <summary>
    /// 待機位置
    /// </summary>
    [SerializeField] private Transform waitingPoint = default;

    /// <summary>
    /// ナビメッシュ
    /// </summary>
    private NavMeshAgent navMeshAgent = default;

    /// <summary>
    /// アニメーター
    /// </summary>
    private Animator animator = default;

    /// <summary>
    /// アピール判定
    /// </summary>
    private bool isAppeal = false;

    /// <summary>
    /// 初期化
    /// </summary>
    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        door.AddOpenCallback(OpenDoorCallback);
    }

    /// <summary>
    /// 初期化
    /// </summary>
    public void Init(DoorAnimator door, Transform waitingPoint)
    {
        this.door = door;
        this.waitingPoint = waitingPoint;
    }

    /// <summary>
    /// キャラクタ移動中処理
    /// </summary>
    private IEnumerator OnMoveAction()
    {
        animator.SetFloat(PARAMETER_SPEED, 0.2f);

        yield return null;
        while (0.1f < navMeshAgent.remainingDistance) yield return null;

        navMeshAgent.isStopped = true;
        animator.SetFloat(PARAMETER_SPEED, 0.0f);
        StartCoroutine(LookAtMainCamera());
    }

    /// <summary>
    /// カメラの方に向く
    /// </summary>
    private IEnumerator LookAtMainCamera()
    {
        Transform cameraTrans = Camera.main.transform;
        Vector3 point = Vector3.zero;
        float positionY = transform.position.y;

        while (navMeshAgent.remainingDistance < 0.1f)
        {
            point = cameraTrans.position;
            point.y = positionY;
            transform.LookAt(point);

            yield return null;
        }
    }

    /// <summary>
    /// アピールタイム呼び出し
    /// </summary>
    public void CallAppealTime()
    {
        if (navMeshAgent.remainingDistance < 0.1f)
            StartCoroutine(AppealTime());
    }

    /// <summary>
    /// アピールタイム
    /// </summary>
    /// <returns></returns>
    private IEnumerator AppealTime()
    {
        if (isAppeal) yield break;

        isAppeal = true;

        navMeshAgent.isStopped = true;
        animator.SetTrigger(PARAMETER_LOOKME);

        // アニメータのステート変更に1フレーム待つ
        yield return null;
        yield return new WaitForAnimation(animator, 0);

        navMeshAgent.isStopped = false;
        isAppeal = false;
    }

    /// <summary>
    /// ドア開閉のコールバックイベント
    /// ドアが開いたら待ち受け位置に移動する
    /// </summary>
    private void OpenDoorCallback()
    {
        navMeshAgent.enabled = true;

        if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            navMeshAgent.SetDestination(waitingPoint.position);
            StartCoroutine(OnMoveAction());
        }
    }
}
