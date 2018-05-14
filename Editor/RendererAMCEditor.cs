using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AdwancedMaterialControler
{
    [CustomEditor(typeof(RenderAMC))]
    public class RendererAMCEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            RenderAMC r = (RenderAMC) target;

            DrawDefaultInspector();


            r.SilderNameBase = EditorGUILayout.IntSlider(r.SilderNameBase,0,CoreAMC.istance.amcData.Count-1);
            GUILayout.Label("Name In Data Base Is: " + CoreAMC.istance.amcData[r.SilderNameBase].DataName);

            r.useCustomShader = GUILayout.Toggle(r.useCustomShader, "Use Custom Shader");

            if (r.useCustomShader)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Custom Shader Field: ");
                r.CustomShader = (Shader) EditorGUILayout.ObjectField(r.CustomShader,typeof(Shader),true);
                EditorGUILayout.EndHorizontal();
            }

           r.useCustomTexture = GUILayout.Toggle(r.useCustomTexture, "Use Custom Texture");

            if (r.useCustomTexture)
            {
                EditorGUILayout.BeginHorizontal();
                GUILayout.Label("Custom Texture Field: ");
                r.CustomTexture = (Texture)EditorGUILayout.ObjectField(r.CustomTexture, typeof(Texture), true);
                EditorGUILayout.EndHorizontal();
            }

            if (GUILayout.Button("Update Components"))
            {
                r.UpdateComponets();
            }

            EditorGUILayout.BeginHorizontal();

            if (GUILayout.Button("-"))
            {
                if (r.value > 0)
                {
                    r.value--;
                }
                r.UpdateRender(r.value);
            }

            
            if (GUILayout.Button("+"))
            {
                if (r.value < r.coreAmc.amcData[r.nameBaseCount].Textures.Length-1)
                {
                    r.value++;
                }
                r.UpdateRender(r.value);
            }

            EditorGUILayout.EndHorizontal();

            if (GUILayout.Button("Remove This Component"))
            {
                r.RemoveThisComponent();
            }

        }
    }
}

