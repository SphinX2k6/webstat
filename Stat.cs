using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Aki.Common.Proxy;

// Token: 0x02000053 RID: 83
[NullableContext(1)]
[Nullable(0)]
public class Stat : IStat
{
	// Token: 0x17000018 RID: 24
	// (get) Token: 0x06000180 RID: 384 RVA: 0x00009EDA File Offset: 0x000080DA
	public static bool Enable
	{
		get
		{
			return false;
		}
	}

	// Token: 0x06000181 RID: 385 RVA: 0x00009EDD File Offset: 0x000080DD
	public static global::Stat Create(string name, string desc = "", string group = "")
	{
		return global::Stat.EmptyStat;
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00009EE4 File Offset: 0x000080E4
	public static global::Stat CreateNoFlameGraph(string name, string desc = "", string group = "")
	{
		return global::Stat.EmptyStat;
	}

	// Token: 0x06000183 RID: 387 RVA: 0x00009EEB File Offset: 0x000080EB
	[Conditional("STATS")]
	public static void CreateInstantStat(string name, string desc = "", string group = "")
	{
	}

	// Token: 0x06000184 RID: 388 RVA: 0x00009EED File Offset: 0x000080ED
	public static global::Stat CreateWithStack(string namePrefix, int skipStackIndex = 0, int maxStackCount = 5)
	{
		return global::Stat.EmptyStat;
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00009EF4 File Offset: 0x000080F4
	[Conditional("STATS")]
	public static void Create(string name, [Nullable(2)] [NotNull] ref global::Stat stat, string desc = "", string group = "")
	{
		stat = global::Stat.EmptyStat;
	}

	// Token: 0x06000186 RID: 390 RVA: 0x00009EFD File Offset: 0x000080FD
	[Conditional("STATS")]
	public static void CreateNoFlameGraph(string name, [Nullable(2)] [NotNull] ref global::Stat stat, string desc = "", string group = "")
	{
		stat = global::Stat.EmptyStat;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00009F06 File Offset: 0x00008106
	[Conditional("STATS")]
	public static void CreateWithStack(string namePrefix, [Nullable(2)] [NotNull] ref global::Stat stat, int skipStackIndex = 0, int maxStackCount = 5)
	{
		stat = global::Stat.EmptyStat;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x00009F0F File Offset: 0x0000810F
	public static string GetStack(string namePrefix, int firstStackIndex = 0, int stackNumberNeeded = 5)
	{
		return string.Empty;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00009F16 File Offset: 0x00008116
	[Conditional("STATS")]
	public void Start()
	{
	}

	// Token: 0x0600018A RID: 394 RVA: 0x00009F18 File Offset: 0x00008118
	[Conditional("STATS")]
	public void Stop()
	{
	}

	// Token: 0x0600018B RID: 395 RVA: 0x00009F1A File Offset: 0x0000811A
	void IStat.Start()
	{
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00009F1C File Offset: 0x0000811C
	void IStat.Stop()
	{
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00009F1E File Offset: 0x0000811E
	public static void CreateStaticDefaultValue()
	{
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00009F20 File Offset: 0x00008120
	public static void ResetStaticDefaultValue()
	{
	}

	// Token: 0x04000176 RID: 374
	[StaticVariableRuleIgnore]
	public static bool EnableCreateWithStack;

	// Token: 0x04000177 RID: 375
	[StaticVariableRuleIgnore]
	private static readonly global::Stat EmptyStat = new global::Stat();
}
