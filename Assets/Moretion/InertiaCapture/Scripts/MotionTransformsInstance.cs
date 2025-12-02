/******************************************************************************
 Transforms方式驱动模型
  
*******************************************************************************/


using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class MotionTransformsInstance : MotionInstance
{
	private Animator animator;

	#region 骨骼
	[SpaceAttribute(10)]
	[Header("上半身")]
	public Transform crotch;                       //臀
	public Transform waistOne;                     //臀上方第一节脊柱
	public Transform waistTwo;                     //臀上方第二节脊柱
	public Transform back;                         //背
	public Transform head;                         //头
	public Transform leftShoulder;                 //左肩
	public Transform leftUpperArm;                 //左大臂
	public Transform leftLowerArm;                 //左小臂
	public Transform leftHand;                     //左手
	public Transform rightShoulder;                //右肩
	public Transform rightUpperArm;                //右大臂
	public Transform rightLowerArm;                //右小臂
	public Transform rightHand;                    //右手

	[Header("下半身")]
	public Transform leftUpperLeg;                 //左大腿
	public Transform leftLowerLeg;                 //左小腿
	public Transform leftFoot;                     //左脚
	public Transform leftToe;                      //左脚尖
	public Transform rightUpperLeg;                //右大腿
	public Transform rightLowerLeg;                //右小腿
	public Transform rightFoot;                    //右脚
	public Transform rightToe;                     //右脚尖

	[Header("左手指")]
	public Transform leftHandThumb1;               //左手大拇指根部
	public Transform leftHandThumb2;               //左手大拇指中部
	public Transform leftHandThumb3;               //左手大拇指上部
	public Transform leftHandIndexFinger1;         //左手食指根部
	public Transform leftHandIndexFinger2;         //左手食指中部
	public Transform leftHandIndexFinger3;         //左手食指上部
	public Transform leftHandMiddleFinger1;        //左手中指根部
	public Transform leftHandMiddleFinger2;        //左手中指中部
	public Transform leftHandMiddleFinger3;        //左手中指上部
	public Transform leftHandRingFinger1;          //左手无名指根部
	public Transform leftHandRingFinger2;          //左手无名指中部
	public Transform leftHandRingFinger3;          //左手无名指上部
	public Transform leftHandLittleFinger1;        //左手小拇指根部
	public Transform leftHandLittleFinger2;        //左手小拇指中部
	public Transform leftHandLittleFinger3;        //左手小拇指上部

	[Header("右手指")]
	public Transform rightHandThumb1;              //右手大拇指根部
	public Transform rightHandThumb2;              //右手大拇指中部
	public Transform rightHandThumb3;              //右手大拇指上部
	public Transform rightHandIndexFinger1;        //右手食指根部
	public Transform rightHandIndexFinger2;        //右手食指中部
	public Transform rightHandIndexFinger3;        //右手食指上部
	public Transform rightHandMiddleFinger1;       //右手中指根部
	public Transform rightHandMiddleFinger2;       //右手中指中部
	public Transform rightHandMiddleFinger3;       //右手中指上部
	public Transform rightHandRingFinger1;         //右手无名指根部
	public Transform rightHandRingFinger2;         //右手无名指中部
	public Transform rightHandRingFinger3;         //右手无名指上部
	public Transform rightHandLittleFinger1;       //右手小拇指根部
	public Transform rightHandLittleFinger2;       //右手小拇指中部
	public Transform rightHandLittleFinger3;       //右手小拇指上部

	#endregion



	private void Awake()
	{

	}

	// Start is called before the first frame update
	public override void Start()
	{
		animator = GetComponent<Animator>();
		InitModel();
		base.Start();
	}

	// Update is called once per frame
	public override void Update()
	{

	}

	/// <summary>
	/// 初始化模型
	/// </summary>
	protected override void InitModel()
	{
		InitBone(crotch);

		InitBone(waistOne);
		InitBone(waistTwo);
		InitBone(back);
		InitBone(head);

		InitBone(leftShoulder);
		InitBone(leftUpperArm);
		InitBone(leftLowerArm);
		InitBone(leftHand);

		InitBone(rightShoulder);
		InitBone(rightUpperArm);
		InitBone(rightLowerArm);
		InitBone(rightHand);

		InitBone(leftUpperLeg);
		InitBone(leftLowerLeg);
		InitBone(leftFoot);
		InitBone(leftToe);

		InitBone(rightUpperLeg);
		InitBone(rightLowerLeg);
		InitBone(rightFoot);
		InitBone(rightToe);

		InitBone(leftHandThumb1);
		InitBone(leftHandThumb2);
		InitBone(leftHandThumb3);
		InitBone(leftHandIndexFinger1);
		InitBone(leftHandIndexFinger2);
		InitBone(leftHandIndexFinger3);
		InitBone(leftHandMiddleFinger1);
		InitBone(leftHandMiddleFinger2);
		InitBone(leftHandMiddleFinger3);
		InitBone(leftHandRingFinger1);
		InitBone(leftHandRingFinger2);
		InitBone(leftHandRingFinger3);
		InitBone(leftHandLittleFinger1);
		InitBone(leftHandLittleFinger2);
		InitBone(leftHandLittleFinger3);

		InitBone(rightHandThumb1);
		InitBone(rightHandThumb2);
		InitBone(rightHandThumb3);
		InitBone(rightHandIndexFinger1);
		InitBone(rightHandIndexFinger2);
		InitBone(rightHandIndexFinger3);
		InitBone(rightHandMiddleFinger1);
		InitBone(rightHandMiddleFinger2);
		InitBone(rightHandMiddleFinger3);
		InitBone(rightHandRingFinger1);
		InitBone(rightHandRingFinger2);
		InitBone(rightHandRingFinger3);
		InitBone(rightHandLittleFinger1);
		InitBone(rightHandLittleFinger2);
		InitBone(rightHandLittleFinger3);
	}

	/// <summary>
	/// 数据驱动模型
	/// </summary>
	/// <param name="motionData"></param>
	public override void ApplyMotion(MotionData motionData)
	{
		try
		{
			//设置根节点位置
			Vector3 pos = new Vector3(motionData.coordinate[0] + positionOffset.x, motionData.coordinate[1] + positionOffset.y, motionData.coordinate[2] + positionOffset.z);
			SetPosition(crotch, pos);//更新位置

			SetRotation(crotch, motionData.crotchQ);

			SetRotation(waistOne, motionData.waistOneQ);
			SetRotation(waistTwo, motionData.waistTwoQ);
			SetRotation(back,motionData.backQ);
			SetRotation(head, motionData.headQ);

			SetRotation(leftShoulder,motionData.leftShoulderQ);
			SetRotation(leftUpperArm, motionData.leftUpperArmQ);
			SetRotation(leftLowerArm, motionData.leftLowerArmQ);
			SetRotation(leftHand,motionData.leftHandQ);

			SetRotation(rightShoulder, motionData.rightShoulderQ);
			SetRotation(rightUpperArm, motionData.rightUpperArmQ);
			SetRotation(rightLowerArm, motionData.rightLowerArmQ);
			SetRotation(rightHand, motionData.rightHandQ);

			SetRotation(leftUpperLeg, motionData.leftUpperLegQ);
			SetRotation(leftLowerLeg,  motionData.leftLowerLegQ);
			SetRotation(leftFoot, motionData.leftFootQ);
			SetRotation(leftToe, motionData.leftToeQ);

			SetRotation(rightUpperLeg,motionData.rightUpperLegQ);
			SetRotation(rightLowerLeg, motionData.rightLowerLegQ);
			SetRotation(rightFoot, motionData.rightFootQ);
			SetRotation(rightToe,motionData.rightToeQ);

			if (isUseHand)
			{
				//---------------左手------------------
				SetRotation(leftHandThumb1,motionData.leftThumbUnderQ);
				SetRotation(leftHandThumb2, motionData.leftThumbMidQ);
				SetRotation(leftHandThumb3,  motionData.leftThumbUpQ);
				SetRotation(leftHandIndexFinger1, motionData.leftForeFingerUnderQ);
				SetRotation(leftHandIndexFinger2,motionData.leftForeFingerMidQ);
				SetRotation(leftHandIndexFinger3,motionData.leftForeFingerUpQ);
				SetRotation(leftHandMiddleFinger1,motionData.leftMiddleFingerUnderQ);
				SetRotation(leftHandMiddleFinger2, motionData.leftMiddleFingerMidQ);
				SetRotation(leftHandMiddleFinger3,motionData.leftMiddleFingerUpQ);
				SetRotation(leftHandRingFinger1,  motionData.leftRingFingerUnderQ);
				SetRotation(leftHandRingFinger2,  motionData.leftRingFingerMidQ);
				SetRotation(leftHandRingFinger3,  motionData.leftRingFingerUpQ);
				SetRotation(leftHandLittleFinger1,  motionData.leftLittleFingerUnderQ);
				SetRotation(leftHandLittleFinger2, motionData.leftLittleFingerMidQ);
				SetRotation(leftHandLittleFinger3,  motionData.leftLittleFingerUpQ);
				//---------------右手------------------
				SetRotation(rightHandThumb1,  motionData.rightThumbUnderQ);
				SetRotation(rightHandThumb2,motionData.rightThumbMidQ);
				SetRotation(rightHandThumb3,  motionData.rightThumbUpQ);
				SetRotation(rightHandIndexFinger1,  motionData.rightForeFingerUnderQ);
				SetRotation(rightHandIndexFinger2, motionData.rightForeFingerMidQ);
				SetRotation(rightHandIndexFinger3,  motionData.rightForeFingerUpQ);
				SetRotation(rightHandMiddleFinger1, motionData.rightMiddleFingerUnderQ);
				SetRotation(rightHandMiddleFinger2, motionData.rightMiddleFingerMidQ);
				SetRotation(rightHandMiddleFinger3, motionData.rightMiddleFingerUpQ);
				SetRotation(rightHandRingFinger1,motionData.rightRingFingerUnderQ);
				SetRotation(rightHandRingFinger2,  motionData.rightRingFingerMidQ);
				SetRotation(rightHandRingFinger3,  motionData.rightRingFingerUpQ);
				SetRotation(rightHandLittleFinger1, motionData.rightLittleFingerUnderQ);
				SetRotation(rightHandLittleFinger2,  motionData.rightLittleFingerMidQ);
				SetRotation(rightHandLittleFinger3, motionData.rightLittleFingerUpQ);
			}
		}
		catch (Exception e)
		{
			Debug.LogError("驱动数据错误:" + e.Message);
		}
	}

	/// <summary>
	/// 设置骨骼姿态
	/// </summary>
	/// <param name="boneTF"></param>
	/// <param name="euler"></param>
	protected override void SetRotation(Transform boneTF, Quaternion globalQua)
	{
		base.SetRotation(boneTF, globalQua);
	}

	//设置模型位置
	protected override void SetPosition(Transform rootTF, Vector3 position)
	{
		base.SetPosition(rootTF, position);
	}

	protected override void InitBone(Transform bone)
	{
		base.InitBone(bone);
	}

	/// <summary>
	/// 编辑器一键绑定骨骼
	/// </summary>
	public void BindBone()
	{
		animator = GetComponent<Animator>();
		if (animator == null)
		{
			Debug.LogError("请添加Animator组件");
			return;
		}

		head = animator.GetBoneTransform(HumanBodyBones.Head);
		back = animator.GetBoneTransform(HumanBodyBones.UpperChest);
		crotch = animator.GetBoneTransform(HumanBodyBones.Hips);
		waistOne = animator.GetBoneTransform(HumanBodyBones.Chest);
		waistTwo = animator.GetBoneTransform(HumanBodyBones.Spine);
		leftShoulder = animator.GetBoneTransform(HumanBodyBones.LeftShoulder);
		leftUpperArm = animator.GetBoneTransform(HumanBodyBones.LeftUpperArm);
		leftLowerArm = animator.GetBoneTransform(HumanBodyBones.LeftLowerArm);
		leftHand = animator.GetBoneTransform(HumanBodyBones.LeftHand);
		rightShoulder = animator.GetBoneTransform(HumanBodyBones.RightShoulder);
		rightUpperArm = animator.GetBoneTransform(HumanBodyBones.RightUpperArm);
		rightLowerArm = animator.GetBoneTransform(HumanBodyBones.RightLowerArm);
		rightHand = animator.GetBoneTransform(HumanBodyBones.RightHand);

		leftUpperLeg = animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg);
		leftLowerLeg = animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg);
		leftFoot = animator.GetBoneTransform(HumanBodyBones.LeftFoot);
		leftToe = animator.GetBoneTransform(HumanBodyBones.LeftToes);
		rightUpperLeg = animator.GetBoneTransform(HumanBodyBones.RightUpperLeg);
		rightLowerLeg = animator.GetBoneTransform(HumanBodyBones.RightLowerLeg);
		rightFoot = animator.GetBoneTransform(HumanBodyBones.RightFoot);
		rightToe = animator.GetBoneTransform(HumanBodyBones.RightToes);

		leftHandThumb1 = animator.GetBoneTransform(HumanBodyBones.LeftThumbProximal);
		leftHandThumb2 = animator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate);
		leftHandThumb3 = animator.GetBoneTransform(HumanBodyBones.LeftThumbDistal);
		leftHandIndexFinger1 = animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal);
		leftHandIndexFinger2 = animator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate);
		leftHandIndexFinger3 = animator.GetBoneTransform(HumanBodyBones.LeftIndexDistal);
		leftHandMiddleFinger1 = animator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal);
		leftHandMiddleFinger2 = animator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate);
		leftHandMiddleFinger3 = animator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal);
		leftHandRingFinger1 = animator.GetBoneTransform(HumanBodyBones.LeftRingProximal);
		leftHandRingFinger2 = animator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate);
		leftHandRingFinger3 = animator.GetBoneTransform(HumanBodyBones.LeftRingDistal);
		leftHandLittleFinger1 = animator.GetBoneTransform(HumanBodyBones.LeftLittleProximal);
		leftHandLittleFinger2 = animator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate);
		leftHandLittleFinger3 = animator.GetBoneTransform(HumanBodyBones.LeftLittleDistal);

		rightHandThumb1 = animator.GetBoneTransform(HumanBodyBones.RightThumbProximal);
		rightHandThumb2 = animator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate);
		rightHandThumb3 = animator.GetBoneTransform(HumanBodyBones.RightThumbDistal);
		rightHandIndexFinger1 = animator.GetBoneTransform(HumanBodyBones.RightIndexProximal);
		rightHandIndexFinger2 = animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate);
		rightHandIndexFinger3 = animator.GetBoneTransform(HumanBodyBones.RightIndexDistal);
		rightHandMiddleFinger1 = animator.GetBoneTransform(HumanBodyBones.RightMiddleProximal);
		rightHandMiddleFinger2 = animator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate);
		rightHandMiddleFinger3 = animator.GetBoneTransform(HumanBodyBones.RightMiddleDistal);
		rightHandRingFinger1 = animator.GetBoneTransform(HumanBodyBones.RightRingProximal);
		rightHandRingFinger2 = animator.GetBoneTransform(HumanBodyBones.RightRingIntermediate);
		rightHandRingFinger3 = animator.GetBoneTransform(HumanBodyBones.RightRingDistal);
		rightHandLittleFinger1 = animator.GetBoneTransform(HumanBodyBones.RightLittleProximal);
		rightHandLittleFinger2 = animator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate);
		rightHandLittleFinger3 = animator.GetBoneTransform(HumanBodyBones.RightLittleDistal);
	}


	public override float[] GetGloveData()
	{
		float[] gloveData = new float[128];

		//---------------左手------------------
		SetGloveData(leftHand, gloveData, 0);
		SetGloveData(leftHandThumb1, gloveData, 1);
		SetGloveData(leftHandThumb2, gloveData, 2);
		SetGloveData(leftHandThumb3, gloveData, 3);
		SetGloveData(leftHandIndexFinger1, gloveData, 4);
		SetGloveData(leftHandIndexFinger2, gloveData, 5);
		SetGloveData(leftHandIndexFinger3, gloveData, 6);
		SetGloveData(leftHandMiddleFinger1, gloveData, 7);
		SetGloveData(leftHandMiddleFinger2, gloveData, 8);
		SetGloveData(leftHandMiddleFinger3, gloveData, 9);
		SetGloveData(leftHandRingFinger1, gloveData, 10);
		SetGloveData(leftHandRingFinger2, gloveData, 11);
		SetGloveData(leftHandRingFinger3, gloveData, 12);
		SetGloveData(leftHandLittleFinger1, gloveData, 13);
		SetGloveData(leftHandLittleFinger2, gloveData, 14);
		SetGloveData(leftHandLittleFinger3, gloveData, 15);
		//---------------右手------------------
		SetGloveData(rightHand, gloveData, 16);
		SetGloveData(rightHandThumb1, gloveData, 17);
		SetGloveData(rightHandThumb2, gloveData, 18);
		SetGloveData(rightHandThumb3, gloveData, 19);
		SetGloveData(rightHandIndexFinger1, gloveData, 20);
		SetGloveData(rightHandIndexFinger2, gloveData, 21);
		SetGloveData(rightHandIndexFinger3, gloveData, 22);
		SetGloveData(rightHandMiddleFinger1, gloveData, 23);
		SetGloveData(rightHandMiddleFinger2, gloveData, 24);
		SetGloveData(rightHandMiddleFinger3, gloveData, 25);
		SetGloveData(rightHandRingFinger1, gloveData, 26);
		SetGloveData(rightHandRingFinger2, gloveData, 27);
		SetGloveData(rightHandRingFinger3, gloveData, 28);
		SetGloveData(rightHandLittleFinger1, gloveData, 29);
		SetGloveData(rightHandLittleFinger2, gloveData, 30);
		SetGloveData(rightHandLittleFinger3, gloveData, 31);
		return gloveData;
	}

	private void SetGloveData(Transform bone, float[] gloveData,int index)
	{
		Quaternion quaternion = bone.rotation;
		gloveData[index * 4 + 0] = quaternion.w;
		gloveData[index * 4 + 1] = quaternion.x;
		gloveData[index * 4 + 2] = quaternion.y;
		gloveData[index * 4 + 3] = quaternion.z;
	}


	private void OnDestroy()
	{

	}
}