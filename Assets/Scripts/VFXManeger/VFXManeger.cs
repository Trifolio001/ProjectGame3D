using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

public class VFXManeger : Singleton<VFXManeger>
{
    public enum VFXType
    {
        BULLETENIMY,
        BULLETPLAYER,
        HEARTPLAYER
    }

    public List<VFXManegerSetup> vfxSetup;
    
    public void PlayVFXByTipe(VFXType vfxType, Vector3 position, Quaternion rotation)
    {
        foreach(var i in vfxSetup)
        {
            if(i.vfxType == vfxType)
            {
                var item = Instantiate(i.prefab);
                item.transform.position = position;
                item.transform.localRotation = rotation;
                Destroy(item.gameObject, 3f);
                break;
            }
        }
    }

    [System.Serializable]
    public class VFXManegerSetup
    {
        public VFXManeger.VFXType vfxType;
        public GameObject prefab;
    }

}
