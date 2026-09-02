using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Launcher.HotPatchKuroSdk;

// Token: 0x02000EF1 RID: 3825
[NullableContext(1)]
[Nullable(0)]
public class SdkReportBattleTech : SdkReportData, IStaticVariableResetter
{
	// Token: 0x06005E75 RID: 24181 RVA: 0x0017A1C0 File Offset: 0x001783C0
	public SdkReportBattleTech([Nullable(new byte[]
	{
		2,
		1,
		1
	})] Dictionary<string, string> eventData) : base(eventData)
	{
	}

	// Token: 0x06005E76 RID: 24182 RVA: 0x0017A1C9 File Offset: 0x001783C9
	static SdkReportBattleTech()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(SdkReportBattleTech.CreateStaticDefaultValue), new Action(SdkReportBattleTech.ResetStaticDefaultValue));
	}

	// Token: 0x170006F4 RID: 1780
	// (get) Token: 0x06005E77 RID: 24183 RVA: 0x0017A1E8 File Offset: 0x001783E8
	private static IReadOnlyDictionary<int, string> GlobalReportMap
	{
		get
		{
			return SdkReportBattleTech._globalReportMap;
		}
	}

	// Token: 0x06005E78 RID: 24184 RVA: 0x0017A1EF File Offset: 0x001783EF
	public static bool IfNeedReport(int treeId, int nodeId)
	{
		return (treeId == 139000025 && (nodeId == 6 || nodeId == 10 || nodeId == 91)) || (treeId == 139000026 && 132 == nodeId) || (treeId == 139000026 && 16 == nodeId);
	}

	// Token: 0x06005E79 RID: 24185 RVA: 0x0017A227 File Offset: 0x00178427
	public override string GetEventName()
	{
		if (this.IfGlobalSdk)
		{
			return SdkReportBattleTech.GlobalReportMap.GetValueOrDefault(this.NodeId, "");
		}
		return "";
	}

	// Token: 0x06005E7A RID: 24186 RVA: 0x0017A24C File Offset: 0x0017844C
	protected override string GetEventDataJson()
	{
		this.EventData = new Dictionary<string, string>();
		this.EventData["eventId"] = "101803";
		this.EventData["TreeId"] = this.TreeConfigId.ToString();
		this.EventData["StepId"] = this.NodeId.ToString();
		return base.GetEventDataJson();
	}

	// Token: 0x06005E7B RID: 24187 RVA: 0x0017A2B8 File Offset: 0x001784B8
	public static void CreateStaticDefaultValue()
	{
		SdkReportBattleTech._globalReportMap = new Dictionary<int, string>
		{
			{
				6,
				"Beginner_level_Battle_Teach_Finish"
			},
			{
				10,
				"Intermediater_level_Battle_Teach_Finish"
			},
			{
				91,
				"Advanced_level_Battle_Teach_Finish"
			},
			{
				132,
				"capture_Teach_Finish"
			},
			{
				16,
				"Prologue_Task_Finish"
			}
		};
	}

	// Token: 0x06005E7C RID: 24188 RVA: 0x0017A312 File Offset: 0x00178512
	public static void ResetStaticDefaultValue()
	{
		SdkReportBattleTech._globalReportMap = null;
	}

	// Token: 0x04002DCA RID: 11722
	public int TreeConfigId;

	// Token: 0x04002DCB RID: 11723
	public int NodeId;

	// Token: 0x04002DCC RID: 11724
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private static IReadOnlyDictionary<int, string> _globalReportMap;
}
