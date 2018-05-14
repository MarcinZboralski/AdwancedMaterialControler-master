using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace AdwancedMaterialControler
{
    public class CoreAMC : MonoBehaviour
    {
        public static CoreAMC istance;

        public List<DataAMC> amcData;

        [NonSerialized]
        public List<Renderer> Renderers;

        public List<Renderer> IgnoreRenderersList; 

        void OnEnable()
        {
            DontDestroyOnLoad(this);
        }

        public Texture GetTexture(string type, int count)
        {
            Texture targetTexture = null;
            foreach (var array in amcData)
            {
                if (array.DataName == type)
                {
                    targetTexture = array.Textures[count];
                    break;   
                }
            }

            return targetTexture;
        }

        public int GetNameDataCount(string type)
        {
            int count = 0;
            for (int i = 0; i < amcData.Count; i++)
            {
                if (amcData[i].DataName == type)
                {
                    count = i;
                    break;
                }
            }

            return count;
        }

        public Shader GetShader(string type)
        {
            Shader shader = null;

            foreach (var array in amcData)
            {
                if (array.DataName == type)
                {
                    shader = array.Shader;
                    break;
                }
            }

            return shader;
        }

        public void FindRenderers()
        {
            Renderers = FindObjectsOfType<Renderer>().ToList();
        }

        public void UpdateRenderersComponent()
        {
            foreach (var r in Renderers)
            {
                if (r.GetComponent(typeof(RenderAMC)) == null)
                {
                    foreach (var rr in IgnoreRenderersList)
                    {
                        if (rr != r)
                        {
                            r.gameObject.AddComponent(typeof(RenderAMC));
                           RenderAMC rrr = (RenderAMC)r.gameObject.GetComponent(typeof(RenderAMC));
                            rrr.UpdateComponets();
                        }
                    }
                }
            }
        }
    }
}

