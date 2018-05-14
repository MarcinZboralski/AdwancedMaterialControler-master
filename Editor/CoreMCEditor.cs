using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace AdwancedMaterialControler
{
    [CustomEditor(typeof(CoreAMC))]
    public class CoreMCEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            CoreAMC r = (CoreAMC)target;

            DrawDefaultInspector();
            CoreAMC.istance = r;
            if (GUILayout.Button("Update All Renderers"))
            {
                r.FindRenderers();
                r.UpdateRenderersComponent();
            }
        }
    }
}

