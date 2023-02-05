using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixerTool : MonoBehaviour
{
    bool selected = false;
    bool hover = false;

    Camera cam;

    public Vector3 selectedPos;
    public Vector3 unselectedPos;
    public Vector3 hoverPos;

    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<Camera>();
    }

    private void Update()
    {
        Debug.Log("fixer " + selected);
        if (selected)
        {
            transform.position = selectedPos;
        }
        else if (hover)
        {
            transform.position = hoverPos;
        }
        if (!selected && !hover)
        {
            transform.position = unselectedPos;
        }
    }

    private void OnMouseDown()
    {
        selected = true;
        cam.GetComponent<Draggable>().SetCanPull(false);
        cam.GetComponent<Fixable>().SetCanFix(true);
        FindObjectOfType<Tool>().SetPullerSelect(false);
    }

    public void SetFixerSelect(bool selection)
    {
        selected = selection;
    }

    private void OnMouseOver()
    {
        hover = true;
    }

    private void OnMouseExit()
    {
        hover = false;
    }
}
