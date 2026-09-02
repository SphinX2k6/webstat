using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033DF RID: 13279
public class RedDotTrapDefenseDevelopBranchAuxiliary : RedDotBase
{
	// Token: 0x0601B982 RID: 113026 RVA: 0x0083CED3 File Offset: 0x0083B0D3
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefenseDevelopBranchAll);
	}

	// Token: 0x0601B983 RID: 113027 RVA: 0x0083CEDF File Offset: 0x0083B0DF
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.TrapDefenseOnBranchUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B984 RID: 113028 RVA: 0x0083CEFD File Offset: 0x0083B0FD
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.TrapDefenseOnBranchUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B985 RID: 113029 RVA: 0x0083CF1B File Offset: 0x0083B11B
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<TrapDefenseModel>.Instance.ViewModelBuildingDevelop.CheckAuxiliaryRedDot();
	}
}
