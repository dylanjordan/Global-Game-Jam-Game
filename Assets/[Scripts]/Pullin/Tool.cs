using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tool : MonoBehaviour
{
    bool selected = false;

    Camera cam;

    public Vector3 selectedPos;
    public Vector3 unselectedPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        Debug.Log("Puller " + selected);
        if (selected)
        {
            transform.position = selectedPos;
        }
        if (!selected)
        {
            transform.position = unselectedPos;
        }
    }

    private void OnMouseDown()
    {
            selected = true;
            cam.GetComponent<Draggable>().SetCanPull(true);
            cam.GetComponent<Fixable>().SetCanFix(false);
            FindObjectOfType<FixerTool>().SetFixerSelect(false);
    }

    public void SetPullerSelect(bool selection)
    {
        selected = selection;
    }
}
