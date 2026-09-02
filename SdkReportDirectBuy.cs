using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF6 RID: 3830
[NullableContext(1)]
[Nullable(0)]
public class SdkReportDirectBuy : SdkReportData, IStaticVariableResetter
{
	// Token: 0x06005E93 RID: 24211 RVA: 0x0017A5DD File Offset: 0x001787DD
	public SdkReportDirectBuy([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E94 RID: 24212 RVA: 0x0017A5E6 File Offset: 0x001787E6
	static SdkReportDirectBuy()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SdkReportDirectBuy.CreateStaticDefaultValue), new Action(SdkReportDirectBuy.ResetStaticDefaultValue));
	}

	// Token: 0x170006F8 RID: 1784
	// (get) Token: 0x06005E95 RID: 24213 RVA: 0x0017A605 File Offset: 0x00178805
	private static IReadOnlyDictionary<int, string> GlobalReportMap
	{
		get
		{
			return SdkReportDirectBuy._globalReportMap;
		}
	}

	// Token: 0x06005E96 RID: 24214 RVA: 0x0017A60C File Offset: 0x0017880C
	public static bool IfNeedReport(int payId)
	{
		return payId == 42 || payId == 43 || payId == 44 || payId == 45;
	}

	// Token: 0x06005E97 RID: 24215 RVA: 0x0017A625 File Offset: 0x00178825
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return SdkReportDirectBuy.GlobalReportMap.GetValueOrDefault(this.PayItemId, "");
		}
		return "";
	}

	// Token: 0x06005E98 RID: 24216 RVA: 0x0017A64A File Offset: 0x0017884A
	public static void CreateStaticDefaultValue()
	{
		SdkReportDirectBuy._globalReportMap = new Dictionary<int, string>
		{
			{
				42,
				"Monthly_card"
			},
			{
				43,
				"BattlePass_Primary"
			},
			{
				44,
				"BattlePass_HIGH"
			},
			{
				45,
				"BattlePass_Primary_To_HIGH"
			}
		};
	}

	// Token: 0x06005E99 RID: 24217 RVA: 0x0017A68A File Offset: 0x0017888A
	public static void ResetStaticDefaultValue()
	{
		SdkReportDirectBuy._globalReportMap = null;
	}

	// Token: 0x04002DD3 RID: 11731
	public int PayItemId;

	// Token: 0x04002DD4 RID: 11732
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static IReadOnlyDictionary<int, string> _globalReportMap;
}
