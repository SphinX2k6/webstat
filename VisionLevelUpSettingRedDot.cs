using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033EE RID: 13294
public class VisionLevelUpSettingRedDot : RedDotBase
{
	// Token: 0x0601B9C4 RID: 113092 RVA: 0x0083D4EE File Offset: 0x0083B6EE
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshVisionLevelUpSettingRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x0601B9C5 RID: 113093 RVA: 0x0083D50C File Offset: 0x0083B70C
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshVisionLevelUpSettingRedPoint, new Action(base.EventCheck));
	}

	// Token: 0x0601B9C6 RID: 113094 RVA: 0x0083D52A File Offset: 0x0083B72A
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomBattleModel>.Instance.CheckVisionLevelUpSettingRedDot();
	}
}
