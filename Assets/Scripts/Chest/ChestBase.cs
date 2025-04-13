using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestBase : MonoBehaviour
{
    public KeyCode keyCode = KeyCode.E;
    public Animator animator;
    public string triggerOpen = "Open"; 
    public List<MeshRenderer> meshRenderers;
    public PlayerControl player;

    [Header("Notification")]
    public GameObject notification;
    public float TweenDuration = .2f;
    public Ease tweenEase = Ease.OutBack;
    private float startscale; 
    private Camera mainCamera;

    [Space]
    public ChestItemBase chestItem;

    private bool _chestOpen = false;

    private void Start()
    {
        mainCamera = Camera.main;
        startscale = notification.transform.localScale.x;
        HideNotification();
        TurnItOff();
    }

    [NaughtyAttributes.Button]
    private void OpenChest()
    {
        if (_chestOpen)
        {
            return;
        }
        animator.SetTrigger(triggerOpen);
        TurnItOn();
        _chestOpen = true;
        chestItem.ShowItem();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (_chestOpen)
        {
            return;
        }
        PlayerControl p = other.transform.GetComponent<PlayerControl>();
        if((p != null))
        {
            player = p;
            notification.transform.LookAt(mainCamera.transform);
            ShowNotification();
        }
    }

    public void OnTriggerExit(Collider other)
    {
        PlayerControl p = other.transform.GetComponent<PlayerControl>();
        if (p != null)
        {
            HideNotification();
        }
    }

    private void ShowNotification()
    {
        TurnItnear();
        notification.SetActive(true);
        notification.transform.localScale = Vector3.zero;
        notification.transform.DOScale(startscale, TweenDuration);
    }


    private void HideNotification()
    {
        if (!_chestOpen)
        {
            TurnItOff();
        }
        notification.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(keyCode) && notification.activeSelf)
        {
            OpenChest(); 
            HideNotification();
        }
    }

    private void TurnItOff()
    {
        for (int i = 0; i < meshRenderers.Count; i++)
        {
            meshRenderers[i].material.SetColor("_EmissionColor", Color.black);
        }
    }

    private void TurnItOn()
    {
        for (int i = 0; i < meshRenderers.Count; i++)
        {
            meshRenderers[i].material.SetColor("_EmissionColor", Color.red);
        }
    }

    private void TurnItnear()
    {
        for (int i = 0; i < meshRenderers.Count; i++)
        {
            meshRenderers[i].material.SetColor("_EmissionColor", Color.green);
        }
    }
}
