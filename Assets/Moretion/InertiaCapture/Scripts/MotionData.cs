/******************************************************************************
 
  
***************************************************************************** */

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeviceList
{
	public List<MotionData> deviceList { get; set; }
}


public class MotionData
{
	#region 对应json中的结构
	private string actorName { get; set; }//角色名
	public string deviceId { get; set; }//设备id
	public string bvhRotationOrder { get; set; }//bvh顺序

	public List<float> coordinate { get; set; }//根节点位置信息
	public List<float> initCoordinate { get; set; }//根节点初始位置
	public List<float> crotch { get; set; }
	public List<float> waistOne { get; set; }
	public List<float> waistTwo { get; set; }
	public List<float> back { get; set; }
	public List<float> head { get; set; }

	public List<float> leftUpperLeg { get; set; }
	public List<float> leftLowerLeg { get; set; }
	public List<float> leftFoot { get; set; }
	public List<float> leftToe { get; set; }

	public List<float> rightUpperLeg { get; set; }
	public List<float> rightLowerLeg { get; set; }
	public List<float> rightFoot { get; set; }
	public List<float> rightToe { get; set; }

	public List<float> leftShoulder { get; set; }
	public List<float> leftUpperArm { get; set; }
	public List<float> leftLowerArm { get; set; }
	public List<float> leftHand { get; set; }

	public List<float> rightShoulder { get; set; }
	public List<float> rightUpperArm { get; set; }
	public List<float> rightLowerArm { get; set; }
	public List<float> rightHand { get; set; }

	public List<float> leftThumbUnder { get; set; }//左手拇指
	public List<float> leftThumbMid { get; set; }
	public List<float> leftThumbUp { get; set; }

	public List<float> leftForeFingerUnder { get; set; }//左手食指
	public List<float> leftForeFingerMid { get; set; }
	public List<float> leftForeFingerUp { get; set; }

	public List<float> leftMiddleFingerUnder { get; set; }//左手中指
	public List<float> leftMiddleFingerMid { get; set; }
	public List<float> leftMiddleFingerUp { get; set; }

	public List<float> leftRingFingerUnder { get; set; }//左手无名指
	public List<float> leftRingFingerMid { get; set; }
	public List<float> leftRingFingerUp { get; set; }

	public List<float> leftLittleFingerUnder { get; set; }//左手小拇指
	public List<float> leftLittleFingerMid { get; set; }
	public List<float> leftLittleFingerUp { get; set; }

	public List<float> rightThumbUnder { get; set; }//右手拇指
	public List<float> rightThumbMid { get; set; }
	public List<float> rightThumbUp { get; set; }

	public List<float> rightForeFingerUnder { get; set; }//右手食指
	public List<float> rightForeFingerMid { get; set; }
	public List<float> rightForeFingerUp { get; set; }

	public List<float> rightMiddleFingerUnder { get; set; }//右手中指
	public List<float> rightMiddleFingerMid { get; set; }
	public List<float> rightMiddleFingerUp { get; set; }

	public List<float> rightRingFingerUnder { get; set; }//右手无名指
	public List<float> rightRingFingerMid { get; set; }
	public List<float> rightRingFingerUp { get; set; }

	public List<float> rightLittleFingerUnder { get; set; }//右手小拇指
	public List<float> rightLittleFingerMid { get; set; }
	public List<float> rightLittleFingerUp { get; set; }
	#endregion


	#region 骨骼对应的四元数数据
	public Quaternion crotchQ { get; set; }
	public Quaternion waistOneQ { get; set; }
	public Quaternion waistTwoQ { get; set; }
	public Quaternion backQ { get; set; }
	public Quaternion headQ { get; set; }

	public Quaternion leftUpperLegQ { get; set; }
	public Quaternion leftLowerLegQ { get; set; }
	public Quaternion leftFootQ { get; set; }
	public Quaternion leftToeQ { get; set; }

	public Quaternion rightUpperLegQ { get; set; }
	public Quaternion rightLowerLegQ { get; set; }
	public Quaternion rightFootQ { get; set; }
	public Quaternion rightToeQ { get; set; }

	public Quaternion leftShoulderQ { get; set; }
	public Quaternion leftUpperArmQ { get; set; }
	public Quaternion leftLowerArmQ { get; set; }
	public Quaternion leftHandQ { get; set; }

	public Quaternion rightShoulderQ { get; set; }
	public Quaternion rightUpperArmQ { get; set; }
	public Quaternion rightLowerArmQ { get; set; }
	public Quaternion rightHandQ { get; set; }

	public Quaternion leftThumbUnderQ { get; set; }//左手拇指
	public Quaternion leftThumbMidQ { get; set; }
	public Quaternion leftThumbUpQ { get; set; }

