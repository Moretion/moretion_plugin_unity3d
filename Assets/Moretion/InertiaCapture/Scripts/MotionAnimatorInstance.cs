/******************************************************************************
 Animator方式驱动模型
  
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class MotionAnimatorInstance : MotionInstance
{
	public Animator animator;
	public override void Start()
	{
		if (animator == null)
			animator = transform.GetComponent<Animator>();
		InitModel();
	}

	public override void Update()
	{

	}

	protected override void InitModel()
	{
		InitBone(animator.GetBoneTransform(HumanBodyBones.Hips));

		InitBone(animator.GetBoneTransform(HumanBodyBones.Spine));
		InitBone(animator.GetBoneTransform(HumanBodyBones.Chest));
		InitBone(animator.GetBoneTransform(HumanBodyBones.UpperChest));
		InitBone(animator.GetBoneTransform(HumanBodyBones.Head));

		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftShoulder));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftLowerArm));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftHand));

		InitBone(animator.GetBoneTransform(HumanBodyBones.RightShoulder));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightUpperArm));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightLowerArm));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightHand));

		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftFoot));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftToes));

		InitBone(animator.GetBoneTransform(HumanBodyBones.RightUpperLeg));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightLowerLeg));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightFoot));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightToes));

		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftThumbProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftThumbDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftIndexDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftRingProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftRingDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftLittleProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.LeftLittleDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.RightThumbProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightThumbDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.RightIndexProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightIndexDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.RightMiddleProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightMiddleDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.RightRingProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightRingIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightRingDistal));

		InitBone(animator.GetBoneTransform(HumanBodyBones.RightLittleProximal));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate));
		InitBone(animator.GetBoneTransform(HumanBodyBones.RightLittleDistal));
	}


	/// <summary>
	/// 设置模型位置和骨骼姿态
	/// </summary>
	/// <param name="motionData"></param>
	public override void ApplyMotion(MotionData motionData)
	{
		//设置模型位置
		Vector3 pos = new Vector3(motionData.coordinate[0] + positionOffset.x, motionData.coordinate[1] + positionOffset.y, motionData.coordinate[2] + positionOffset.z);
		SetPosition(animator.GetBoneTransform(HumanBodyBones.Hips), pos);
		

		SetRotation(animator.GetBoneTransform(HumanBodyBones.Hips), motionData.crotchQ);

		SetRotation(animator.GetBoneTransform(HumanBodyBones.Spine), motionData.waistOneQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.Chest), motionData.waistTwoQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.UpperChest), motionData.backQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.Head), motionData.headQ);

		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftShoulder), motionData.leftShoulderQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm), motionData.leftUpperArmQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftLowerArm), motionData.leftLowerArmQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftHand), motionData.leftHandQ);

		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightShoulder), motionData.rightShoulderQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightUpperArm), motionData.rightUpperArmQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightLowerArm), motionData.rightLowerArmQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightHand), motionData.rightHandQ);

		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg), motionData.leftUpperLegQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftLowerLeg), motionData.leftLowerLegQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftFoot), motionData.leftFootQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftToes), motionData.leftToeQ);

		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightUpperLeg), motionData.rightUpperLegQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightLowerLeg), motionData.rightLowerLegQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightFoot), motionData.rightFootQ);
		SetRotation(animator.GetBoneTransform(HumanBodyBones.RightToes), motionData.rightToeQ);

		if (isUseHand)
		{
			//---------------左手------------------
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftThumbProximal), motionData.leftThumbUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate), motionData.leftThumbMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftThumbDistal), motionData.leftThumbUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftIndexProximal), motionData.leftForeFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate), motionData.leftForeFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftIndexDistal), motionData.leftForeFingerUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftMiddleProximal), motionData.leftMiddleFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate), motionData.leftMiddleFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftMiddleDistal), motionData.leftMiddleFingerUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftRingProximal), motionData.leftRingFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftRingIntermediate), motionData.leftRingFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftRingDistal), motionData.leftRingFingerUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftLittleProximal), motionData.leftLittleFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate), motionData.leftLittleFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.LeftLittleDistal), motionData.leftLittleFingerUpQ);
			//---------------右手------------------
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightThumbProximal), motionData.rightThumbUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightThumbIntermediate), motionData.rightThumbMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightThumbDistal), motionData.rightThumbUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightIndexProximal), motionData.rightForeFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightIndexIntermediate), motionData.rightForeFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightIndexDistal), motionData.rightForeFingerUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightMiddleProximal), motionData.rightMiddleFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate), motionData.rightMiddleFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightMiddleDistal), motionData.rightMiddleFingerUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightRingProximal), motionData.rightRingFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightRingIntermediate), motionData.rightRingFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightRingDistal), motionData.rightRingFingerUpQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightLittleProximal), motionData.rightLittleFingerUnderQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightLittleIntermediate), motionData.rightLittleFingerMidQ);
			SetRotation(animator.GetBoneTransform(HumanBodyBones.RightLittleDistal), motionData.rightLittleFingerUpQ);
		}
	}

	protected override void InitBone(Transform bone)
	{
		base.InitBone(bone);
	}

	protected override void SetPosition(Transform rootTF, Vector3 position)
	{
		base.SetPosition(rootTF, position);
	}

	protected override void SetRotation(Transform boneTF,Quaternion localQua)
	{
		base.SetRotation(boneTF,localQua);
	}
}
