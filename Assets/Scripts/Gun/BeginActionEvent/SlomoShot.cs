using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlomoShot : MonoBehaviour
{
    [SerializeField] private GameObject skinwalker;
    [Space]
    [SerializeField] private GameObject player;

    private float distance;

    [SerializeField] private GameObject inputText;

    private Ray ray;
    // Update is called once per frame
    void Update()
    {
        ShoterAction();
    }

    public void ShoterAction()
    {
        distance = Vector3.Distance(skinwalker.transform.position, player.transform.position);

        if (distance <= 4 && PigNavmesh.dead == false && TrueForm2.playerDeath == false) Time.timeScale = 0.5f;
        else Time.timeScale = 1;

        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
		{
            if(distance <= 4)
			{
                if (hitInfo.collider.gameObject.tag == "skinwalker") inputText.SetActive(true);
                else if (hitInfo.collider.gameObject.tag == "skinwalker2") inputText.SetActive(true);
                else inputText.SetActive(false);
            }
        }
    }
}
