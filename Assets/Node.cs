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

    private Economy economy;
    private Alert alert;

    void Start()
    {
        rend = GetComponent<Renderer>();
        initialColor = rend.material.color;
        GameObject gameMaster = GameObject.Find("GameMaster");
        economy = gameMaster.GetComponent<Economy>();
        alert = gameMaster.GetComponent<Alert>();
    }
    #region
    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = initialColor;
    }
    #endregion
    private void OnMouseDown()
    {
        if (turret != null)
        {
            alert.setText("Tady už tureta je.");
        }
        else if (economy.CanBuild())
        {
            turret = Instantiate(turretModel, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        }
        else
        {
            alert.setText("Nemáš dostatek peněz");
        }
    }
}
