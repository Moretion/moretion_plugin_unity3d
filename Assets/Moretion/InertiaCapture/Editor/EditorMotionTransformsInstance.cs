using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MotionTransformsInstance))]
public class EditorMotionTransformsInstance : Editor
{

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        MotionTransformsInstance  motionTransformsInstance = (MotionTransformsInstance)target;
        if (GUILayout.Button("bind"))
        {
            //一键绑定骨骼，需要自行确认下骨骼有没有错
            motionTransformsInstance.BindBone();
        }
    }
}
