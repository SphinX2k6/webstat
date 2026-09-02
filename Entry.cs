using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02000016 RID: 22
public class Entry : IStaticVariableResetter
{
	// Token: 0x06000029 RID: 41 RVA: 0x000021BD File Offset: 0x000003BD
	static Entry()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(Entry.CreateStaticDefaultValue), new Action(Entry.ResetStaticDefaultValue));
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000021DC File Offset: 0x000003DC
	public Entry([Nullable(new byte[]
	{
		0,
		1
	})] TWeakObjectPtr<UClass> kclass, int budget)
	{
		this.Class = kclass;
		this.Budget = budget;
	}

	// Token: 0x0600002B RID: 43 RVA: 0x00002200 File Offset: 0x00000400
	public void Touch(double? cost = null)
	{
		this.Count++;
		if (cost != null)
		{
			this.Cost = this.Cost * 0.5 + cost.Value * 0.5;
		}
		Entry.Increment += 1L;
		this.Score = (double)((long)this.Count + Entry.Increment) + this.Cost * 10.0 - (double)(this.Values.Count * 5);
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002290 File Offset: 0x00000490
	[NullableContext(1)]
	public static int Compare(Entry a, Entry b)
	{
		int count = a.Values.Count;
		int count2 = b.Values.Count;
		bool flag = a.Budget == 0 || count <= a.Budget;
		bool flag2 = b.Budget == 0 || count2 <= b.Budget;
		if (flag == flag2)
		{
			return a.Score.CompareTo(b.Score);
		}
		if (!flag)
		{
			return -1;
		}
		return 1;
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002301 File Offset: 0x00000501
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002303 File Offset: 0x00000503
	public static void ResetStaticDefaultValue()
	{
		Entry.Increment = 0L;
	}

	// Token: 0x04000007 RID: 7
	private static long Increment;

	// Token: 0x04000008 RID: 8
	private int Count;

	// Token: 0x04000009 RID: 9
	private double Cost;

	// Token: 0x0400000A RID: 10
	public double Score;

	// Token: 0x0400000B RID: 11
	[Nullable(1)]
	public readonly Dictionary<AActor, int> Values = new Dictionary<AActor, int>();

	// Token: 0x0400000C RID: 12
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public readonly TWeakObjectPtr<UClass> Class;

	// Token: 0x0400000D RID: 13
	public int Budget;
}
