using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Diagnostics;

public class MaterialCombine {


    [MenuItem("Assets/Combine same materials")]
    static public void CombineMaterial()
    {
        Renderer[] renderers = Selection.activeGameObject.GetComponentsInChildren<Renderer>();
        Dictionary<Color, Material> mats = new Dictionary<Color, Material>();
        foreach( Renderer renderer in renderers )
        {
            if (renderer == null) continue;
            Material mat = renderer.sharedMaterial;
            if (mat.mainTexture != null) continue;
            Color col  = mat.color;
            if ( mats.ContainsKey(col))
            {
                renderer.sharedMaterial = mats[col];
            }
            else
            {
                mats[col] = mat;
            }
        }
    }
}
