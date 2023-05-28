using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkinwalkerTrueForm : MonoBehaviour
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
    [SerializeField] private GameObject pigSkinwalker;
    [SerializeField] private GameObject gameObjectSkinwalker;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject deathCamera;
    [Space]
    private float distance;
    private bool playerDeath = false;
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

        if (playerDeath == false)
        {
            if (!dead) skinwalker.SetDestination(player.transform.position);
            else
            {
                skinwalkerAnimator.SetTrigger("death");
                skinwalker.enabled = false;
                hitBox.SetActive(false);
            }
        }

        if (distance <= 1.5f && !dead)
        {
            skinwalkerAnimator.SetTrigger("kill");
            Debug.Log("Grabbed");
            mainCamera.SetActive(false);
            deathCamera.SetActive(true);
            player.gameObject.SetActive(false);
            skinwalker.angularSpeed = 0;
            playerDeath = true;
        }
    }
}
