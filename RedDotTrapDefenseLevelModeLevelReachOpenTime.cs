using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033E1 RID: 13281
public class RedDotTrapDefenseLevelModeLevelReachOpenTime : RedDotBase
{
	// Token: 0x0601B98C RID: 113036 RVA: 0x0083CF95 File Offset: 0x0083B195
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefenseMainLevel);
	}

	// Token: 0x0601B98D RID: 113037 RVA: 0x0083CFA1 File Offset: 0x0083B1A1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseLevelModeLevelReachOpenTime, new Action(base.EventCheck));
	}

	// Token: 0x0601B98E RID: 113038 RVA: 0x0083CFBF File Offset: 0x0083B1BF
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseLevelModeLevelReachOpenTime, new Action(base.EventCheck));
	}

	// Token: 0x0601B98F RID: 113039 RVA: 0x0083CFDD File Offset: 0x0083B1DD
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<TrapDefenseModel>.Instance.LevelModeData.RedDotLevelReachOpenTime();
	}
}
