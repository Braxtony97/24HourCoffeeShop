using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class GirlController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Animator _animator;

    private readonly int _crawlTriggerHash = Animator.StringToHash("Crawl");
    private readonly int _idleTriggerHash = Animator.StringToHash("Idle");

    private Coroutine _movementCoroutine;

    public void MoveTo(Transform point)
    {
        if (_movementCoroutine != null)
            StopCoroutine(_movementCoroutine);

        _agent.destination = point.position;
        _animator.SetTrigger(_crawlTriggerHash);

        _movementCoroutine = StartCoroutine(WaitForDestination());
    }

    private IEnumerator WaitForDestination()
    {
        while (_agent.pathPending)
            yield return null;

        while (_agent.remainingDistance > _agent.stoppingDistance)
            yield return null;

        _animator.SetTrigger(_idleTriggerHash);
    }
}
