using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMenuPicker : MonoBehaviour
{
    [Tooltip("Main Camera in the scene")]
    public Camera mainCamera;
    [Tooltip("How long to focus on a menu element before it's picked")]
    public float focusTime = 1.5f;

    private RaycastHit raycastHit;
    private GameObject focusedMenuItem = null;
    private float elapsedFocusTime = 0.0f;

    // Update is called once per frame
    void Update()
    {
        if (mainCamera != null)
        {
            Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));
            // We hit something
            if (Physics.Raycast(ray, out raycastHit))
            {
                // Is it a menu object?
                if (raycastHit.collider.gameObject.tag.Equals("MenuObject"))
                {
                    // do we currently have a some sort of menu item we are looking at?
                    if (focusedMenuItem != null)
                    {
                        // add to elapsed time if we do
                        if (elapsedFocusTime < focusTime)
                        {
                            elapsedFocusTime += Time.deltaTime;
                        }
                        else
                        {
                            // Call menu function if time has passed
                            elapsedFocusTime = 0.0f;
                            focusedMenuItem.GetComponent<MenuTrigger>().Run();
                        }
                    }
                    else
                    {
                        // We just found something we wanna focus on
                        focusedMenuItem = raycastHit.collider.gameObject;
                    }
                }
                else
                {
                    // We have not found anything to focus on.
                    focusedMenuItem = null;
                    elapsedFocusTime = 0.0f;
                }
            }
        }
        else
        {
            Debug.LogError("No camera in RaycastMenuPicker");
        }
    }
}
