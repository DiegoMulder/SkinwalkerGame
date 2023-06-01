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
    [SerializeField] private GameObject gameObjectSkinwalker;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private GameObject deathCamera;
    [SerializeField] private GameObject inGamePanel;
    [Space]
    private float distance;
    public static bool playerDeath = false;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        playerDeath = false;
    }

    // Update is called once per frame
    void Update()
    {
        WalkLogic();
    }

    public void WalkLogic()
	{
        distance = Vector3.Distance(skinwalker.transform.position, player.transform.position);

        if(playerDeath == false)
		{
            if (!dead) skinwalker.SetDestination(player.transform.position);
            else
            {
                skinwalkerAnimator.SetBool("death", true);
                skinwalker.enabled = false;
                hitBox.SetActive(false);
            }

            if (distance >= 30 && dead)
            {
                PigNavmesh.skinwalkerTransform = false;
                skinwalkerAnimator.SetBool("death", false);
                skinwalker.enabled = true;
                hitBox.SetActive(true);
                dead = false;
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
            inGamePanel.SetActive(false);
        }
        else if (distance >= 20 && SkinwalkerParent.isChanged == true && !dead)
        {
            gameObjectSkinwalker.SetActive(false);
            SkinwalkerParent.isChanged = false;
            SkinwalkerParent.canChange = true;
            PigNavmesh.skinwalkerTransform = false;
        }
    }
}
