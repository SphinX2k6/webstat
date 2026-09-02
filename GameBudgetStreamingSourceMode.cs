using System;
using UnrealEngine;

// Token: 0x02001D14 RID: 7444
public class GameBudgetStreamingSourceMode : GameBudgetMode
{
	// Token: 0x0600DA98 RID: 55960 RVA: 0x003ABC6C File Offset: 0x003A9E6C
	public GameBudgetStreamingSourceMode() : base("EGameBudgetMode.StreamingSource", EGameBudgetMode.StreamingSource)
	{
	}

	// Token: 0x0600DA99 RID: 55961 RVA: 0x003ABC7A File Offset: 0x003A9E7A
	public override void OnEnterMode()
	{
		UKuroGameBudgetAllocatorCSharpInterface.SetDisableAssistantCenterActor(true);
		Singleton<GameBudgetInterfaceController>.Instance.SetCenterRole(ModelBase<GameModeModel>.Instance.StreamingSource);
	}

	// Token: 0x0600DA9A RID: 55962 RVA: 0x003ABC96 File Offset: 0x003A9E96
	public override void OnExitMode()
	{
		UKuroGameBudgetAllocatorCSharpInterface.SetDisableAssistantCenterActor(false);
	}

	// Token: 0x0600DA9B RID: 55963 RVA: 0x003ABC9E File Offset: 0x003A9E9E
	public override bool AllowSwitchMode()
	{
		return false;
	}

	// Token: 0x0600DA9C RID: 55964 RVA: 0x003ABCA1 File Offset: 0x003A9EA1
	public override bool AllowSetCenterActor()
	{
		return false;
	}

	// Token: 0x0600DA9D RID: 55965 RVA: 0x003ABCA4 File Offset: 0x003A9EA4
	public override bool AllowSetCenterOffset()
	{
		return false;
	}

	// Token: 0x0600DA9E RID: 55966 RVA: 0x003ABCA7 File Offset: 0x003A9EA7
	public override bool AllowAddAssistantActor()
	{
		return false;
	}
}
