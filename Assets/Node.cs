using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor = Color.grey;
    private Color initialColor;

    private Renderer rend;

    public GameObject turretModel;
    private GameObject turret;

    void Start()
    {
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = initialColor;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Tady už tureta je.");
        }
        else
        {
            turret = Instantiate(turretModel, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        }
    }
}
