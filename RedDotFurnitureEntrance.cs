using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020033D1 RID: 13265
[NullableContext(1)]
[Nullable(0)]
public class RedDotFurnitureEntrance : RedDotBase
{
	// Token: 0x0601B94B RID: 112971 RVA: 0x0083C790 File Offset: 0x0083A990
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateFurnitureEntranceRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Add<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Add<List<Aki.Protocol.PayShopItem>>(EEventName.OnPayShopConditionFinish, new Action<List<Aki.Protocol.PayShopItem>>(this.OnPayShopConditionFinish));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FurnitureFunctionOpenNotify, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Add<int, IReadOnlyList<AreaInfo>>(EEventName.OnFurnitureAreaUnlockNotify, new Action<int, IReadOnlyList<AreaInfo>>(this.OnFurnitureAreaUnlockNotify));
	}

	// Token: 0x0601B94C RID: 112972 RVA: 0x0083C864 File Offset: 0x0083AA64
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.UpdateFurnitureEntranceRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Remove<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Remove<List<Aki.Protocol.PayShopItem>>(EEventName.OnPayShopConditionFinish, new Action<List<Aki.Protocol.PayShopItem>>(this.OnPayShopConditionFinish));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.FurnitureFunctionOpenNotify, new Action<int>(base.EventCheckWithUid));
		Singleton<EventSystem>.Instance.Remove<int, IReadOnlyList<AreaInfo>>(EEventName.OnFurnitureAreaUnlockNotify, new Action<int, IReadOnlyList<AreaInfo>>(this.OnFurnitureAreaUnlockNotify));
	}

	// Token: 0x0601B94D RID: 112973 RVA: 0x0083C935 File Offset: 0x0083AB35
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<FurnitureModel>.Instance.CheckFurnitureEntranceRedDot();
	}

	// Token: 0x0601B94E RID: 112974 RVA: 0x0083C941 File Offset: 0x0083AB41
	private void OnUnLockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopMap)
	{
		base.EventCheck();
	}

	// Token: 0x0601B94F RID: 112975 RVA: 0x0083C949 File Offset: 0x0083AB49
	private void OnRefreshAllPayShop(IEnumerable<PayShopDefine.EPayShopTabType> idList)
	{
		base.EventCheck();
	}

	// Token: 0x0601B950 RID: 112976 RVA: 0x0083C951 File Offset: 0x0083AB51
	private void OnRefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		base.EventCheck();
	}

	// Token: 0x0601B951 RID: 112977 RVA: 0x0083C959 File Offset: 0x0083AB59
	private void OnPayShopConditionFinish(List<Aki.Protocol.PayShopItem> shopItemList)
	{
		base.EventCheck();
	}

	// Token: 0x0601B952 RID: 112978 RVA: 0x0083C961 File Offset: 0x0083AB61
	private void OnFurnitureAreaUnlockNotify(int handleId, IReadOnlyList<AreaInfo> areaIds)
	{
		base.EventCheck();
	}
}
