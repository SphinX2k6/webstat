using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Core.Common;
using CSharpScript.Game.Utils;
using UnrealEngine;

// Token: 0x02002E0E RID: 11790
[NullableContext(1)]
[Nullable(0)]
public class BulletTraceElementPool : IStaticVariableResetter
{
	// Token: 0x06017D46 RID: 97606 RVA: 0x006A564B File Offset: 0x006A384B
	static BulletTraceElementPool()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(BulletTraceElementPool.CreateStaticDefaultValue), new Action(BulletTraceElementPool.ResetStaticDefaultValue));
	}

	// Token: 0x17002057 RID: 8279
	// (get) Token: 0x06017D47 RID: 97607 RVA: 0x006A566A File Offset: 0x006A386A
	private static List<UTraceBoxElement> TraceBoxElementList
	{
		get
		{
			return BulletTraceElementPool._traceBoxElementList;
		}
	}

	// Token: 0x17002058 RID: 8280
	// (get) Token: 0x06017D48 RID: 97608 RVA: 0x006A5671 File Offset: 0x006A3871
	private static List<UTraceLineElement> TraceLineElementList
	{
		get
		{
			return BulletTraceElementPool._traceLineElementList;
		}
	}

	// Token: 0x17002059 RID: 8281
	// (get) Token: 0x06017D49 RID: 97609 RVA: 0x006A5678 File Offset: 0x006A3878
	private static List<UTraceSphereElement> TraceSphereElementList
	{
		get
		{
			return BulletTraceElementPool._traceSphereElementList;
		}
	}

	// Token: 0x06017D4A RID: 97610 RVA: 0x006A567F File Offset: 0x006A387F
	public static UTraceBoxElement GetTraceBoxElement([Nullable(new byte[]
	{
		1,
		0
	})] TArray<TEnumAsByte<EObjectTypeQuery>> traceObjectType, int attackerId, [Nullable(2)] HashSet<EObjectTypeQuery> ignoreObjectType = null)
	{
		return BulletTraceElementPool.GetTraceElement<UTraceBoxElement>(BulletTraceElementPool.TraceBoxElementList, traceObjectType, attackerId, ignoreObjectType);
	}

	// Token: 0x06017D4B RID: 97611 RVA: 0x006A568E File Offset: 0x006A388E
	public static UTraceLineElement GetTraceLineElement([Nullable(new byte[]
	{
		1,
		0
	})] TArray<TEnumAsByte<EObjectTypeQuery>> traceObjectType, int attackerId, [Nullable(2)] HashSet<EObjectTypeQuery> ignoreObjectType = null)
	{
		return BulletTraceElementPool.GetTraceElement<UTraceLineElement>(BulletTraceElementPool.TraceLineElementList, traceObjectType, attackerId, ignoreObjectType);
	}

	// Token: 0x06017D4C RID: 97612 RVA: 0x006A569D File Offset: 0x006A389D
	public static UTraceSphereElement GetTraceSphereElement([Nullable(new byte[]
	{
		1,
		0
	})] TArray<TEnumAsByte<EObjectTypeQuery>> traceObjectType, int attackerId, [Nullable(2)] HashSet<EObjectTypeQuery> ignoreObjectType = null)
	{
		return BulletTraceElementPool.GetTraceElement<UTraceSphereElement>(BulletTraceElementPool.TraceSphereElementList, traceObjectType, attackerId, ignoreObjectType);
	}

	// Token: 0x06017D4D RID: 97613 RVA: 0x006A56AC File Offset: 0x006A38AC
	private static T GetTraceElement<[Nullable(0)] T>(List<T> elementList, [Nullable(new byte[]
	{
		1,
		0
	})] TArray<TEnumAsByte<EObjectTypeQuery>> traceObjectType, int attackerId, [Nullable(2)] HashSet<EObjectTypeQuery> ignoreObjectType = null) where T : UTraceBaseElement, new()
	{
		if (elementList.Count > 0)
		{
			T t = elementList[elementList.Count - 1];
			elementList.RemoveAt(elementList.Count - 1);
			TArray<TEnumAsByte<EObjectTypeQuery>> tarray = new TArray<TEnumAsByte<EObjectTypeQuery>>();
			t.SetObjectTypesQuery(ref tarray);
			int i = 0;
			int num = traceObjectType.Num();
			while (i < num)
			{
				TEnumAsByte<EObjectTypeQuery> value = traceObjectType.Get(i);
				if (ignoreObjectType == null || !ignoreObjectType.Contains(value))
				{
					t.AddObjectTypeQuery(value);
				}
				i++;
			}
			if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
			{
				bool flag = ModelBase<BulletModel>.Instance.ShowBulletTrace(attackerId);
				t.SetDrawDebugTrace(flag ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
				if (flag)
				{
					Singleton<TraceElementCommon>.Instance.SetTraceColor(t, ColorUtils.LinearGreen);
					Singleton<TraceElementCommon>.Instance.SetTraceHitColor(t, ColorUtils.LinearRed);
				}
			}
			return t;
		}
		T t2 = BulletTraceElementPool.NewTraceElement<T>(traceObjectType, ignoreObjectType, false);
		if (Singleton<Info>.Instance.IsBuildDevelopmentOrDebug)
		{
			bool flag2 = ModelBase<BulletModel>.Instance.ShowBulletTrace(attackerId);
			t2.SetDrawDebugTrace(flag2 ? EDrawDebugTrace.ForDuration : EDrawDebugTrace.None);
			if (flag2)
			{
				Singleton<TraceElementCommon>.Instance.SetTraceColor(t2, ColorUtils.LinearGreen);
				Singleton<TraceElementCommon>.Instance.SetTraceHitColor(t2, ColorUtils.LinearRed);
			}
		}
		return t2;
	}

	// Token: 0x06017D4E RID: 97614 RVA: 0x006A57FD File Offset: 0x006A39FD
	[NullableContext(2)]
	public static void RecycleTraceBoxElement(UTraceBoxElement traceElement)
	{
		if (traceElement != null)
		{
			traceElement.ClearCacheData(false);
			BulletTraceElementPool.TraceBoxElementList.Add(traceElement);
		}
	}

	// Token: 0x06017D4F RID: 97615 RVA: 0x006A5814 File Offset: 0x006A3A14
	[NullableContext(2)]
	public static void RecycleTraceLineElement(UTraceLineElement traceElement)
	{
		if (traceElement != null)
		{
			traceElement.ClearCacheData(false);
			BulletTraceElementPool.TraceLineElementList.Add(traceElement);
		}
	}

	// Token: 0x06017D50 RID: 97616 RVA: 0x006A582B File Offset: 0x006A3A2B
	[NullableContext(2)]
	public static void RecycleTraceSphereElement(UTraceSphereElement traceElement)
	{
		if (traceElement != null)
		{
			traceElement.ClearCacheData(false);
			BulletTraceElementPool.TraceSphereElementList.Add(traceElement);
		}
	}

	// Token: 0x06017D51 RID: 97617 RVA: 0x006A5844 File Offset: 0x006A3A44
	private static T NewTraceElement<[Nullable(0)] T>([Nullable(new byte[]
	{
		1,
		0
	})] TArray<TEnumAsByte<EObjectTypeQuery>> traceObjectType, [Nullable(2)] HashSet<EObjectTypeQuery> ignoreObjectType = null, bool bIsSingle = false) where T : UTraceBaseElement, new()
	{
		T t = Activator.CreateInstance<T>();
		t.WorldContextObject = GlobalData.World;
		int i = 0;
		int num = traceObjectType.Num();
		while (i < num)
		{
			TEnumAsByte<EObjectTypeQuery> value = traceObjectType.Get(i);
			if (ignoreObjectType == null || !ignoreObjectType.Contains(value))
			{
				t.AddObjectTypeQuery(value);
			}
			i++;
		}
		t.bTraceComplex = false;
		t.bIgnoreSelf = true;
		t.bIsSingle = bIsSingle;
		return t;
	}

	// Token: 0x06017D52 RID: 97618 RVA: 0x006A58D0 File Offset: 0x006A3AD0
	public static T NewTraceElementByTraceChannel<[Nullable(0)] T>(ETraceTypeQuery traceChannel, bool bIsSingle = false) where T : UTraceBaseElement, new()
	{
		T t = Activator.CreateInstance<T>();
		t.WorldContextObject = GlobalData.World;
		t.SetTraceTypeQuery(traceChannel);
		t.bTraceComplex = false;
		t.bIgnoreSelf = true;
		t.bIsSingle = bIsSingle;
		return t;
	}

	// Token: 0x06017D53 RID: 97619 RVA: 0x006A5922 File Offset: 0x006A3B22
	public static void Clear()
	{
		BulletTraceElementPool.TraceBoxElementList.Clear();
		BulletTraceElementPool.TraceLineElementList.Clear();
		BulletTraceElementPool.TraceSphereElementList.Clear();
	}

	// Token: 0x06017D54 RID: 97620 RVA: 0x006A5942 File Offset: 0x006A3B42
	public static void CreateStaticDefaultValue()
	{
		BulletTraceElementPool._traceBoxElementList = new List<UTraceBoxElement>();
		BulletTraceElementPool._traceLineElementList = new List<UTraceLineElement>();
		BulletTraceElementPool._traceSphereElementList = new List<UTraceSphereElement>();
	}

	// Token: 0x06017D55 RID: 97621 RVA: 0x006A5962 File Offset: 0x006A3B62
	public static void ResetStaticDefaultValue()
	{
		BulletTraceElementPool._traceBoxElementList = null;
		BulletTraceElementPool._traceLineElementList = null;
		BulletTraceElementPool._traceSphereElementList = null;
	}

	// Token: 0x0400B8EF RID: 47343
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<UTraceBoxElement> _traceBoxElementList;

	// Token: 0x0400B8F0 RID: 47344
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<UTraceLineElement> _traceLineElementList;

	// Token: 0x0400B8F1 RID: 47345
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<UTraceSphereElement> _traceSphereElementList;
}
