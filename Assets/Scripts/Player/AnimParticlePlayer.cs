using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimParticlePlayer : MonoBehaviour
{
    public ParticleSystem particlesystemLeftLand;
    public ParticleSystem particlesystemRightLand;
    public ParticleSystem particlesystemDownJumpLand;

    public void ParticleLeftLand()
    {
        if (particlesystemLeftLand != null)
        particlesystemLeftLand.Play();

    }

    public void ParticleRightLand()
    {
        if (particlesystemRightLand != null)
            particlesystemRightLand.Play();
    }
    public void ParticleDownJumpLand()
    {
        if (particlesystemDownJumpLand != null)
            particlesystemDownJumpLand.Play();
    }
}
