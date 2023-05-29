using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TravelBorders : MonoBehaviour
{
    public int builderIndexNumber = 0;
	public void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			SceneManager.LoadScene(builderIndexNumber);
		}
	}
}
