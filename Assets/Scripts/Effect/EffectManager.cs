using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using Ebac.core.Singleton;
using Cinemachine;

public class EffectManager : Singleton<EffectManager>
{
    public PostProcessVolume processVolume;
    public Vignette _vignette;
    public ColorGrading _colorGrading;

    public float durationVignette = 0.2f;
    public float durationGrading = 3f;
    private float valuePostExpessure = 1;


    [Header("Shake Value")]
    public List<CinemachineVirtualCamera> virtualCamera;
    public float shakeTime;
    public float amplitude = 3f;
    public float frequence = 3f;
    public float time = .2f;
    private bool camShakeActive= false;


    [NaughtyAttributes.Button]

    public void ChangeVegnette()
    {
        StartCoroutine(FlashColorVignette());
    }


    IEnumerator FlashColorVignette()
    {
        Vignette tmp;

        if(processVolume.profile.TryGetSettings<Vignette>(out tmp))
        {
            _vignette = tmp;
        }

        ColorParameter c = new ColorParameter();

        float time = 0;
        while(time < durationVignette)
        {
            c.value = Color.Lerp(Color.white, Color.red, time / durationVignette);
            time += Time.deltaTime;
            _vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }
        time = 0;
        while (time < durationVignette)
        {
            c.value = Color.Lerp( Color.red, Color.white, time / durationVignette);
            time += Time.deltaTime;
            _vignette.color.Override(c);
            yield return new WaitForEndOfFrame();
        }

    }

    public void ChangeColorGradingIn()
    {
        StartCoroutine(FlashColorGradingIn());
    }


    IEnumerator FlashColorGradingIn()
    {
        {
            ColorGrading tmp;

            if (processVolume.profile.TryGetSettings<ColorGrading>(out tmp))
            {
                _colorGrading = tmp;
            }

            ColorParameter c = new ColorParameter();

            valuePostExpessure = _colorGrading.postExposure.value;
            float time = 0;
            while (time < durationGrading)
            {
                c.value = Color.Lerp(Color.white, Color.black, time / durationGrading);
                time += Time.deltaTime;
                _colorGrading.colorFilter.Override(c);
                yield return new WaitForEndOfFrame();
            }
            _colorGrading.postExposure.value = -50;
        }
    }

    public void ChangeColorGradingOut()
    {
        StartCoroutine(FlashColorGradingOut());
    }
    IEnumerator FlashColorGradingOut()
    {
        ColorGrading tmp;

        if (processVolume.profile.TryGetSettings<ColorGrading>(out tmp))
        {
            _colorGrading = tmp;
        }

        ColorParameter c = new ColorParameter();

        _colorGrading.postExposure.value = valuePostExpessure;

        float time = 0;
        while (time < durationGrading)
        {
            c.value = Color.Lerp(Color.black, Color.white, time / (durationGrading/2));
            time += Time.deltaTime;
            _colorGrading.colorFilter.Override(c);
            yield return new WaitForEndOfFrame();
        }
    }

    [NaughtyAttributes.Button]
    public void Shake()
    {
        Shake(amplitude, frequence, time);
    }

    public void Shake(float amplitude, float frequenci, float time)
    {
        for(int i = 0; i < virtualCamera.Count; i++)
        {
                virtualCamera[i].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = amplitude;
                virtualCamera[i].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = frequenci;
            
        }

        camShakeActive = false;

        shakeTime = time;
    }

    private void Update()
    {
        if (!camShakeActive)
        {
            if (shakeTime > 0)
            {
                shakeTime -= Time.deltaTime;
            }
            else
            {
                for (int i = 0; i < virtualCamera.Count; i++)
                {
                        virtualCamera[i].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = 0f;
                        virtualCamera[i].GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_FrequencyGain = 0f;

                }
                camShakeActive =true;
            }
        }
    }
}
