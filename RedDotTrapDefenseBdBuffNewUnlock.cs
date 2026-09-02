using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033DC RID: 13276
public class RedDotTrapDefenseBdBuffNewUnlock : RedDotBase
{
	// Token: 0x0601B97B RID: 113019 RVA: 0x0083CE62 File Offset: 0x0083B062
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefenseBdSum);
	}

	// Token: 0x0601B97C RID: 113020 RVA: 0x0083CE6E File Offset: 0x0083B06E
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseBdBuffNewUnlock, new Action(base.EventCheck));
	}

	// Token: 0x0601B97D RID: 113021 RVA: 0x0083CE8C File Offset: 0x0083B08C
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseBdBuffNewUnlock, new Action(base.EventCheck));
	}

	// Token: 0x0601B97E RID: 113022 RVA: 0x0083CEAA File Offset: 0x0083B0AA
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<TrapDefenseModel>.Instance.RougeModeData.RedDotNewUnlockBdBuff();
	}
}
