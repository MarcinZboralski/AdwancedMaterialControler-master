using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AdwancedMaterialControler
{
    [RequireComponent(typeof(Renderer))]
    public class RenderAMC : MonoBehaviour
    {
        [NonSerialized]
        public CoreAMC coreAmc;

        [NonSerialized]
        public int nameBaseCount;

        [NonSerialized]
        private new Renderer renderer;


        [NonSerialized]
        public string nameBase;

        [NonSerialized]
        public int value;

        [NonSerialized]
        public bool useCustomShader;

        [NonSerialized]
        public bool useCustomTexture;

        [NonSerialized]
        public Shader CustomShader;

        [NonSerialized]
        public Texture CustomTexture;

        [NonSerialized]
        public int SilderNameBase;

        void Awake()
        {
            UpdateComponets();
        }

        void OnEnable()
        {
            DontDestroyOnLoad(this);
        }

        public void UpdateComponets()
        {
            coreAmc = CoreAMC.istance;
            renderer = GetComponent<Renderer>();
            nameBaseCount = coreAmc.GetNameDataCount(nameBase);
            UpdateRender(0);
        }

        public void UpdateRender(int value)
        {
            nameBaseCount = coreAmc.GetNameDataCount(nameBase);
            nameBase = coreAmc.amcData[SilderNameBase].DataName;

            if (useCustomTexture == false)
            {
                renderer.material.mainTexture = coreAmc.GetTexture(nameBase, value);
            }
            else
            {
                if (CustomTexture == null)
                {
                    renderer.material.mainTexture = coreAmc.GetTexture(nameBase, value);
                    useCustomTexture = false;
                }
                else
                {
                    renderer.material.mainTexture = CustomTexture;
                }
            }

            if (useCustomShader == false)
            {
                renderer.material.shader = coreAmc.GetShader(nameBase);
            }
            else
            {
                if (CustomShader == null)
                {
                    renderer.material.shader = coreAmc.GetShader(nameBase);
                    useCustomShader = false;
                }
                else
                {
                    renderer.material.shader = CustomShader;
                }
            }
           
        }

        public void RemoveThisComponent()
        {
            DestroyImmediate(this);
        }
    }
}

