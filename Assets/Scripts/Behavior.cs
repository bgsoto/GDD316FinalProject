using System.Collections;
using System.Collections.Generic;
using System.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;



public class Behavior : MonoBehaviour
{
   [SerializeField] public Transform[] checkpoints; // Set these in the inspector
    [SerializeField] private int currentCheckpoint = 0;

    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private enum State { Idle, Moving, Waiting, Arrived };
    [SerializeField] private State state = State.Idle;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        switch (state)
        {
            case State.Idle:
                if (checkpoints.Length > 0)
                {
                    agent.SetDestination(checkpoints[currentCheckpoint].position);
                    state = State.Moving;
                }
                break;

            case State.Moving:
                if (!agent.pathPending)
                {
                    if (agent.remainingDistance <= agent.stoppingDistance)
                    {
                        if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                        {
                            state = State.Waiting;
                            StartCoroutine(WaitAtCheckpoint(3.0f));
                        }
                    }
                }
                break;

            case State.Waiting:
                // Waiting is handled by the coroutine.
                break;

            case State.Arrived:
                currentCheckpoint = (currentCheckpoint + 1) % checkpoints.Length;
                state = State.Idle;
                break;
        }
    }

    private IEnumerator WaitAtCheckpoint(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        state = State.Arrived;
    }
}
