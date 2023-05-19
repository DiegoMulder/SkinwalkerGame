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
    [SerializeField] private GameObject hitBox;
    [Space]
    private float distance;
    [SerializeField] private GameObject pigSkinwalker;
    [SerializeField] private GameObject gameObjectSkinwalker;
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
        distance = Vector3.Distance(skinwalker.transform.position, player.transform.position);

        if (!dead) skinwalker.SetDestination(player.transform.position);
		else
		{
            skinwalkerAnimator.SetTrigger("death");
            skinwalker.enabled = false;
            hitBox.SetActive(false);
        }

        if(distance <= 4.5 && !dead)
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
}
