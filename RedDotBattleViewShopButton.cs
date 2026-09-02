using System;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;

// Token: 0x0200330B RID: 13067
public class RedDotBattleViewShopButton : RedDotBase
{
	// Token: 0x0601B5B6 RID: 112054 RVA: 0x00835125 File Offset: 0x00833325
	protected override bool OnCheck(int uId = 0)
	{
		return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.FirstOpenShop, true);
	}

	// Token: 0x0601B5B7 RID: 112055 RVA: 0x0083512E File Offset: 0x0083332E
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFirstOpenShopChanged, new Action(base.EventCheck));
	}

	// Token: 0x0601B5B8 RID: 112056 RVA: 0x0083514C File Offset: 0x0083334C
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFirstOpenShopChanged, new Action(base.EventCheck));
	}
}
