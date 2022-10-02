using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    public GameObject launchPoint;

    private void Awake()
    {
        Transform launchPointTrans = transform.Find("Launch Point"); // a
        launchPoint = launchPointTrans.gameObject;
        launchPoint.SetActive(false); // b
    }
    private void OnMouseEnter()
    {
        //print("Slingshot:OnMouseEnter()");
        launchPoint.SetActive(true); //b
    }
    private void OnMouseExit()
    {
        //print("Slingshot:OnMouseExit()");
        launchPoint.SetActive(false);
    }
}
