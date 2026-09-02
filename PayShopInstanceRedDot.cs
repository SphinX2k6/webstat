using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x020033CB RID: 13259
[NullableContext(1)]
[Nullable(0)]
public class PayShopInstanceRedDot : RedDotBase
{
	// Token: 0x0601B923 RID: 112931 RVA: 0x0083BF26 File Offset: 0x0083A126
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.FunctionPayShop);
	}

	// Token: 0x0601B924 RID: 112932 RVA: 0x0083BF2F File Offset: 0x0083A12F
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B925 RID: 112933 RVA: 0x0083BF32 File Offset: 0x0083A132
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B926 RID: 112934 RVA: 0x0083BF38 File Offset: 0x0083A138
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
		Singleton<EventSystem>.Instance.Add(EEventName.ReceiveWeekCardDataEvent, new Action(base.EventCheck));
	}

	// Token: 0x0601B927 RID: 112935 RVA: 0x0083C044 File Offset: 0x0083A244
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
		Singleton<EventSystem>.Instance.Remove(EEventName.ReceiveWeekCardDataEvent, new Action(base.EventCheck));
	}

	// Token: 0x0601B928 RID: 112936 RVA: 0x0083C14D File Offset: 0x0083A34D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PayShopModel>.Instance.CheckPayShopHasRedDot((PayShopDefine.EPayShopTabType)uId);
	}

	// Token: 0x0601B929 RID: 112937 RVA: 0x0083C15A File Offset: 0x0083A35A
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		base.EventCheck();
	}

	// Token: 0x0601B92A RID: 112938 RVA: 0x0083C162 File Offset: 0x0083A362
	private void OnUnLockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopMap)
	{
		base.EventCheck();
	}

	// Token: 0x0601B92B RID: 112939 RVA: 0x0083C16A File Offset: 0x0083A36A
	private void OnRefreshPayShop(int payShopId, bool ifItemRefresh)
	{
		base.EventCheck();
	}

	// Token: 0x0601B92C RID: 112940 RVA: 0x0083C172 File Offset: 0x0083A372
	private void OnRefreshAllPayShop(IEnumerable<PayShopDefine.EPayShopTabType> idList)
	{
		base.EventCheck();
	}

	// Token: 0x0601B92D RID: 112941 RVA: 0x0083C17A File Offset: 0x0083A37A
	private void OnRefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		base.EventCheck();
	}

	// Token: 0x0601B92E RID: 112942 RVA: 0x0083C182 File Offset: 0x0083A382
	private void OnRefreshPayShopInstanceRedDot(PayShopDefine.EPayShopTabType payShopId)
	{
		base.EventCheck();
	}
}
