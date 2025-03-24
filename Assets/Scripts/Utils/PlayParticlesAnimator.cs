using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticlesAnimator : MonoBehaviour
{
    public ParticleSystem particleIRA;
    public ParticleSystem particleKill;

    public void PlayIraParticlesPlay()
    {
        //if (_index >= particleIRA.Count) _index = 0;
        particleIRA.Play();
        //_index++;
    }


    public void PlayKillParticlesPlay()
    {
        particleKill.Play();
    }
}
