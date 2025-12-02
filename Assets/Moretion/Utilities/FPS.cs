using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 
 * 显示FPS
 * 
 * 
 * 
 */

public class FPS : MonoBehaviour
{
	//public enum VSyncMode
	//{
	//	DontSync,
	//	EveryVBlank,
	//	EverySecondVBlank
	//}

	public float updateInterval = 0.5f;
	public float fps { get; protected set; }
	//public VSyncMode mode;
	public Text textFPS = null;

	//protected VSyncMode currentMode;
	protected float accum = 0;
	protected int frames = 0;
	protected float timeleft;

	protected void Start()
	{
		timeleft = updateInterval;
	}

	protected void Update()
	{	
		//ToggleMode();
		timeleft -= Time.deltaTime;
		accum += Time.timeScale / Time.deltaTime;
		++frames;

		if (timeleft <= 0.0f)
		{
			fps = accum / frames;
			timeleft = updateInterval;
			accum = 0.0f;
			frames = 0;
		}

		if (textFPS != null)
		{
			textFPS.text = Mathf.FloorToInt(fps).ToString();
		}
	}


	/// <summary>
	/// 
	/// </summary>
	//private void ToggleMode()
	//{
	//	if (currentMode != mode)
	//	{
	//		QualitySettings.vSyncCount = (int)mode;
	//		currentMode = mode;
	//	}
	//	else if ((int)currentMode != QualitySettings.vSyncCount)
	//	{
	//		mode = (VSyncMode)QualitySettings.vSyncCount;
	//		currentMode = mode;
	//	}
	//}
}
