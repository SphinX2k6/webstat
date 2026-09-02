using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Infrastructure;

// Token: 0x0200334C RID: 13132
public class RedDotInfrShop : RedDotBase
{
	// Token: 0x0601B6C8 RID: 112328 RVA: 0x008371D0 File Offset: 0x008353D0
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.Infrastructure);
	}

	// Token: 0x0601B6C9 RID: 112329 RVA: 0x008371DC File Offset: 0x008353DC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureShopRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.InfrastructureFireDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B6CA RID: 112330 RVA: 0x00837240 File Offset: 0x00835440
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureShopRedDotUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.InfrastructureFireDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B6CB RID: 112331 RVA: 0x008372A1 File Offset: 0x008354A1
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<InfrastructureModel>.Instance.GetShopHasNewRedDot();
	}

	// Token: 0x0601B6CC RID: 112332 RVA: 0x008372AD File Offset: 0x008354AD
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		base.EventCheck();
	}
}
