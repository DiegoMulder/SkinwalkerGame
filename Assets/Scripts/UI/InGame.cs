using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    private Ray ray;
    [SerializeField] private Image mainGameCursor;
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
            if (hitInfo.collider.gameObject.tag == "skinwalker") mainGameCursor.color = Color.red;
            else if (hitInfo.collider.gameObject.tag == "skinwalker2") mainGameCursor.color = Color.red;
            else mainGameCursor.color = Color.white;
        }
    }
}
