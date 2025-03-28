using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ColorChange : MonoBehaviour
{
    //public float duration = .5f;

   // public List<SkinnedMeshRenderer> spriteRenderers;
    

    public Material meshRender;

    public Color _startColor = Color.red;

    private Color _correctColor;

    private void Start()
    {
        _correctColor = Color.white;
        meshRender = GetComponent<SkinnedMeshRenderer>().material;
    }

    public void InitiateAnimate(float duration)
    {
        meshRender.DOColor(_startColor, duration).SetLoops(2, LoopType.Yoyo);
    }

    /*private void LerpColor(float duration)
    {
    }*/

    /*IEnumerator OperationDelay(Material spriteSelect, float timesequence)
    {
        
                meshRender.DOColor(_startColor, duration).SetDelay(timesequence);
                yield return new WaitForSeconds(timesequence);
                meshRender.DOColor(Color.white, duration).SetDelay(timesequence);
                yield return new WaitForSeconds(timesequence / i);
    }*/

}
