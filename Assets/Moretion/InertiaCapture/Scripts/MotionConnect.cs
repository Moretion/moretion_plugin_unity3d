using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using Newtonsoft.Json;
using System.Net.Sockets;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.IO;

/*
 * 
 * socket通信相关
 * 
 * 
 */

public enum SocketType
{
	TCP,
	UDP
}

public class MotionConnect
{

	public MotionType motionType;
	public MotionTransformsInstance motionTransformsInstance;
	public MotionAnimatorInstance motionAnimatorInstance;
	private bool isReceiveData = false;
	private string redundancyData = null;//粘包冗余数据
	private IPEndPoint remoteEndPoint;

	private MotionInstance[] motionInstances;
	private Dictionary<string, int> actorInfoDic = new Dictionary<string, int>();//key:角色id  value:角色索引
	private int maxDeviceCount = -1;//相当于动捕设备数量

	private Dictionary<int, List<MotionInstance>> motionInstanceDic = new Dictionary<int, List<MotionInstance>>();

	private SynchronizationContext m_context;

	public MotionConnect(MotionInstance[] instances)
	{
		this.motionInstances = instances;
		if (motionInstances != null)
		{
			for (int i = 0; i < motionInstances.Length; i++)
			{
				MotionInstance curMotionInstance = motionInstances[i];
				if (curMotionInstance != null)
				{
					int actorId = curMotionInstance.actorID;
					if (motionInstanceDic.ContainsKey(actorId))
					{
						List<MotionInstance> temp = motionInstanceDic[actorId];
						temp.Add(curMotionInstance);
						motionInstanceDic[actorId] = temp;
					}
					else
					{
						List<MotionInstance> temp = new List<MotionInstance>();
						temp.Add(curMotionInstance);
						motionInstanceDic.Add(actorId, temp);
					}
				}
			}
		}
	}


	Socket clientSocket;
	Thread recThread;


	public enum MotionType
	{
		Transform,
		Animator
	}

	/// <summary>
	/// TCP协议连接服务端
	/// </summary>
	/// <param name="ser_ip"></param>
	/// <param name="ser_port"></param>
	/// <returns></returns>
	public int ConnectTCP(string ser_ip, string ser_port)
	{
		try
		{
			if (clientSocket == null)
			{
				Debug.Log("服务端ip:" + ser_ip + "  服务端端口:" + ser_port);
				//创建客户端Socket，设置远程ip和端口号
				clientSocket = new Socket(AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Stream, ProtocolType.Tcp);
				IPAddress ip = IPAddress.Parse(ser_ip);
				IPEndPoint point = new IPEndPoint(ip, Convert.ToInt32(ser_port));
				clientSocket.Connect(point);
				//开启新的线程，不停的接收服务器发来的消息
				isReceiveData = true;
				recThread = new Thread(ReceivedTCP);
				recThread.IsBackground = true;
				recThread.Start();
				return 1;
			}
		}
		catch (Exception)
		{
			Debug.LogError("IP或者端口号错误...");
			Destory();
		}
		return -1;
	}

	/// <summary>
	/// 接收服务端返回的消息TCP
	/// </summary>
	void ReceivedTCP()
	{
		while (isReceiveData)
		{
			try
			{
				if (clientSocket != null && clientSocket.Connected)
				{
					byte[] buffer = new byte[1024 * 20];

					//实际接收到的有效字节数
					int len = clientSocket.Receive(buffer);
					if (len > 0)
					{
						string newData = Encoding.UTF8.GetString(buffer, 0, len);
						//Debug.Log("TCP收到的消息:" + newData.Length + "  " + newData);
						Unpack(newData);
					}
					else
					{
						if (clientSocket.Poll(1000, SelectMode.SelectRead))
						{
							Debug.Log("socket断开连接");
							Destory();
							break;
						}
					}
				}
				Thread.Sleep(1);
			}
			catch (JsonReaderException e)
			{

			}
			catch (SocketException e)
			{
				Debug.LogError("socket异常:" + e.Message);
			}
			catch (Exception e)
			{

			}
		}
	}

