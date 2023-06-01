using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickSwap : MonoBehaviour
{
    [SerializeField] private GameObject gunParent;
    [SerializeField] private GameObject pistolTekst;
    public static bool gunSwap = false;
    [Space]
    public static bool canUsePistol = false;
    private float tekstTimer = 3;
    private bool timerTekstBool = false;
    // Start is called before the first frame update
    void Start()
    {
        gunSwap = false;
        canUsePistol = false;
        timerTekstBool = false;
    }

    // Update is called once per frame
    void Update()
    {
        SwapLogic();
    }

    public void SwapLogic()
	{
        if (timerTekstBool && !canUsePistol)
        {
            tekstTimer -= Time.deltaTime;
            pistolTekst.SetActive(true);
        }
        else pistolTekst.SetActive(false);

        if (tekstTimer <= 0)
		{
            pistolTekst.SetActive(false);
            tekstTimer = 3;
            timerTekstBool = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha1) && canUsePistol)
        {
            gunSwap = !gunSwap;
            if (gunSwap) gunParent.SetActive(true);
            else gunParent.SetActive(false);
            pistolTekst.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1) && !timerTekstBool && !canUsePistol)
        {
            timerTekstBool = true;
        }
	}
}
