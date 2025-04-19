using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlashColor : MonoBehaviour
{
    public List<MeshRenderer> meshRenderers; 
    public Color color = Color.red;
    public float duration = .02f;

    private Tween _curretTween;
    private bool Referencetime = false;
    private int timeMili = 0;

    public List<Color> colorRenderers;
    private List<ColorChange> colorChange;

    private void Start()
    {
        Invoke(nameof(OnValidate), 1f);
    }

    

    private void OnValidate()
    {
        Referencetime = true;
        colorRenderers = new List<Color>();
        meshRenderers = new List<MeshRenderer>();
        foreach(var child in transform.GetComponentsInChildren<MeshRenderer>())
        {
            meshRenderers.Add(child);
            colorRenderers.Add(child.sharedMaterial.color);
        }
        colorChange = new List<ColorChange>();
        foreach (var child in gameObject.GetComponentsInChildren<ColorChange>())
        {
            colorChange.Add(child);
        }
    }



    public void Flash()
    {
        /*Debug.Log(_curretTween);
        if (_curretTween != null)
        {
            Debug.Log("passo");
            spriteRenderers.ForEach(i => i.color = Color.white);
            _curretTween.Kill();
        }*/

        //Debug.Log(timeMili + " = e = " + Referencetime);

        if(Referencetime)
        {
            foreach (var s in meshRenderers)
            {
                s.material.DOColor(color, (duration/2)).SetLoops(2, LoopType.Yoyo);
            }
            timeMili = 10;
            Referencetime = false;
            for (int i = 0; i < colorChange.Count; i++)
            {
                colorChange[i].InitiateAnimate((duration / 2));
            }
            Invoke(nameof(OperaçãodeTempo), duration + 0.1f);
        }
        
    }

    public void OperaçãodeTempo()
    {       
        Referencetime = true;
    }


    public void SetTransparency(float alpha)
    {
        /*meshRenderers.ForEach(i =>
        {
            Color color = i.color; 
            color.a = alpha; 
            i.color = color; 
        });*/
    }
}
