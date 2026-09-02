using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;
using UnrealEngine.Extension;

// Token: 0x0200294F RID: 10575
[NullableContext(1)]
[Nullable(0)]
public class SceneBattleInteractPool : IStaticVariableResetter
{
	// Token: 0x0601502E RID: 86062 RVA: 0x005CFA62 File Offset: 0x005CDC62
	static SceneBattleInteractPool()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SceneBattleInteractPool.CreateStaticDefaultValue), new Action(SceneBattleInteractPool.ResetStaticDefaultValue));
	}

	// Token: 0x0601502F RID: 86063 RVA: 0x005CFA81 File Offset: 0x005CDC81
	public static void CreateStaticDefaultValue()
	{
		SceneBattleInteractPool.TraceCapsuleElementList = new List<UTraceCapsuleElement>();
		SceneBattleInteractPool.TraceLineElementList = new List<UTraceLineElement>();
		SceneBattleInteractPool.TraceSphereElementList = new List<UTraceSphereElement>();
	}

	// Token: 0x06015030 RID: 86064 RVA: 0x005CFAA1 File Offset: 0x005CDCA1
	public static void ResetStaticDefaultValue()
	{
		SceneBattleInteractPool.TraceCapsuleElementList = null;
		SceneBattleInteractPool.TraceLineElementList = null;
		SceneBattleInteractPool.TraceSphereElementList = null;
	}

	// Token: 0x06015031 RID: 86065 RVA: 0x005CFAB5 File Offset: 0x005CDCB5
	public static UTraceCapsuleElement GetTraceCapsuleElement(ETraceTypeQuery traceChannel)
	{
		return SceneBattleInteractPool.GetTraceElement<UTraceCapsuleElement>(UTraceCapsuleElement.StaticClass().ToClass(), SceneBattleInteractPool.TraceCapsuleElementList, traceChannel, false);
	}

	// Token: 0x06015032 RID: 86066 RVA: 0x005CFACD File Offset: 0x005CDCCD
	public static UTraceLineElement GetTraceLineElement(ETraceTypeQuery traceChannel)
	{
		return SceneBattleInteractPool.GetTraceElement<UTraceLineElement>(UTraceLineElement.StaticClass().ToClass(), SceneBattleInteractPool.TraceLineElementList, traceChannel, false);
	}

	// Token: 0x06015033 RID: 86067 RVA: 0x005CFAE5 File Offset: 0x005CDCE5
	public static UTraceSphereElement GetTraceSphereElement(ETraceTypeQuery traceChannel)
	{
		return SceneBattleInteractPool.GetTraceElement<UTraceSphereElement>(UTraceSphereElement.StaticClass().ToClass(), SceneBattleInteractPool.TraceSphereElementList, traceChannel, false);
	}

	// Token: 0x06015034 RID: 86068 RVA: 0x005CFB00 File Offset: 0x005CDD00
	private static T GetTraceElement<[Nullable(0)] T>(UClass type, List<T> elementList, ETraceTypeQuery traceChannel, bool bIsSingle = false) where T : UTraceBaseElement
	{
		if (elementList.Count > 0)
		{
			int index = elementList.Count - 1;
			T t = elementList[index];
			elementList.RemoveAt(index);
			t.SetTraceTypeQuery(traceChannel);
			t.bIsSingle = bIsSingle;
			return t;
		}
		T t2 = UE.NewObject<T>(type, null, EObjectFlags.RF_NoFlags);
		t2.WorldContextObject = GlobalData.World;
		t2.SetTraceTypeQuery(traceChannel);
		t2.bTraceComplex = false;
		t2.bIgnoreSelf = true;
		t2.bIsSingle = bIsSingle;
		return t2;
	}

	// Token: 0x06015035 RID: 86069 RVA: 0x005CFB8E File Offset: 0x005CDD8E
	[NullableContext(2)]
	public static void RecycleTraceCapsuleElement(UTraceCapsuleElement traceElement)
	{
		if (traceElement != null)
		{
			traceElement.ClearCacheData(false);
			SceneBattleInteractPool.TraceCapsuleElementList.Add(traceElement);
		}
	}

	// Token: 0x06015036 RID: 86070 RVA: 0x005CFBA5 File Offset: 0x005CDDA5
	[NullableContext(2)]
	public static void RecycleTraceLineElement(UTraceLineElement traceElement)
	{
		if (traceElement != null)
		{
			traceElement.ClearCacheData(false);
			SceneBattleInteractPool.TraceLineElementList.Add(traceElement);
		}
	}

	// Token: 0x06015037 RID: 86071 RVA: 0x005CFBBC File Offset: 0x005CDDBC
	[NullableContext(2)]
	public static void RecycleTraceSphereElement(UTraceSphereElement traceElement)
	{
		if (traceElement != null)
		{
			traceElement.ClearCacheData(false);
			SceneBattleInteractPool.TraceSphereElementList.Add(traceElement);
		}
	}

	// Token: 0x06015038 RID: 86072 RVA: 0x005CFBD3 File Offset: 0x005CDDD3
	public static void Clear()
	{
		List<UTraceCapsuleElement> traceCapsuleElementList = SceneBattleInteractPool.TraceCapsuleElementList;
		if (traceCapsuleElementList != null)
		{
			traceCapsuleElementList.Clear();
		}
		List<UTraceLineElement> traceLineElementList = SceneBattleInteractPool.TraceLineElementList;
		if (traceLineElementList != null)
		{
			traceLineElementList.Clear();
		}
		List<UTraceSphereElement> traceSphereElementList = SceneBattleInteractPool.TraceSphereElementList;
		if (traceSphereElementList == null)
		{
			return;
		}
		traceSphereElementList.Clear();
	}

	// Token: 0x0400A1D0 RID: 41424
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<UTraceCapsuleElement> TraceCapsuleElementList;

	// Token: 0x0400A1D1 RID: 41425
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<UTraceLineElement> TraceLineElementList;

	// Token: 0x0400A1D2 RID: 41426
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static List<UTraceSphereElement> TraceSphereElementList;
}
