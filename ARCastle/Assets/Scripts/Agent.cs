using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private const string PARAMETER_SPEED = "Speed";
    private const string PARAMETER_LOOKME = "LookMe";

    [SerializeField] private DoorAnimator door = default;

    [SerializeField] private Transform waitingPoint = default;

    private NavMeshAgent navMeshAgent = default;
    private Animator animator = default;
    private bool isAppeal = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        door.AddOpenCallback(OpenDoorCallback);
        StartCoroutine(LookAtMainCamera());
    }

    void Update()
    {
    }

    private IEnumerator OnMoveAction()
    {
        animator.SetFloat(PARAMETER_SPEED, 0.2f);

        while (0.1f < navMeshAgent.remainingDistance)
            yield return null;

        animator.SetFloat(PARAMETER_SPEED, 0.0f);
        StartCoroutine(LookAtMainCamera());
    }

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

    private IEnumerator AppealTime()
    {
        if (isAppeal)
            yield break;

        isAppeal = true;

        navMeshAgent.isStopped = true;
        animator.SetTrigger(PARAMETER_LOOKME);

        yield return null;
        yield return new WaitForAnimation(animator, 0);

        navMeshAgent.isStopped = false;
        isAppeal = false;
    }

    private void OpenDoorCallback()
    {
        if (navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            navMeshAgent.SetDestination(waitingPoint.position);
            StartCoroutine(OnMoveAction());
        }
    }
}
