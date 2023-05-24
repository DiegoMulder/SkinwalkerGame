using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class TrueForm2 : MonoBehaviour
{
    [SerializeField] private NavMeshAgent skinwalker;
    [Space]
    [SerializeField] private Transform player;
    [Space]
    public static bool dead = false;
    [Space]
    [SerializeField] private Animator skinwalkerAnimator;
    [Space]
    [SerializeField] private GameObject hitBox;
    [SerializeField] private GameObject NPCSkinwalker;
    [SerializeField] private GameObject gameObjectSkinwalker;
    [Space]
    private float distance;

    // Start is called before the first frame update
    void Start()
    {
        dead = false;
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

        if (distance <= 4.5 && !dead)
        {
            NPCSkinwalker.SetActive(false);
            gameObjectSkinwalker.SetActive(true);
        }
    }
}
