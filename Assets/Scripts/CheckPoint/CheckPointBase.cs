using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointBase : MonoBehaviour
{
    public List<MeshRenderer> meshRenderers;
    public int key = 1;

    private bool checkpointActived = false;
    public Animator animator;
    private string checkpointKey = "CheckpointKey";

    public void Start()
    {
        TurnItOff();
    }

    private void OnTriggerEnter(Collider other)
    {
        if((!checkpointActived) && (other.transform.tag == "Player"))
        {
            animator.SetTrigger("Ativate");
            CheckCheckPoint();
        }
    }

    private void CheckCheckPoint()
    {
        saveCheckPoint();
        TurnItOn();
    }

    [NaughtyAttributes.Button]
    private void TurnItOff()
    {
        for(int i = 0; i < meshRenderers.Count; i++)         
        {
            meshRenderers[i].material.SetColor("_EmissionColor", Color.black);
        }
    }

    [NaughtyAttributes.Button]
    private void TurnItOn()
    {
        for (int i = 0; i < meshRenderers.Count; i++)
        {
            meshRenderers[i].material.SetColor("_EmissionColor", Color.green);
        }
    }

    private void saveCheckPoint()
    {
        /*if (PlayerPrefs.GetInt(checkpointKey, 0) > key)
        {
            PlayerPrefs.SetInt(checkpointKey, key);
        }*/
        CheckPointManager.Instance.saveCheckpoint(key);

        checkpointActived = true;
    }

    public void RevavelPlayer()
    {
        animator.SetTrigger("Revavel");
    }
}
