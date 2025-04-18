using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cloth {
    public class ClothChanger : MonoBehaviour
    {
        public List<SkinnedMeshRenderer> mesh;
        public Texture2D texture;
        public string shaderIdName = "_EmissionMap";

        private Texture2D _defaultTexture;

        
        public void DefaultTextureSave()
        {
            foreach (SkinnedMeshRenderer M in mesh)
            {
                _defaultTexture = (Texture2D)M.sharedMaterials[0].GetTexture(shaderIdName);
            }
        }

        [NaughtyAttributes.Button]
        private void ChangeTexture()
        {
            foreach (SkinnedMeshRenderer M in mesh)
            {
                M.sharedMaterials[0].SetTexture(shaderIdName, texture);
            }
        }

        public void ChangeTexture(ClothSetup setup)
        {
            foreach (SkinnedMeshRenderer M in mesh)
            {
                M.sharedMaterials[0].SetTexture(shaderIdName, setup.texture);
            }
        }

        public void ResetTexture()
        {
            foreach (SkinnedMeshRenderer M in mesh)
            {
                M.sharedMaterials[0].SetTexture(shaderIdName, _defaultTexture);
            }
        }
    }
}
