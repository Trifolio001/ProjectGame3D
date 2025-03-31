using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStartCheck : MonoBehaviour
{
    public string tagToCheck = "Player";

    public GameObject bossCamera;
    //public GameObject OutherCamera;

    private void Awake()
    {
        bossCamera.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == tagToCheck)
        {
            bossCamera.SetActive(true);
            //OutherCamera.SetActive(false);
        }

    }


    private void OnTriggerExit(Collider other)
    {
        if (other.transform.tag == tagToCheck)
        {

            //OutherCamera.SetActive(true);
            bossCamera.SetActive(false);
        }

    }


    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }*/
}
