using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ChestItemCoin : ChestItemBase
{
    public ChestBase chestBase;
    public int coinNumber = 5;
    public GameObject coinObject;

    private List<GameObject> _itens = new List<GameObject>();

    public Vector2 randomRangex = new Vector2(-2f, 2f);
    public Vector2 randomRangey = new Vector2(-2f, 2f);


    public float deleyTime = .5f;
    public float tweenTime = .5f;
    private bool collected = false;


    public void Start()
    {

        collect();
    }

    public override void ShowItem()
    {
        base.ShowItem();
        CreateItens();
    }


    [NaughtyAttributes.Button]
    private void CreateItens()
    {
        for (int i = 0; i < coinNumber; i++)
        {
            var item = Instantiate(coinObject);
            item.transform.position = transform.position + Vector3.forward * Random.Range(randomRangex.x, randomRangex.y) + Vector3.right * Random.Range(randomRangey.x, randomRangey.y);
            _itens.Add(item);
        }
        collect();
    }


    [NaughtyAttributes.Button]
    public override void collect()
    {
        base.collect();
        float time = 0;

        foreach(var i in _itens)
        {
            i.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
            i.transform.DOMoveY(7f, tweenTime).SetRelative().SetDelay(deleyTime);
            i.transform.DOScale(transform.localScale, tweenTime + .5f).SetDelay(deleyTime); 
            time += .3f;
            StartCoroutine(OperaçãodeTempo(i, time));
        }

    }

    IEnumerator OperaçãodeTempo(GameObject i, float time)
    {
        yield return new WaitForSeconds(tweenTime + time + deleyTime);
        foreach (var child in i.GetComponentsInChildren<CoinChestScript>())
        {
            child.PlayerChase(chestBase.player);
        }

    }


}
