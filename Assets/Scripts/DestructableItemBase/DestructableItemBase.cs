using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DestructableItemBase : MonoBehaviour, IDamageable
{
    public HealthBase healthBase;
    public List<MeshRenderer> meshRenderers;
    public ParticleSystem particleDamage = null;
    public int dropCoin = 10;
    public int EnddropCoin = 5;
    private int savedCoins = 1;
    public GameObject coinPrefab;
    public Transform dropPosition;
    public GameObject graphicItem;

    private void OnValidate()
    {
        if (healthBase == null)
        {
            healthBase = GetComponent<HealthBase>();
        }
    }
    private void Awake()
    {
        TurnItOff();
        OnValidate();
        savedCoins = dropCoin;
        //healthBase.onDamage += ;
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

    public void Damage(float damage)
    {
    }

    public void Damage(float damage, Transform pos)
    {
    }

    public void Damage(float damage, Transform pos, bool recoil, bool constant)
    {
        if(0 <= savedCoins)
        {
            savedCoins--;
            spawndropCoin();
        }
        else
        {
            dropGroupCoin();
        }
            
        TurnItOn();
        if (particleDamage != null)
        {
            particleDamage.transform.position = pos.position;

            Vector3 pontaPos = (transform.position);
            Vector3 centroPos = (pos.transform.position); 

            // Calcular a direção da ponta em relação ao centro
            Vector3 direcao = pontaPos - centroPos;

            // Inverter a direção
            Vector3 direcaoOposta = -direcao;

            particleDamage.transform.LookAt(centroPos + direcaoOposta);
            particleDamage.transform.rotation = Quaternion.Euler(0, particleDamage.transform.rotation.eulerAngles.y, 0);
            particleDamage.Play();
        }
        Invoke(nameof(TurnItOff), 0.5f);
    }

    private void spawndropCoin()
    {
        var i = Instantiate(coinPrefab);
        
        i.transform.position = dropPosition.position;
        i.transform.DOScale(0, 1f).SetEase(Ease.OutBack).From();
        foreach (var child in i.GetComponentsInChildren<CoinChestScript>())
        {
            child.DropAddForce();
        }
    }

    private void dropGroupCoin()
    {
        for(int i = 0; i < EnddropCoin; i++)
        {
            savedCoins--;
            spawndropCoin();
        }
        StartCoroutine(HideObject());
    }

    IEnumerator HideObject()
    {

        if (graphicItem != null)
        {
            graphicItem.SetActive(false);
        }
        yield return new WaitForSeconds(3f);
        Destroy(gameObject);
    }


}
