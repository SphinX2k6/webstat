using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020033CC RID: 13260
[NullableContext(1)]
[Nullable(0)]
public class PayShopTabRedDot : RedDotBase
{
	// Token: 0x0601B930 RID: 112944 RVA: 0x0083C192 File Offset: 0x0083A392
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B931 RID: 112945 RVA: 0x0083C195 File Offset: 0x0083A395
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B932 RID: 112946 RVA: 0x0083C198 File Offset: 0x0083A398
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsRefreshDiscountTime, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<PayShopDefine.EPayShopTabType>(EEventName.SwitchPayShopView, new Action<PayShopDefine.EPayShopTabType>(this.OnSwitchPayShopView));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshPayShopTabRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveWeekCardDataEvent, new Action(base.EventCheck));
	}

	// Token: 0x0601B933 RID: 112947 RVA: 0x0083C2A4 File Offset: 0x0083A4A4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.GoodsRefreshDiscountTime, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<PayShopDefine.EPayShopTabType>(EEventName.SwitchPayShopView, new Action<PayShopDefine.EPayShopTabType>(this.OnSwitchPayShopView));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshPayShopTabRedDot, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveWeekCardDataEvent, new Action(base.EventCheck));
	}

	// Token: 0x0601B934 RID: 112948 RVA: 0x0083C3B0 File Offset: 0x0083A5B0
	protected override bool OnCheck(int uId = 0)
	{
		int currentPayShopId = ModelBase<PayShopModel>.Instance.GetCurrentPayShopId();
		return ModelBase<PayShopModel>.Instance.CheckPayShopTabHasRedDot((PayShopDefine.EPayShopTabType)currentPayShopId, uId);
	}

	// Token: 0x0601B935 RID: 112949 RVA: 0x0083C3D4 File Offset: 0x0083A5D4
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		base.EventCheck();
	}

	// Token: 0x0601B936 RID: 112950 RVA: 0x0083C3DC File Offset: 0x0083A5DC
	private void OnUnLockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopMap)
	{
		base.EventCheck();
	}

	// Token: 0x0601B937 RID: 112951 RVA: 0x0083C3E4 File Offset: 0x0083A5E4
	private void OnRefreshPayShop(int payShopId, bool ifItemRefresh)
	{
		base.EventCheck();
	}

	// Token: 0x0601B938 RID: 112952 RVA: 0x0083C3EC File Offset: 0x0083A5EC
	private void OnSwitchPayShopView(PayShopDefine.EPayShopTabType payShopId)
	{
		base.EventCheck();
	}

	// Token: 0x0601B939 RID: 112953 RVA: 0x0083C3F4 File Offset: 0x0083A5F4
	private void OnRefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		base.EventCheck();
	}
}
