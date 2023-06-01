using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCwalk : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agentNPC;
    [SerializeField] private float walkingRange;
    // Start is called before the first frame update
    void Start() => agentNPC = GetComponent<NavMeshAgent>();

    // Update is called once per frame
    void Update() => RoamingBehaviour();

    private Vector3 RandomPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * walkingRange;
        Vector3 newRandomPosition = transform.position + randomPos;
        return newRandomPosition;
    }

    private void RoamingBehaviour()
    {
        if (agentNPC.hasPath == false)
        {
            agentNPC.SetDestination(RandomPosition());
            return;
        }
    }
}
