using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ebac.core.Singleton;

namespace Cloth
{
    public enum ClothType
    {
        NULL,
        SPEED,
        STRONG,
        GOLD,
        NEWCOLOR
    }

    public class ClothManager : Singleton<ClothManager>
    {
        public List<ClothSetup> clothSetup;

        public ClothSetup GetSetupByType(ClothType clothTipe)
        {
            return clothSetup.Find(i => i.clothType == clothTipe);
        }

    }

    [System.Serializable]
    public class ClothSetup
    {
        public ClothType clothType;
        public Texture2D texture;
        public GameObject Visual;
    }
}
