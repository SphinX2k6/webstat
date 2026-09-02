using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF4 RID: 3828
[NullableContext(1)]
[Nullable(0)]
public class SdkReportRecharge : SdkReportData, IStaticVariableResetter
{
	// Token: 0x06005E89 RID: 24201 RVA: 0x0017A486 File Offset: 0x00178686
	public SdkReportRecharge([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E8A RID: 24202 RVA: 0x0017A48F File Offset: 0x0017868F
	static SdkReportRecharge()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SdkReportRecharge.CreateStaticDefaultValue), new Action(SdkReportRecharge.ResetStaticDefaultValue));
	}

	// Token: 0x170006F6 RID: 1782
	// (get) Token: 0x06005E8B RID: 24203 RVA: 0x0017A4AE File Offset: 0x001786AE
	private static IReadOnlyDictionary<int, string> GlobalReportMap
	{
		get
		{
			return SdkReportRecharge._globalReportMap;
		}
	}

	// Token: 0x170006F7 RID: 1783
	// (get) Token: 0x06005E8C RID: 24204 RVA: 0x0017A4B5 File Offset: 0x001786B5
	private static IReadOnlyDictionary<int, string> ChinaReportMap
	{
		get
		{
			return SdkReportRecharge._chinaReportMap;
		}
	}

	// Token: 0x06005E8D RID: 24205 RVA: 0x0017A4BC File Offset: 0x001786BC
	public static bool IfNeedReport(int payId)
	{
		return payId >= 1 && payId <= 6;
	}

	// Token: 0x06005E8E RID: 24206 RVA: 0x0017A4C9 File Offset: 0x001786C9
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return SdkReportRecharge.GlobalReportMap.GetValueOrDefault(this.PayItemId, "");
		}
		return SdkReportRecharge.ChinaReportMap.GetValueOrDefault(this.PayItemId, "");
	}

	// Token: 0x06005E8F RID: 24207 RVA: 0x0017A500 File Offset: 0x00178700
	public static void CreateStaticDefaultValue()
	{
		SdkReportRecharge._globalReportMap = new Dictionary<int, string>
		{
			{
				1,
				"Purchase_099"
			},
			{
				2,
				"Purchase_499"
			},
			{
				3,
				"Purchase_1499"
			},
			{
				4,
				"Purchase_2999"
			},
			{
				5,
				"Purchase_4999"
			},
			{
				6,
				"Purchase_9999"
			}
		};
		SdkReportRecharge._chinaReportMap = new Dictionary<int, string>
		{
			{
				1,
				"event_5"
			},
			{
				2,
				"event_6"
			},
			{
				3,
				"event_7"
			},
			{
				4,
				"event_8"
			},
			{
				5,
				"event_9"
			},
			{
				6,
				"event_10"
			}
		};
	}

	// Token: 0x06005E90 RID: 24208 RVA: 0x0017A5B1 File Offset: 0x001787B1
	public static void ResetStaticDefaultValue()
	{
		SdkReportRecharge._globalReportMap = null;
		SdkReportRecharge._chinaReportMap = null;
	}

	// Token: 0x04002DD0 RID: 11728
	public int PayItemId;

	// Token: 0x04002DD1 RID: 11729
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static IReadOnlyDictionary<int, string> _globalReportMap;

	// Token: 0x04002DD2 RID: 11730
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static IReadOnlyDictionary<int, string> _chinaReportMap;
}