	public Quaternion leftForeFingerUnderQ { get; set; }//左手食指
	public Quaternion leftForeFingerMidQ { get; set; }
	public Quaternion leftForeFingerUpQ { get; set; }

	public Quaternion leftMiddleFingerUnderQ { get; set; }//左手中指
	public Quaternion leftMiddleFingerMidQ { get; set; }
	public Quaternion leftMiddleFingerUpQ { get; set; }

	public Quaternion leftRingFingerUnderQ { get; set; }//左手无名指
	public Quaternion leftRingFingerMidQ { get; set; }
	public Quaternion leftRingFingerUpQ { get; set; }

	public Quaternion leftLittleFingerUnderQ { get; set; }//左手小拇指
	public Quaternion leftLittleFingerMidQ { get; set; }
	public Quaternion leftLittleFingerUpQ { get; set; }

	public Quaternion rightThumbUnderQ { get; set; }//右手拇指
	public Quaternion rightThumbMidQ { get; set; }
	public Quaternion rightThumbUpQ { get; set; }

	public Quaternion rightForeFingerUnderQ { get; set; }//右手食指
	public Quaternion rightForeFingerMidQ { get; set; }
	public Quaternion rightForeFingerUpQ { get; set; }

	public Quaternion rightMiddleFingerUnderQ { get; set; }//右手中指
	public Quaternion rightMiddleFingerMidQ { get; set; }
	public Quaternion rightMiddleFingerUpQ { get; set; }

	public Quaternion rightRingFingerUnderQ { get; set; }//右手无名指
	public Quaternion rightRingFingerMidQ { get; set; }
	public Quaternion rightRingFingerUpQ { get; set; }

	public Quaternion rightLittleFingerUnderQ { get; set; }//右手小拇指
	public Quaternion rightLittleFingerMidQ { get; set; }
	public Quaternion rightLittleFingerUpQ { get; set; }
	#endregion


