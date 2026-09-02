using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x02003365 RID: 13157
[NullableContext(1)]
[Nullable(0)]
public class RedDotMoonChasingShop : RedDotBase
{
	// Token: 0x0601B73A RID: 112442 RVA: 0x0083807A File Offset: 0x0083627A
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.MoonChasingRewardAndShop);
	}

	// Token: 0x0601B73B RID: 112443 RVA: 0x00838088 File Offset: 0x00836288
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.MoonChasingRefreshRewardRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Add<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
	}

	// Token: 0x0601B73C RID: 112444 RVA: 0x00838108 File Offset: 0x00836308
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.MoonChasingRefreshRewardRedDot, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Remove<IReadOnlyDictionary<int, HashSet<int>>>(EEventName.UnLockGoods, new Action<IReadOnlyDictionary<int, HashSet<int>>>(this.OnUnLockGoods));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.GoodsSoldOut, new Action<int>(this.OnGoodsSoldOut));
	}

	// Token: 0x0601B73D RID: 112445 RVA: 0x00838185 File Offset: 0x00836385
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B73E RID: 112446 RVA: 0x00838188 File Offset: 0x00836388
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityMoonChasingController>.Instance.RefreshActivityRedDot();
		return ModelBase<MoonChasingRewardModel>.Instance.GetShopRedDotState();
	}

	// Token: 0x0601B73F RID: 112447 RVA: 0x0083819E File Offset: 0x0083639E
	private void OnGoodsSoldOut(int _)
	{
		base.EventCheck();
	}

	// Token: 0x0601B740 RID: 112448 RVA: 0x008381A6 File Offset: 0x008363A6
	private void OnUnLockGoods(IReadOnlyDictionary<int, HashSet<int>> payShopMap)
	{
		base.EventCheck();
	}

	// Token: 0x0601B741 RID: 112449 RVA: 0x008381AE File Offset: 0x008363AE
	private void OnRefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		base.EventCheck();
	}
}
