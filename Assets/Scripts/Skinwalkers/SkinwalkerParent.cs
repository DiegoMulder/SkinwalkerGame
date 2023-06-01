using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinwalkerParent : MonoBehaviour
{
    private int randomNumber = 0;
    [SerializeField] private GameObject disguise1, disguise2, disguise3;
    public static bool canChange = false;
    public static bool isChanged = false;
    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 4);
        canChange = false;
        isChanged = false;
    }

    // Update is called once per frame
    void Update()
    {
        SkinwalkerDisguiseLogic();
    }

    public void SkinwalkerDisguiseLogic()
	{
        if(canChange) randomNumber = Random.Range(1, 4);

		if (!isChanged)
		{
            if (randomNumber == 1)
            {
                disguise1.SetActive(true);
                disguise2.SetActive(false);
                disguise3.SetActive(false);
                canChange = false;
                isChanged = true;
            }
            else if (randomNumber == 2)
            {
                disguise1.SetActive(false);
                disguise2.SetActive(true);
                disguise3.SetActive(false);
                canChange = false;
                isChanged = true;
            }
            else if (randomNumber == 3)
            {
                disguise1.SetActive(false);
                disguise2.SetActive(false);
                disguise3.SetActive(true);
                canChange = false;
                isChanged = true;
            }
        }
	}
}
