/******************************************************************************
 动捕数据驱动模型基类
  
*******************************************************************************/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotionInstance : MonoBehaviour
{
	public int actorID;
	public bool isUseHand = true;

	[Header("模型位置调整")]
	public Vector3 positionOffset;

	public Dictionary<Transform, Quaternion> unityT = new Dictionary<Transform, Quaternion>();//key:骨骼  value:初始姿态

	public virtual void Start()
	{

	}

	// Update is called once per frame
	public virtual void Update()
	{

	}

	/// <summary>
	/// 初始化模型
	/// </summary>
	protected virtual void InitModel()
	{

	}


	/// <summary>
	/// 初始化骨骼相关信息
	/// </summary>
	/// <param name="bone"></param>
	protected virtual void InitBone(Transform bone)
	{
		if (bone != null)
		{
			//记录骨骼初始姿态
			if (!unityT.ContainsKey(bone))
			{
				unityT.Add(bone, bone.rotation);
			}
		}
	}

	/// <summary>
	/// 应用动捕数据
	/// </summary>
	/// <param name="motionData"></param>
	public virtual void ApplyMotion(MotionData motionData)
	{

	}

	/// <summary>
	/// 设置骨骼姿态
	/// </summary>
	/// <param name="boneTF"></param>
	/// <param name="targetData"></param>
	/// <param name="rotateOrder"></param>
	protected virtual void SetRotation(Transform boneTF, Quaternion globalQua)
	{
		try
		{
			if (boneTF != null)
			{
				Quaternion unityTQua;
				if (unityT.TryGetValue(boneTF, out unityTQua))
				{
					boneTF.rotation = globalQua * unityTQua;
				}
			}
		}
		catch (Exception e)
		{
			Debug.LogWarning("设置骨骼姿态错误:" + e.Message);
		}
	}

	/// <summary>
	/// 设置模型位置
	/// </summary>
	/// <param name="rootTF"></param>
	/// <param name="position"></param>
	protected virtual void SetPosition(Transform rootTF, Vector3 position)
	{
		if (rootTF != null)
		{
			rootTF.position = position;
		}
	}

	/// <summary>
	/// 获取手套数据
	/// </summary>
	/// <returns></returns>
	public virtual float[]GetGloveData()
	{
		return null;
	}

	/// <summary>
	/// 角度转换[-180, 180]
	/// </summary>
	/// <param name="angle"></param>
	/// <returns></returns>
	private float WrapAngle(float angle)
	{
		while (angle <= -180f) angle += 360f;
		while (angle > 180f) angle -= 360f;
		return angle;
	}
}
