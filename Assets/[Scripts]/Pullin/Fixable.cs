using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fixable : MonoBehaviour
{

    public LayerMask m_FixLayers;

    bool canFix = false;

    public Color m_Color = Color.white;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("fix: " + canFix);

        var worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if (Input.GetMouseButtonDown(0) && canFix)
        {
            // Fetch the first collider.
            // NOTE: We could do this for multiple colliders.
            var collider = Physics2D.OverlapPoint(worldPos, m_FixLayers);
            if (!collider)
                return;

            // Fetch the collider body.
            var body = collider.gameObject;
            if (!body)
                return;

            body.GetComponent<SpriteRenderer>().color = m_Color;
        }
    }

    public void SetCanFix(bool selected)
    {
        canFix = selected;
    }
}
