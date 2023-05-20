using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PigNavmesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent skinwalker;
    [Space]
    [SerializeField] private Transform player;
    [Space]
    public static bool dead = false;
    private bool skinwalkerTransform = false;
    [Space]
    [SerializeField] private Animator skinwalkerAnimator;
    [Space]
    [SerializeField] private GameObject hitBox;
    [SerializeField] private GameObject pigSkinwalker;
    [SerializeField] private GameObject gameObjectSkinwalker;
    [Space]
    private float distance;
    [SerializeField] private float attackTimer;
    [SerializeField] private float walkingRange;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = Random.Range(10, 120);
        skinwalkerTransform = false;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        WalkLogic();
        AttackTimerLogic();
    }

    public void WalkLogic()
	{
        distance = Vector3.Distance(skinwalker.transform.position, player.transform.position);

		if (skinwalkerTransform)
		{
            if (!dead) skinwalker.SetDestination(player.transform.position);
            else
            {
                skinwalkerAnimator.SetTrigger("death");
                skinwalker.enabled = false;
                hitBox.SetActive(false);
            }

            if (distance <= 4.5 && !dead)
            {
                pigSkinwalker.SetActive(false);
                gameObjectSkinwalker.SetActive(true);
            }
            else if (distance >= 5f && !dead)
            {
                pigSkinwalker.SetActive(true);
                gameObjectSkinwalker.SetActive(false);
            }
        }
        else RoamingBehaviour();
    }

    public void AttackTimerLogic()
	{
		if (!skinwalkerTransform)
		{
            attackTimer -= Time.deltaTime;

            if (attackTimer < 0)
            {
                attackTimer = 0;
                skinwalkerTransform = true;
            }
        }
	}

    private Vector3 RandomPosition()
    {
        Vector3 randomPos = Random.insideUnitSphere * walkingRange;

        Vector3 newRandomPosition = transform.position + randomPos;

        return newRandomPosition;
    }

    private void RoamingBehaviour()
    {
        if (skinwalker.hasPath == false)
        {
            skinwalker.SetDestination(RandomPosition());
            return;
        }
    }
}