	/// <summary>
	/// UDP协议连接服务端
	/// </summary>
	/// <param name="ser_ip"></param>
	/// <param name="ser_port"></param>
	/// <param name="local_ip"></param>
	/// <param name="local_port"></param>
	/// <returns></returns>
	public int ConnectUDP(string ser_ip, string ser_port, string local_ip, string local_port)
	{
		try
		{
			if (clientSocket == null)
			{
				//创建客户端套接字
				clientSocket = new Socket(AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, ProtocolType.Udp);
				//设置客户端套接字的IP地址和端口号
				IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse(local_ip), Convert.ToInt32(local_port));
				clientSocket.Bind(localEndPoint);
				//设置服务器端的IP地址和端口号
				remoteEndPoint = new IPEndPoint(IPAddress.Parse(ser_ip), int.Parse(ser_port));
				EndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(ser_ip), Convert.ToInt32(ser_port));
				//开启线程接收服务端消息
				isReceiveData = true;
				recThread = new Thread(() => ReceivedUDP(ref serverEndPoint));
				recThread.IsBackground = true;
				recThread.Start();
				return 1;
			}
		}
		catch (Exception e)
		{
			Debug.LogError("IP或者端口号错误..." + e.StackTrace + e.Message);
			Destory();
		}
		return -1;
	}


	/// <summary>
	/// 接收服务端返回的消息UDP
	/// </summary>
	void ReceivedUDP(ref EndPoint serverEndPoint)
	{
		try
		{
			while (isReceiveData)
			{
				if (clientSocket != null)
				{
					byte[] buffer = new byte[1024 * 20];
					int len = clientSocket.ReceiveFrom(buffer, ref serverEndPoint);
					if (len > 0)
					{
						string newData = Encoding.UTF8.GetString(buffer, 0, len);
						//Debug.Log("UDP收到的消息:" + newData.Length + "  "+ newData);
						Unpack(newData);
					}
					else
					{
						if (clientSocket.Poll(10000000, SelectMode.SelectRead))
						{
							Debug.Log("socket断开连接");
							Destory();
							break;
						}
					}
				}
				Thread.Sleep(1);
			}
		}
		catch (JsonReaderException e)
		{
			Debug.LogWarning("json格式错误:" + e.Message);
		}
		catch (SocketException e)
		{
			Debug.LogWarning("socket异常:" + e);
		}
		catch (Exception e)
		{

		}
	}

	/// <summary>
	/// TCP协议向服务端发送消息
	/// </summary>
	/// <param name="msg"></param>
	/// <returns></returns>
	public bool TcpSendMessage(string msg)
	{
		try
		{
			if (clientSocket != null && clientSocket.Connected)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(msg);
				clientSocket.Send(bytes);
				return true;
			}
			else
			{
				Debug.LogError("Socket未连接");
				return false;
			}
		}
		catch (Exception e)
		{
			Debug.LogError("socket发送指令错误");
			return false;
		}
	}

	/// <summary>
	/// UDP协议向服务端发送消息
	/// </summary>
	/// <param name="msg"></param>
	/// <returns></returns>
	public bool UdpSendMessage(string msg)
	{
		try
		{
			if (clientSocket != null)
			{
				byte[] data = Encoding.UTF8.GetBytes(msg);
				clientSocket.SendTo(data, remoteEndPoint);
				return true;
			}
			else
			{
				Debug.LogError("Socket未连接");
				return false;
			}
		}
		catch (Exception e)
		{
			Debug.LogError("socket发送指令错误");
			return false;
		}

	}

	/// <summary>
	/// 拆包(每帧数据包尾部是换行符)
	/// </summary>
	/// <param name="data">原始json数据</param>
	private void Unpack(string data)
	{
		try
		{
			if (redundancyData != null)
			{
				data = redundancyData + data;
				redundancyData = null;
			}

			if (data.Contains('\n'))
			{
				string[] datas = data.Split('\n');
				for (int i = 0; i < datas.Length - 1; i++)
				{
					ProcessMessage(datas[i]);
				}
				if (data.EndsWith('\n'))
				{
					redundancyData = null;
				}
				else
				{
					redundancyData = datas[datas.Length - 1];
				}
			}
			else
			{
				redundancyData = data;
			}
		}
		catch (Exception e)
		{
			Debug.LogError("拆包错误:" + data + "  /n" + e);
		}
	}


	/// <summary>
	/// 处理服务端消息
	/// </summary>
	/// <param name="msg"></param>
	private void ProcessMessage(string msg)
	{
		if (msg.Length > 1000)//只有实时bvh数据长度才会大于1000
		{
			PostureData(msg);
		}
		else
		{
			UniversalServerResponse(msg);
		}
	}


	/// <summary>
	/// 实时姿态数据
	/// </summary>
	/// <param name="msg"></param>
	private void PostureData(string msg)
	{
		if (motionInstances != null)
		{
			try
			{
				DeviceList deviceList = JsonConvert.DeserializeObject<DeviceList>(msg);
				List<MotionData> motionDatas = deviceList.deviceList;
				Loom.Instance.AddEventOnMainThread(() =>
				{
					if(motionDatas!=null)
					ApplyMotion(motionDatas);
				});
			}
			catch (Exception e)
			{
				Debug.LogError("解析数据错误:" + msg + "  /n" + msg);
			}
		}
	}

	/// <summary>
	/// 动捕数据驱动模型
	/// </summary>
	/// <param name="motionDatas"></param>
	private void ApplyMotion(List<MotionData> motionDatas)
	{
		for (int i = 0; i < motionDatas.Count; i++)
		{
			MotionData motionData = motionDatas[i];
			motionData.coordinate = new List<float>() { -motionData.coordinate[0], motionData.coordinate[1], motionData.coordinate[2] };
			motionData.SetBoneGlobalQua();
			string deviceId = motionData.deviceId;
			if (!actorInfoDic.ContainsKey(deviceId))
			{
				maxDeviceCount += 1;
				actorInfoDic.Add(motionData.deviceId, maxDeviceCount);
			}

			int actorId = actorInfoDic[deviceId];
			if (motionInstanceDic.ContainsKey(actorId))
			{
				List<MotionInstance> curMotionInstance = motionInstanceDic[actorId];
				foreach (var item in curMotionInstance)
				{
					item.ApplyMotion(motionData);
				}
			}
		}
	}


	/// <summary>
	/// 通用服务端响应
	/// </summary>
	/// <param name="msg"></param>
	private void UniversalServerResponse(string msg)
	{
		//Debug.Log("服务端响应消息:" + msg);
		ServerResponse serverResponse = JsonConvert.DeserializeObject<ServerResponse>(msg);
		if (serverResponse.control == "motorShake")
		{
			Shake(serverResponse);
		}
	}

	/// <summary>
	/// 震动马达
	/// </summary>
	/// <param name="msg"></param>
	private void Shake(ServerResponse serverResponse)
	{
		if (serverResponse.code == 1000)
		{
			Debug.Log("震动马达-成功");
		}
		else
		{
			Debug.Log("震动马达-失败");
		}
	}


	/// <summary>
	/// 释放线程资源
	/// 释放socket资源
	/// </summary>
	public void Destory()
	{
		try
		{
			isReceiveData = false;
			if (recThread != null)
			{
				recThread.Interrupt();
				recThread.Abort();

			}
		}
		catch (ThreadAbortException e)
		{
			recThread = null;
		}
		catch (Exception e)
		{

		}

		try
		{
			if (clientSocket != null)
			{
				if (clientSocket.Connected)
				{
					clientSocket.Dispose();
					clientSocket.Close();
				}
				clientSocket = null;
			}
		}
		catch (Exception e)
		{

		}
	}

	public double GetTimeStamp_MS()
	{
		TimeSpan mTimeSpan = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0);
		return mTimeSpan.TotalMilliseconds;
	}


}


//通用服务端响应消息
public class ServerResponse
{
	public int code;
	public string control;
	public bool data;
	public string msg;
}