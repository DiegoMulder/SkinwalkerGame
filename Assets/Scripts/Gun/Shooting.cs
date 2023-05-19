using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private AudioSource shotSound;
    [SerializeField] private Animator gunAnimator;
    private bool canShoot = true;
    private float timer = 1;
    [Space]
    private Ray ray;
    // Update is called once per frame
    void Update()
    {
        ShotLogic();
        TimerLogic();
    }

    public void ShotLogic()
	{
		if (canShoot)
		{
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                canShoot = false;
                shotSound.Play();
                gunAnimator.SetBool("shot", true);
                Debug.Log("Shot");

                ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
                RaycastHit hitInfo;
                if (Physics.Raycast(ray, out hitInfo))
                {
                    if (hitInfo.collider.gameObject.tag == "skinwalker")
                    {
                        Debug.Log("Hit");
                        Navmesh.dead = true;
                    }
                }
            }
        }
    }

    public void TimerLogic()
	{
		if (!canShoot)
		{
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = 1;
                gunAnimator.SetBool("shot", false);
                canShoot = true;
            }
        }
    }
}