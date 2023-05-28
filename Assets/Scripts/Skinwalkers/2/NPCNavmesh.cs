using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCNavmesh : MonoBehaviour
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
    [SerializeField] private GameObject NPCSkinwalker;
    [SerializeField] private GameObject gameObjectSkinwalker;
    [Space]
    private float distance;
    [SerializeField] private float attackTimer;
    [SerializeField] private float walkingRange;
    [Space]
    [SerializeField] private float minimumRandomValue = 10;
    [SerializeField] private float maximumRandomValue = 120;

    // Start is called before the first frame update
    void Start()
    {
        attackTimer = Random.Range(minimumRandomValue, maximumRandomValue);
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

            if (distance <= 4 && !dead)
            {
                NPCSkinwalker.SetActive(false);
                gameObjectSkinwalker.SetActive(true);
                skinwalker.speed = 0;
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
