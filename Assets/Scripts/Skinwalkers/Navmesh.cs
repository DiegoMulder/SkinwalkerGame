using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navmesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent skinwalker;
    [SerializeField] private Transform player;
    [Space]
    public static bool dead = false;
    [Space]
    [SerializeField] private Animator skinwalkerAnimator;
    [SerializeField] private CapsuleCollider hitBox;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WalkLogic();
    }

    public void WalkLogic()
	{
        if (!dead) skinwalker.SetDestination(player.transform.position);
		else
		{
            skinwalkerAnimator.SetTrigger("death");
            skinwalker.enabled = false;
            hitBox.enabled = false;
        }
    }
}
