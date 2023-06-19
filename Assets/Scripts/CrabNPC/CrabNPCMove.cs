using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.AI;

public class CrabNPCMove : MonoBehaviour
{
    [SerializeField] private float minimumWaitingTime = 1;
    [SerializeField] private float maximumWaitingTime = 10;

    private CharacterController _crabController;

    private NavMeshAgent _navMeshAgent;
    [SerializeField] private List<Transform> _npcPoints;
    public int _target;

    [FormerlySerializedAs("NPCSpeed")] [SerializeField]
    private float npcSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _crabController = GetComponent<CharacterController>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _navMeshAgent.SetDestination(_npcPoints[_target].position);
        
    }

    private void Update()
    {
        if (transform.position.x == _npcPoints[_target].position.x && transform.position.z == _npcPoints[_target].position.z)
        {
            if (_target - 1  < _npcPoints.Count)
            {
                _target += 1;
                _navMeshAgent.SetDestination(_npcPoints[_target].position);
            }
            else
            {
                _target = 0;
            }
        }
    }
}



