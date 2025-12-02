using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*
 
 编辑器扩展
 
 */
#if UNITY_EDITOR
[CustomEditor(typeof(MotionSourceManager))]
public class EditorMotionSourceManagerInspect : Editor
{
	private SerializedObject obj;
	private MotionSourceManager motionSourceManager;
	private SerializedProperty iterator;
	private List<string> propertyNames;
	private SocketType socketType;
	private Dictionary<string, SocketType> specialPropertys
		= new Dictionary<string, SocketType>
		{
			{"client_ip", SocketType.UDP},
			{"client_port", SocketType.UDP},
		};

	void OnEnable()
	{
		obj = new SerializedObject(target);
		iterator = obj.GetIterator();
		iterator.NextVisible(true);
		propertyNames = new List<string>();
		do
		{
			propertyNames.Add(iterator.name);
		} while (iterator.NextVisible(false));
		motionSourceManager = (MotionSourceManager)target;
	}

	public override void OnInspectorGUI()
	{
		obj.Update();
		GUI.enabled = false;
		foreach (var name in propertyNames)
		{
			if (specialPropertys.TryGetValue(name, out socketType)
				&& socketType != motionSourceManager.socketType)
				continue;
			EditorGUILayout.PropertyField(obj.FindProperty(name));
			if (!GUI.enabled)//让第1次遍历到的 Script 属性为只读
				GUI.enabled = true;
		}
		obj.ApplyModifiedProperties();
	}
}
#endif

