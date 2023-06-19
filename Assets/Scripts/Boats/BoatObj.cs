using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BoatObj : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private List<Vector3> _npcPoints;
    public int _target;
    private bool _canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        SetNewDestination();
    }

    private void SetNewDestination()
    {
        if (_canMove)
        {
            if (transform.position.x == _npcPoints[_target].x &&
                transform.position.z == _npcPoints[_target].z)
            {
                if (_target - 1 <= _npcPoints.Count)
                {
                    _target += 1;
                    _navMeshAgent.SetDestination(_npcPoints[_target]);
                }
                else
                {
                    _target = 0;
                }
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _canMove = true;
            _navMeshAgent.SetDestination(_npcPoints[_target]);
        }
    }
}
