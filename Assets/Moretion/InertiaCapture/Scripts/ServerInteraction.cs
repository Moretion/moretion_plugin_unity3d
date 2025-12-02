/******************************************************************************
 和服务端交互
  
*******************************************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class ServerInteraction : MonoBehaviour
{
	public static ServerInteraction Instance;

	public bool isShake = false;
	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		if (isShake)
		{
			Shake("100", 5, 2);
			isShake = false;
		}
	}

	/// <summary>
	/// 手套震动
	/// </summary>
	/// <param name="gloveID">手套id</param>
	/// <param name="shakePattern">震动模式 0=震动0.5s 1=震动1s 以此类推最多震动5s</param>
	/// <param name="handType">1=左手  2=右手</param>
	public void Shake(string gloveID, int shakePattern, int handType)
	{
		if (shakePattern < 0)
		{
			shakePattern = 0;
		}
		if (shakePattern > 9)
		{
			shakePattern = 9;
		}

		if (handType < 1)
		{
			handType = 1;
		}
		if (handType > 2)
		{
			handType = 2;
		}

		Shake shake = new Shake();
		shake.control = "motorShake";
		shake.deviceId = "100";//选填
		shake.shakePattern = shakePattern;
		shake.nodeList = new List<int>() { handType };

		string sendData = JsonConvert.SerializeObject(shake);
		Debug.Log("震动马达发送的消息:" + sendData);
		bool result = MotionSourceManager.Instance.SendMessage(sendData);

		if (result)
		{
			Debug.Log("震动马达-向服务端发送消息成功");
		}
		else
		{
			Debug.Log("震动马达-向服务端发送消息失败");
		}
	}
}



public class Shake
{
	public string control;
	public string deviceId;
	public int shakePattern;
	public List<int> nodeList;
}