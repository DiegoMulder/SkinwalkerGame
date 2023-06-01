using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    private Ray ray;
    [SerializeField] private Image mainGameCursor;
    [SerializeField] private Sprite normalSprite, interactionSprite;
    // Update is called once per frame
    void Update()
    {
        CursorColorLogic();
    }

    public void CursorColorLogic()
	{
        ray = Camera.main.ViewportPointToRay(new Vector3(.5f, .5f, 0));
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject.tag == "skinwalker")
			{
                mainGameCursor.color = Color.red;
                QuickSwap.canUsePistol = true;
            }
            else if (hitInfo.collider.gameObject.tag == "skinwalker2")
			{
                mainGameCursor.color = Color.red;
                QuickSwap.canUsePistol = true;
            }
			else
			{
                mainGameCursor.color = Color.white;
            }

            if(LeftDoor.distance <= 2.5f)
			{
                if (hitInfo.collider.gameObject.tag == "door") mainGameCursor.sprite = interactionSprite;
                else mainGameCursor.sprite = normalSprite;
            }

            if(RightDoor.distance <= 2.5f)
			{
                if (hitInfo.collider.gameObject.tag == "door2") mainGameCursor.sprite = interactionSprite;
                else mainGameCursor.sprite = normalSprite;
            }

            if (LeftDoor2.distance <= 2.5f)
            {
                if (hitInfo.collider.gameObject.tag == "door3") mainGameCursor.sprite = interactionSprite;
                else mainGameCursor.sprite = normalSprite;
            }

            if (RightDoor2.distance <= 2.5f)
            {
                if (hitInfo.collider.gameObject.tag == "door4") mainGameCursor.sprite = interactionSprite;
                else mainGameCursor.sprite = normalSprite;
            }
        }
    }
}
