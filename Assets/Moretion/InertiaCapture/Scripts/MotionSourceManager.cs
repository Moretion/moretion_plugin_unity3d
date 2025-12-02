/******************************************************************************
 动捕数据来源
  
***************************************************************************** */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class MotionSourceManager : MonoBehaviour
{
	public static MotionSourceManager Instance;
    public SocketType socketType = SocketType.TCP;
    public string server_ip = "192.168.2.10";
    public string server_port = "7788";
    public string client_ip = "192.168.2.10";
    public string client_port = "5566";
	public bool autoConnect = true;
	public MotionInstance[] motionInstances;
	private MotionConnect motionConnect;


	private void Awake()
	{
		Instance = this;
	}

	// Start is called before the first frame update
	void Start()
    {
		motionConnect = new MotionConnect(motionInstances);
		if (autoConnect)
		{
			Task.Run(() =>
			{
				Connect(socketType);
			});			
		}
    }

    // Update is called once per frame
    void Update()
    {
		
    }

	/// <summary>
	/// 连接服务器
	/// </summary>
	/// <param name="type"></param>
	public int Connect(SocketType type)
	{
		int result = 0;
		try
		{
			switch (type)
			{
				case SocketType.TCP:
					result = motionConnect.ConnectTCP(server_ip, server_port);
					break;
				case SocketType.UDP:
					result = motionConnect.ConnectUDP(server_ip, server_port, client_ip, client_port);
					break;
			}

			if (result == 1)
			{
				Debug.Log("连接服务器成功");
			}
			else if (result == -1)
			{
				Debug.LogError("连接服务器失败");
			}
		}
		catch (Exception e)
		{
			Debug.LogError("连接服务器错误:" + e.Message);
		}
		return result;
	}

	/// <summary>
	/// 断开连接
	/// </summary>
	public void Disconnect()
	{
		motionConnect.Destory();
	}

	/// <summary>
	/// 向服务端发送消息
	/// </summary>
	/// <param name="msg"></param>
	/// <returns></returns>
	public new bool SendMessage(string msg)
	{
		try
		{
			if (socketType == SocketType.TCP)
			{
				return motionConnect.TcpSendMessage(msg);
			}
			else if (socketType == SocketType.UDP)
			{
				return motionConnect.UdpSendMessage(msg);
			}
			else
			{
				return false;
			}
		}
		catch (Exception e)
		{
			Debug.LogError("向服务端发送消息错误");
			return false;
		}
	}


	private void OnApplicationQuit()
	{
		motionConnect.Destory();
	}

	private void OnDestroy()
	{
		
	}
}
