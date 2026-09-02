using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033E0 RID: 13280
public class RedDotTrapDefenseDevelopBranchBuilding : RedDotBase
{
	// Token: 0x0601B987 RID: 113031 RVA: 0x0083CF34 File Offset: 0x0083B134
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefenseDevelopBranchAll);
	}

	// Token: 0x0601B988 RID: 113032 RVA: 0x0083CF40 File Offset: 0x0083B140
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnBranchUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B989 RID: 113033 RVA: 0x0083CF5E File Offset: 0x0083B15E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnBranchUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B98A RID: 113034 RVA: 0x0083CF7C File Offset: 0x0083B17C
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckBuildingRedDot();
	}
}
