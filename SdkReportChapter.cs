using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF7 RID: 3831
[NullableContext(1)]
[Nullable(0)]
public class SdkReportChapter : SdkReportData, IStaticVariableResetter
{
	// Token: 0x06005E9A RID: 24218 RVA: 0x0017A692 File Offset: 0x00178892
	public SdkReportChapter([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E9B RID: 24219 RVA: 0x0017A69B File Offset: 0x0017889B
	static SdkReportChapter()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SdkReportChapter.CreateStaticDefaultValue), new Action(SdkReportChapter.ResetStaticDefaultValue));
	}

	// Token: 0x170006F9 RID: 1785
	// (get) Token: 0x06005E9C RID: 24220 RVA: 0x0017A6BA File Offset: 0x001788BA
	private static IReadOnlyDictionary<int, string> GlobalReportMap
	{
		get
		{
			return SdkReportChapter._globalReportMap;
		}
	}

	// Token: 0x170006FA RID: 1786
	// (get) Token: 0x06005E9D RID: 24221 RVA: 0x0017A6C1 File Offset: 0x001788C1
	private static IReadOnlyDictionary<int, string> ChinaReportMap
	{
		get
		{
			return SdkReportChapter._chinaReportMap;
		}
	}

	// Token: 0x06005E9E RID: 24222 RVA: 0x0017A6C8 File Offset: 0x001788C8
	public static bool IfNeedReport(int treeId, int nodeId)
	{
		return treeId == 139000025 || treeId == 139000026 || treeId == 139000027 || treeId == 139000029 || treeId == 139000030 || treeId == 139000031 || treeId == 114000020 || treeId == 140000004;
	}

	// Token: 0x06005E9F RID: 24223 RVA: 0x0017A718 File Offset: 0x00178918
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return SdkReportChapter.GlobalReportMap.GetValueOrDefault(this.TreeConfigId, "");
		}
		return SdkReportChapter.ChinaReportMap.GetValueOrDefault(this.TreeConfigId, "");
	}

	// Token: 0x06005EA0 RID: 24224 RVA: 0x0017A750 File Offset: 0x00178950
	public static void CreateStaticDefaultValue()
	{
		SdkReportChapter._globalReportMap = new Dictionary<int, string>
		{
			{
				139000025,
				"Complete_pre_1"
			},
			{
				139000026,
				"Complete_pre_2"
			},
			{
				139000027,
				"Complete_C1_1"
			},
			{
				139000029,
				"Complete_C1_2"
			},
			{
				139000030,
				"Complete_C1_3"
			},
			{
				139000031,
				"Complete_C1_4"
			},
			{
				114000020,
				"Complete_C1_5"
			},
			{
				140000004,
				"Complete_C1_6"
			}
		};
		SdkReportChapter._chinaReportMap = new Dictionary<int, string>
		{
			{
				139000025,
				"event_12"
			},
			{
				139000026,
				"event_13"
			},
			{
				139000027,
				"event_14"
			},
			{
				139000029,
				"event_15"
			},
			{
				139000030,
				"event_16"
			},
			{
				139000031,
				"event_17"
			},
			{
				114000020,
				"event_18"
			},
			{
				140000004,
				"event_19"
			}
		};
	}

	// Token: 0x06005EA1 RID: 24225 RVA: 0x0017A871 File Offset: 0x00178A71
	public static void ResetStaticDefaultValue()
	{
		SdkReportChapter._globalReportMap = null;
		SdkReportChapter._chinaReportMap = null;
	}

	// Token: 0x04002DD5 RID: 11733
	public int TreeConfigId;

	// Token: 0x04002DD6 RID: 11734
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static IReadOnlyDictionary<int, string> _globalReportMap;

	// Token: 0x04002DD7 RID: 11735
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static IReadOnlyDictionary<int, string> _chinaReportMap;
}
