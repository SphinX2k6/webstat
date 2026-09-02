using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033A1 RID: 13217
public class RedDotQuestViewItem : RedDotBase
{
	// Token: 0x0601B85F RID: 112735 RVA: 0x0083A2AF File Offset: 0x008384AF
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B860 RID: 112736 RVA: 0x0083A2CD File Offset: 0x008384CD
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnQuestRedDotStateChange, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B861 RID: 112737 RVA: 0x0083A2EC File Offset: 0x008384EC
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<QuestNewModel>.Instance.CheckQuestRedDotDataState(uId).GetValueOrDefault();
	}
}
