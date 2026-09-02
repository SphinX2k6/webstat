using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033E5 RID: 13285
public class RedDotTrapDefenseRougeModeOpen : RedDotBase
{
	// Token: 0x0601B998 RID: 113048 RVA: 0x0083D067 File Offset: 0x0083B267
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefenseRougeLevel);
	}

	// Token: 0x0601B999 RID: 113049 RVA: 0x0083D073 File Offset: 0x0083B273
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseRougeModeOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B99A RID: 113050 RVA: 0x0083D091 File Offset: 0x0083B291
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseRougeModeOpen, new Action(base.EventCheck));
	}

	// Token: 0x0601B99B RID: 113051 RVA: 0x0083D0AF File Offset: 0x0083B2AF
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<TrapDefenseModel>.Instance.RougeModeData.RedDotModeOpen();
	}
}
