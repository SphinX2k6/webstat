using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.PhantomArena;

// Token: 0x02003394 RID: 13204
public class RedDotPhantomArenaShopUpdate : RedDotBase
{
	// Token: 0x0601B81C RID: 112668 RVA: 0x00839A7D File Offset: 0x00837C7D
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.RedDotPhantomArenaLimitReward);
	}

	// Token: 0x0601B81D RID: 112669 RVA: 0x00839A89 File Offset: 0x00837C89
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnPhantomArenaShopOpen, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
	}

	// Token: 0x0601B81E RID: 112670 RVA: 0x00839AC3 File Offset: 0x00837CC3
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnPhantomArenaShopOpen, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
	}

	// Token: 0x0601B81F RID: 112671 RVA: 0x00839AFD File Offset: 0x00837CFD
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B820 RID: 112672 RVA: 0x00839B00 File Offset: 0x00837D00
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomArenaModel>.Instance.CheckShopRedDot(uId);
	}

	// Token: 0x0601B821 RID: 112673 RVA: 0x00839B0D File Offset: 0x00837D0D
	[NullableContext(1)]
	private void OnRefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		base.EventCheck();
	}
}
