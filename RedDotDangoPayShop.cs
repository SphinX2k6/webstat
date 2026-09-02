using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x0200331F RID: 13087
[NullableContext(1)]
[Nullable(0)]
public class RedDotDangoPayShop : RedDotBase
{
	// Token: 0x0601B60A RID: 112138 RVA: 0x00835A6F File Offset: 0x00833C6F
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B60B RID: 112139 RVA: 0x00835A74 File Offset: 0x00833C74
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsRefreshDiscountTime, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Add<PayShopDefine.EPayShopTabType>(EEventName.RefreshPayShopInstanceRedDot, new Action<PayShopDefine.EPayShopTabType>(this.OnRefreshPayShopInstanceRedDot));
	}

	// Token: 0x0601B60C RID: 112140 RVA: 0x00835B64 File Offset: 0x00833D64
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.GoodsRefreshDiscountTime, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Remove<PayShopDefine.EPayShopTabType>(EEventName.RefreshPayShopInstanceRedDot, new Action<PayShopDefine.EPayShopTabType>(this.OnRefreshPayShopInstanceRedDot));
	}

	// Token: 0x0601B60D RID: 112141 RVA: 0x00835C51 File Offset: 0x00833E51
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<DangoAbyssModel>.Instance.CheckPayShopRedDot();
	}

	// Token: 0x0601B60E RID: 112142 RVA: 0x00835C5D File Offset: 0x00833E5D
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		base.EventCheck();
	}

	// Token: 0x0601B60F RID: 112143 RVA: 0x00835C65 File Offset: 0x00833E65
	private void OnUnLockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopMap)
	{
		base.EventCheck();
	}

	// Token: 0x0601B610 RID: 112144 RVA: 0x00835C6D File Offset: 0x00833E6D
	private void OnRefreshPayShop(int payShopId, bool ifItemRefresh)
	{
		base.EventCheck();
	}

	// Token: 0x0601B611 RID: 112145 RVA: 0x00835C75 File Offset: 0x00833E75
	private void OnRefreshAllPayShop(IEnumerable<PayShopDefine.EPayShopTabType> idList)
	{
		base.EventCheck();
	}

	// Token: 0x0601B612 RID: 112146 RVA: 0x00835C7D File Offset: 0x00833E7D
	private void OnRefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		base.EventCheck();
	}

	// Token: 0x0601B613 RID: 112147 RVA: 0x00835C85 File Offset: 0x00833E85
	private void OnRefreshPayShopInstanceRedDot(PayShopDefine.EPayShopTabType obj)
	{
		base.EventCheck();
	}
}
