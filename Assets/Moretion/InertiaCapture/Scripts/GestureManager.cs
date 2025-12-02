using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class GestureManager : MonoBehaviour
{

	[DllImport("Motion_RecognizeHG")]
	public extern static void creatRecognizeHG();

	[DllImport("Motion_RecognizeHG")]
	public extern static OutPutGesture recognizeHG(float[] quaData);

	[DllImport("Motion_RecognizeHG")]
	public extern static void releaseRecognizeHG();



	public MotionInstance motionInstance;

	private float[] inputQuaData = new float[128];

	private OutPutGesture preGesture;

	private int updateCount = 0;

	public event Action<int, GestureType> gestureChangeEvent;


	public Text leftHandGesture_Text;
	public Text leftHandGestureProbability_Text;
	public Text rightHandGesture_Text;
	public Text rightHandGestureProbability_Text;


	// Start is called before the first frame update
	void Start()
	{
		Init();
	}


	private void Init()
	{
		creatRecognizeHG();

		preGesture.left_hand_label = -1;
		preGesture.left_hand_probability = 100;
		preGesture.right_hand_label = -1;
		preGesture.right_hand_probability = 100;
	}

	private void Update()
	{
		if (updateCount % 3 == 0)
		{
			UpDateGesture();
		}
		updateCount++;
	}

	/// <summary>
	/// 更新手势
	/// </summary>
	private void UpDateGesture()
	{
		inputQuaData = motionInstance.GetGloveData();
		OutPutGesture curGesture = recognizeHG(inputQuaData);
		Debug.Log("左手手势:" + curGesture.left_hand_label + "  概率:" + curGesture.left_hand_probability + "  右手手势:" + curGesture.right_hand_label + "  概率:" + curGesture.right_hand_probability);

		if (curGesture.left_hand_label >= 0)
		{
			if (curGesture.left_hand_label != preGesture.left_hand_label)
			{
				if (curGesture.left_hand_probability > 80)
				{
					gestureChangeEvent?.Invoke(1, (GestureType)Enum.Parse(typeof(GestureType), curGesture.left_hand_label.ToString()));
				}
			}
		}

		if (curGesture.right_hand_label >= 0)
		{
			if (curGesture.right_hand_label != preGesture.right_hand_label)
			{
				if (curGesture.right_hand_probability > 80)
				{
					gestureChangeEvent?.Invoke(2, (GestureType)Enum.Parse(typeof(GestureType), curGesture.right_hand_label.ToString()));
				}
			}
		}
		preGesture = curGesture;

		leftHandGesture_Text.text = "左手手势:" + curGesture.left_hand_label.ToString();
		leftHandGestureProbability_Text.text = "左手手势概率:" + curGesture.left_hand_probability.ToString();
		rightHandGesture_Text.text = "右手手势:" + curGesture.right_hand_label.ToString();
		rightHandGestureProbability_Text.text = "右手手势概率:" + curGesture.right_hand_probability.ToString();
	}


	public struct OutPutGesture
	{
		public int left_hand_label;//左手手势
		public double left_hand_probability;//左手手势概率
		public int right_hand_label;//右手手势
		public double right_hand_probability;//右手手势概率
	}


	//手势类型
	public enum GestureType
	{
		OpenHand = 0,//张手
		Grab = 1,//握拳
		Point = 2,//点击
		Victory = 3,//耶
		Pinch = 4,//捏
		Ok = 5//ok
	}


	private void OnDestroy()
	{
		releaseRecognizeHG();
	}
}
