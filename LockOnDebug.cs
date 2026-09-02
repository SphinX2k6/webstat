using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020030BB RID: 12475
[NullableContext(1)]
[Nullable(0)]
public class LockOnDebug : IStaticVariableResetter
{
	// Token: 0x06019B5A RID: 105306 RVA: 0x0077B507 File Offset: 0x00779707
	static LockOnDebug()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(LockOnDebug.CreateStaticDefaultValue), new Action(LockOnDebug.ResetStaticDefaultValue));
	}

	// Token: 0x1700229F RID: 8863
	// (get) Token: 0x06019B5B RID: 105307 RVA: 0x0077B526 File Offset: 0x00779726
	private static Dictionary<LockOnInfo, LockOnDebugData> LockOnDataMap
	{
		get
		{
			return LockOnDebug._lockOnDataMap;
		}
	}

	// Token: 0x06019B5C RID: 105308 RVA: 0x0077B52D File Offset: 0x0077972D
	public static void Clear()
	{
		LockOnDebug.LockOnDataMap.Clear();
	}

	// Token: 0x06019B5D RID: 105309 RVA: 0x0077B53C File Offset: 0x0077973C
	public static void Push(LockOnInfo info)
	{
		if (!LockOnDebug.IsShowDebugLine)
		{
			return;
		}
		LockOnDebugData value = new LockOnDebugData(info);
		LockOnDebug.LockOnDataMap[info] = value;
	}

	// Token: 0x06019B5E RID: 105310 RVA: 0x0077B564 File Offset: 0x00779764
	public static void SetDebugString(LockOnInfo info, float angle, float distance, Vector moveDir, [Nullable(2)] Vector actualDir)
	{
		if (!LockOnDebug.IsShowDebugLine)
		{
			return;
		}
		LockOnDebugData lockOnDebugData;
		if (LockOnDebug.LockOnDataMap.TryGetValue(info, out lockOnDebugData))
		{
			lockOnDebugData.ShowTip = string.Concat(new string[]
			{
				"角度：",
				LockOnDebug.FormatNumber((double)angle),
				"\n距离：",
				LockOnDebug.FormatNumber((double)distance),
				"\n移动方向：",
				LockOnDebug.FormatVector(moveDir)
			});
			if (actualDir != null)
			{
				LockOnDebugData lockOnDebugData2 = lockOnDebugData;
				lockOnDebugData2.ShowTip = lockOnDebugData2.ShowTip + "\n实际方向：" + LockOnDebug.FormatVector(actualDir);
			}
		}
	}

	// Token: 0x06019B5F RID: 105311 RVA: 0x0077B5F0 File Offset: 0x007797F0
	public static void SetDebugArrow(LockOnInfo info, EColorType colorType)
	{
		if (!LockOnDebug.IsShowDebugLine)
		{
			return;
		}
		LockOnDebugData lockOnDebugData;
		if (LockOnDebug.LockOnDataMap.TryGetValue(info, out lockOnDebugData))
		{
			lockOnDebugData.ColorType = colorType;
		}
	}

	// Token: 0x06019B60 RID: 105312 RVA: 0x0077B61B File Offset: 0x0077981B
	private static string FormatNumber(double value)
	{
		return value.ToString("F2");
	}

	// Token: 0x06019B61 RID: 105313 RVA: 0x0077B62C File Offset: 0x0077982C
	private static string FormatVector(Vector vec)
	{
		return string.Concat(new string[]
		{
			"X=",
			LockOnDebug.FormatNumber(vec.X),
			", Y=",
			LockOnDebug.FormatNumber(vec.Y),
			", Z=",
			LockOnDebug.FormatNumber(vec.Z)
		});
	}

	// Token: 0x06019B62 RID: 105314 RVA: 0x0077B688 File Offset: 0x00779888
	public static void Tick(Entity me)
	{
		if (!LockOnDebug.IsShowDebugLine)
		{
			return;
		}
		List<LockOnInfo> list = new List<LockOnInfo>();
		foreach (KeyValuePair<LockOnInfo, LockOnDebugData> keyValuePair in LockOnDebug.LockOnDataMap)
		{
			LockOnInfo lockOnInfo;
			LockOnDebugData lockOnDebugData;
			keyValuePair.Deconstruct(out lockOnInfo, out lockOnDebugData);
			LockOnInfo lockOnInfo2 = lockOnInfo;
			LockOnDebugData lockOnDebugData2 = lockOnDebugData;
			EntityHandle entityHandle = lockOnInfo2.EntityHandle;
			if (entityHandle == null || !entityHandle.Valid)
			{
				list.Add(lockOnInfo2);
			}
			else
			{
				lockOnDebugData2.DrawDebug(me);
			}
		}
		foreach (LockOnInfo key in list)
		{
			LockOnDebug.LockOnDataMap.Remove(key);
		}
	}

	// Token: 0x06019B63 RID: 105315 RVA: 0x0077B760 File Offset: 0x00779960
	public static void CreateStaticDefaultValue()
	{
		LockOnDebug.IsShowDebugLine = false;
		LockOnDebug._lockOnDataMap = new Dictionary<LockOnInfo, LockOnDebugData>();
	}

	// Token: 0x06019B64 RID: 105316 RVA: 0x0077B772 File Offset: 0x00779972
	public static void ResetStaticDefaultValue()
	{
		LockOnDebug.IsShowDebugLine = false;
		LockOnDebug._lockOnDataMap = null;
	}

	// Token: 0x0400CCCD RID: 52429
	public const float ARROW_SIZE = 15f;

	// Token: 0x0400CCCE RID: 52430
	public const double DEBUG_TEXT_FALLBACK_Z_OFFSET = 120.0;

	// Token: 0x0400CCCF RID: 52431
	public const double DEBUG_TEXT_EXTRA_Z_OFFSET = 50.0;

	// Token: 0x0400CCD0 RID: 52432
	public static bool IsShowDebugLine;

	// Token: 0x0400CCD1 RID: 52433
	[Nullable(new byte[]
	{
		2,
		1,
		1
	})]
	private static Dictionary<LockOnInfo, LockOnDebugData> _lockOnDataMap;
}
