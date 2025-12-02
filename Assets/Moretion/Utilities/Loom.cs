/******************************************************************************
 子线程调用主线程中的方法
 当做中间桥梁
  
*******************************************************************************/

using UnityEngine;
using System.Collections.Generic;
using System;
using System.Threading;
using System.Linq;
using System.Collections.Concurrent;

public class Loom : MonoBehaviour
{
	public static Loom Instance;
	private ConcurrentQueue<Action> queue;
	private Action curAction;

	private Loom() { }


	void Awake()
	{
		Instance = this;
		if (queue == null)
			queue = new ConcurrentQueue<Action>();
	}

	private void Start()
	{

	}

	/// <summary>
	/// 向主线程中添加事件
	/// </summary>
	/// <param name="action"></param>
	public void AddEventOnMainThread(Action action)
	{
		queue.Enqueue(action);
	}


	private void Update()
	{
		if (queue.Count > 0)
		{
			for (int i = 0; i < queue.Count; i++)
			{
				if (queue.TryDequeue(out curAction))
					curAction();
			}
		}
	}

	private void OnDestroy()
	{
		Instance = null;
	}
}
