using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;

// Token: 0x020033AE RID: 13230
public class RedDotRoguelikeSkillCanUnlock : RedDotBase
{
	// Token: 0x0601B89B RID: 112795 RVA: 0x0083AA58 File Offset: 0x00838C58
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeCurrencyUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RoguelikeTalentLevelUp, new Action<int>(this.OnRoguelikeTalentLevelUp));
	}

	// Token: 0x0601B89C RID: 112796 RVA: 0x0083AABC File Offset: 0x00838CBC
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeCurrencyUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RoguelikeTalentLevelUp, new Action<int>(this.OnRoguelikeTalentLevelUp));
	}

	// Token: 0x0601B89D RID: 112797 RVA: 0x0083AB1D File Offset: 0x00838D1D
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B89E RID: 112798 RVA: 0x0083AB20 File Offset: 0x00838D20
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityRogueController>.Instance.RefreshActivityRedDot();
		return ModelBase<RoguelikeModel>.Instance.CheckHasCanUnlockSkill();
	}

	// Token: 0x0601B89F RID: 112799 RVA: 0x0083AB36 File Offset: 0x00838D36
	private void OnRoguelikeTalentLevelUp(int _)
	{
		base.EventCheck();
	}
}