	/// <summary>
	/// 设置骨骼全局四元数
	/// </summary>
	public void SetBoneGlobalQua()
	{
		crotchQ = DataConvert.Euler2Quaternion(crotch, bvhRotationOrder);

		waistOneQ = crotchQ * DataConvert.Euler2Quaternion(waistOne, bvhRotationOrder);
		waistTwoQ = waistOneQ * DataConvert.Euler2Quaternion(waistTwo, bvhRotationOrder);
		backQ = waistTwoQ * DataConvert.Euler2Quaternion(back, bvhRotationOrder);

		headQ = backQ * DataConvert.Euler2Quaternion(head, bvhRotationOrder);

		leftUpperLegQ = crotchQ * DataConvert.Euler2Quaternion(leftUpperLeg, bvhRotationOrder);
		leftLowerLegQ = leftUpperLegQ * DataConvert.Euler2Quaternion(leftLowerLeg, bvhRotationOrder);
		leftFootQ = leftLowerLegQ * DataConvert.Euler2Quaternion(leftFoot, bvhRotationOrder);
		leftToeQ = leftFootQ * DataConvert.Euler2Quaternion(leftToe, bvhRotationOrder);

		rightUpperLegQ = crotchQ * DataConvert.Euler2Quaternion(rightUpperLeg, bvhRotationOrder);
		rightLowerLegQ = rightUpperLegQ * DataConvert.Euler2Quaternion(rightLowerLeg, bvhRotationOrder);
		rightFootQ = rightLowerLegQ * DataConvert.Euler2Quaternion(rightFoot, bvhRotationOrder);
		rightToeQ = rightFootQ * DataConvert.Euler2Quaternion(rightToe, bvhRotationOrder);

		leftShoulderQ = backQ * DataConvert.Euler2Quaternion(leftShoulder, bvhRotationOrder);
		leftUpperArmQ = leftShoulderQ * DataConvert.Euler2Quaternion(leftUpperArm, bvhRotationOrder);
		leftLowerArmQ = leftUpperArmQ * DataConvert.Euler2Quaternion(leftLowerArm, bvhRotationOrder);
		leftHandQ = leftLowerArmQ * DataConvert.Euler2Quaternion(leftHand, bvhRotationOrder);

		rightShoulderQ = backQ * DataConvert.Euler2Quaternion(rightShoulder, bvhRotationOrder);
		rightUpperArmQ = rightShoulderQ * DataConvert.Euler2Quaternion(rightUpperArm, bvhRotationOrder);
		rightLowerArmQ = rightUpperArmQ * DataConvert.Euler2Quaternion(rightLowerArm, bvhRotationOrder);
		rightHandQ = rightLowerArmQ * DataConvert.Euler2Quaternion(rightHand, bvhRotationOrder);

		leftThumbUnderQ = leftHandQ * DataConvert.Euler2Quaternion(leftThumbUnder, bvhRotationOrder);//左手拇指
		leftThumbMidQ = leftThumbUnderQ * DataConvert.Euler2Quaternion(leftThumbMid, bvhRotationOrder);
		leftThumbUpQ = leftThumbMidQ * DataConvert.Euler2Quaternion(leftThumbUp, bvhRotationOrder);

		leftForeFingerUnderQ = leftHandQ * DataConvert.Euler2Quaternion(leftForeFingerUnder, bvhRotationOrder);//左手食指
		leftForeFingerMidQ = leftForeFingerUnderQ * DataConvert.Euler2Quaternion(leftForeFingerMid, bvhRotationOrder);
		leftForeFingerUpQ = leftForeFingerMidQ * DataConvert.Euler2Quaternion(leftForeFingerUp, bvhRotationOrder);

		leftMiddleFingerUnderQ = leftHandQ * DataConvert.Euler2Quaternion(leftMiddleFingerUnder, bvhRotationOrder);//左手中指
		leftMiddleFingerMidQ = leftMiddleFingerUnderQ * DataConvert.Euler2Quaternion(leftMiddleFingerMid, bvhRotationOrder);
		leftMiddleFingerUpQ = leftMiddleFingerMidQ * DataConvert.Euler2Quaternion(leftMiddleFingerUp, bvhRotationOrder);

		leftRingFingerUnderQ = leftHandQ * DataConvert.Euler2Quaternion(leftRingFingerUnder, bvhRotationOrder);//左手无名指
		leftRingFingerMidQ = leftRingFingerUnderQ * DataConvert.Euler2Quaternion(leftRingFingerMid, bvhRotationOrder);
		leftRingFingerUpQ = leftRingFingerMidQ * DataConvert.Euler2Quaternion(leftRingFingerUp, bvhRotationOrder);

		leftLittleFingerUnderQ = leftHandQ * DataConvert.Euler2Quaternion(leftLittleFingerUnder, bvhRotationOrder);//左手小拇指
		leftLittleFingerMidQ = leftLittleFingerUnderQ * DataConvert.Euler2Quaternion(leftLittleFingerMid, bvhRotationOrder);
		leftLittleFingerUpQ = leftLittleFingerMidQ * DataConvert.Euler2Quaternion(leftLittleFingerUp, bvhRotationOrder);

		rightThumbUnderQ = rightHandQ * DataConvert.Euler2Quaternion(rightThumbUnder, bvhRotationOrder);//右手拇指
		rightThumbMidQ = rightThumbUnderQ * DataConvert.Euler2Quaternion(rightThumbMid, bvhRotationOrder);
		rightThumbUpQ = rightThumbMidQ * DataConvert.Euler2Quaternion(rightThumbUp, bvhRotationOrder);

		rightForeFingerUnderQ = rightHandQ * DataConvert.Euler2Quaternion(rightForeFingerUnder, bvhRotationOrder);//右手食指
		rightForeFingerMidQ = rightForeFingerUnderQ * DataConvert.Euler2Quaternion(rightForeFingerMid, bvhRotationOrder);
		rightForeFingerUpQ = rightForeFingerMidQ * DataConvert.Euler2Quaternion(rightForeFingerUp, bvhRotationOrder);

		rightMiddleFingerUnderQ = rightHandQ * DataConvert.Euler2Quaternion(rightMiddleFingerUnder, bvhRotationOrder);//右手中指
		rightMiddleFingerMidQ = rightMiddleFingerUnderQ * DataConvert.Euler2Quaternion(rightMiddleFingerMid, bvhRotationOrder);
		rightMiddleFingerUpQ = rightMiddleFingerMidQ * DataConvert.Euler2Quaternion(rightMiddleFingerUp, bvhRotationOrder);

		rightRingFingerUnderQ = rightHandQ * DataConvert.Euler2Quaternion(rightRingFingerUnder, bvhRotationOrder);//右手无名指
		rightRingFingerMidQ = rightRingFingerUnderQ * DataConvert.Euler2Quaternion(rightRingFingerMid, bvhRotationOrder);
		rightRingFingerUpQ = rightRingFingerMidQ * DataConvert.Euler2Quaternion(rightRingFingerUp, bvhRotationOrder);

		rightLittleFingerUnderQ = rightHandQ * DataConvert.Euler2Quaternion(rightLittleFingerUnder, bvhRotationOrder);//右手小拇指
		rightLittleFingerMidQ = rightLittleFingerUnderQ * DataConvert.Euler2Quaternion(rightLittleFingerMid, bvhRotationOrder);
		rightLittleFingerUpQ = rightLittleFingerMidQ * DataConvert.Euler2Quaternion(rightLittleFingerUp, bvhRotationOrder);
	}
}