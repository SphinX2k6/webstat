using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002133 RID: 8499
[NullableContext(1)]
[Nullable(0)]
public class ExploreToolAssemblyLogData : AssemblyLogData
{
	// Token: 0x1700138D RID: 5005
	// (get) Token: 0x06010397 RID: 66455 RVA: 0x00475712 File Offset: 0x00473912
	// (set) Token: 0x06010398 RID: 66456 RVA: 0x0047571A File Offset: 0x0047391A
	public override string AssemblyId { get; set; } = "";

	// Token: 0x1700138E RID: 5006
	// (get) Token: 0x06010399 RID: 66457 RVA: 0x00475723 File Offset: 0x00473923
	// (set) Token: 0x0601039A RID: 66458 RVA: 0x0047572B File Offset: 0x0047392B
	public override CommonLogData AssemblyLogInfo { get; set; } = new ExploreToolUseLogData();

	// Token: 0x0601039B RID: 66459 RVA: 0x00475734 File Offset: 0x00473934
	public override void SetLogDataToAssembly(IUnitLogData unitLogData)
	{
		((ExploreToolUseLogData)this.AssemblyLogInfo).o_report.Add(unitLogData);
	}

	// Token: 0x0601039C RID: 66460 RVA: 0x0047574C File Offset: 0x0047394C
	public override bool CheckIsSend()
	{
		return ((ExploreToolUseLogData)this.AssemblyLogInfo).o_report.Count != 0;
	}

	// Token: 0x0601039D RID: 66461 RVA: 0x00475766 File Offset: 0x00473966
	public override void AfterSend()
	{
		((ExploreToolUseLogData)this.AssemblyLogInfo).o_report.Clear();
	}

	// Token: 0x0601039E RID: 66462 RVA: 0x00475780 File Offset: 0x00473980
	public ExploreToolAssemblyLogData(string tool_id)
	{
		this.SendTimePeriod = ConfigCommonParamById.GetIntConfig("LogReportPeriod_ExploreTool").Value * Singleton<TimeUtil>.Instance.InverseMillisecond;
		((ExploreToolUseLogData)this.AssemblyLogInfo).i_tool_id = tool_id;
		this.AssemblyId = "1026_" + tool_id;
	}
}
