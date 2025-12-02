/******************************************************************************
 通用数据转换
  
***************************************************************************** */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataConvert
{

	/// <summary>
	/// 欧拉角转四元数
	/// </summary>
	/// <param name="targetData"></param>
	/// <param name="bvhRotationOrder"></param>
	/// <returns></returns>
	public static Quaternion Euler2Quaternion(List<float> targetData, string bvhRotationOrder)
	{
		float[] temp = new float[3];
		for (int i = 0; i < 3; i++)
		{
			temp[i] = targetData[i] / 180f * Mathf.PI;//度→弧度  π弧度=180°
		}

		float x = 0, y = 0, z = 0, w = 1;
		float c1 = Mathf.Cos(temp[0] / 2f);
		float c2 = Mathf.Cos(temp[1] / 2f);
		float c3 = Mathf.Cos(temp[2] / 2f);
		float s1 = Mathf.Sin(temp[0] / 2f);
		float s2 = Mathf.Sin(temp[1] / 2f);
		float s3 = Mathf.Sin(temp[2] / 2f);

		switch (bvhRotationOrder)
		{
			case "XYZ":
				w = c1 * c2 * c3 - s1 * s2 * s3;
				x = s1 * c2 * c3 + c1 * s2 * s3;
				y = c1 * s2 * c3 - s1 * c2 * s3;
				z = c1 * c2 * s3 + s1 * s2 * c3;
				break;

			case "XZY":
				w = c1 * c2 * c3 + s1 * s2 * s3;
				x = s1 * c2 * c3 - c1 * s2 * s3;
				y = c1 * c2 * s3 - s1 * s2 * c3;
				z = c1 * s2 * c3 + s1 * c2 * s3;
				break;

			case "ZXY":
				w = c1 * c2 * c3 - s1 * s2 * s3;
				x = c1 * s2 * c3 - s1 * c2 * s3;
				y = c1 * c2 * s3 + s1 * s2 * c3;
				z = s1 * c2 * c3 + c1 * s2 * s3;
				break;

			case "ZYX":
				w = c1 * c2 * c3 + s1 * s2 * s3;
				x = c1 * c2 * s3 - s1 * s2 * c3;
				y = c1 * s2 * c3 + s1 * c2 * s3;
				z = s1 * c2 * c3 - c1 * s2 * s3;
				break;

			case "YZX":
				w = c1 * c2 * c3 - s1 * s2 * s3;
				x = c1 * c2 * s3 + s1 * s2 * c3;
				y = s1 * c2 * c3 + c1 * s2 * s3;
				z = c1 * s2 * c3 - s1 * c2 * s3;
				break;

			case "YXZ":
				w = c1 * c2 * c3 + s1 * s2 * s3;
				x = c1 * s2 * c3 + s1 * c2 * s3;
				y = s1 * c2 * c3 - c1 * s2 * s3;
				z = c1 * c2 * s3 - s1 * s2 * c3;
				break;
			default:
				break;
		}
		return new Quaternion(x, -y, -z, w);
	}
}
