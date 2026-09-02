using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF8 RID: 3832
[NullableContext(1)]
[Nullable(0)]
public class SdkReportLevel : SdkReportData, IStaticVariableResetter
{
	// Token: 0x06005EA2 RID: 24226 RVA: 0x0017A87F File Offset: 0x00178A7F
	public SdkReportLevel([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005EA3 RID: 24227 RVA: 0x0017A888 File Offset: 0x00178A88
	static SdkReportLevel()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SdkReportLevel.CreateStaticDefaultValue), new Action(SdkReportLevel.ResetStaticDefaultValue));
	}

	// Token: 0x170006FB RID: 1787
	// (get) Token: 0x06005EA4 RID: 24228 RVA: 0x0017A8A7 File Offset: 0x00178AA7
	private static IReadOnlyList<int> NeedReportLevel
	{
		get
		{
			return SdkReportLevel._needReportLevel;
		}
	}

	// Token: 0x170006FC RID: 1788
	// (get) Token: 0x06005EA5 RID: 24229 RVA: 0x0017A8AE File Offset: 0x00178AAE
	private static IReadOnlyDictionary<int, string> ChinaReportMap
	{
		get
		{
			return SdkReportLevel._chinaReportMap;
		}
	}

	// Token: 0x06005EA6 RID: 24230 RVA: 0x0017A8B5 File Offset: 0x00178AB5
	public static bool IfNeedReport(int level)
	{
		return SdkReportLevel.NeedReportLevel.Contains(level);
	}

	// Token: 0x06005EA7 RID: 24231 RVA: 0x0017A8C2 File Offset: 0x00178AC2
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return StringUtils.Format("Level_{0}", new string[]
			{
				this.Level.ToString()
			});
		}
		return SdkReportLevel.ChinaReportMap.GetValueOrDefault(this.Level, "");
	}

	// Token: 0x06005EA8 RID: 24232 RVA: 0x0017A900 File Offset: 0x00178B00
	public static void CreateStaticDefaultValue()
	{
		SdkReportLevel._needReportLevel = new <>z__ReadOnlyArray<int>(new int[]
		{
			8,
			10,
			12,
			15,
			20,
			25,
			30,
			35,
			40,
			45
		});
		SdkReportLevel._chinaReportMap = new Dictionary<int, string>
		{
			{
				8,
				"event_20"
			},
			{
				10,
				"event_21"
			},
			{
				12,
				"event_22"
			},
			{
				15,
				"event_23"
			},
			{
				20,
				"event_24"
			},
			{
				25,
				"event_25"
			},
			{
				30,
				"event_26"
			},
			{
				35,
				"event_27"
			},
			{
				40,
				"event_28"
			},
			{
				45,
				"event_29"
			}
		};
	}

	// Token: 0x06005EA9 RID: 24233 RVA: 0x0017A9B4 File Offset: 0x00178BB4
	public static void ResetStaticDefaultValue()
	{
		SdkReportLevel._needReportLevel = null;
		SdkReportLevel._chinaReportMap = null;
	}

	// Token: 0x04002DD8 RID: 11736
	public int Level;

	// Token: 0x04002DD9 RID: 11737
	[Nullable(2)]
	private static IReadOnlyList<int> _needReportLevel;

	// Token: 0x04002DDA RID: 11738
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static IReadOnlyDictionary<int, string> _chinaReportMap;
}
