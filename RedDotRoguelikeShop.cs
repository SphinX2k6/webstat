using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;

// Token: 0x020033AD RID: 13229
[NullableContext(1)]
[Nullable(0)]
public class RedDotRoguelikeShop : RedDotBase
{
	// Token: 0x0601B892 RID: 112786 RVA: 0x0083A8A8 File Offset: 0x00838AA8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RoguelikeDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Add<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Add<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Add(EEventName.CrossDay, new Action(base.EventCheck));
	}

	// Token: 0x0601B893 RID: 112787 RVA: 0x0083A960 File Offset: 0x00838B60
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoguelikeDataUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Remove<int, PayShopDefine.EPayShopTabType, int>(EEventName.RefreshGoods, new Action<int, PayShopDefine.EPayShopTabType, int>(this.OnRefreshGoods));
		Singleton<EventSystem>.Instance.Remove<IReadOnlySet<int>>(EEventName.RefreshGoodsList, new Action<IReadOnlySet<int>>(this.OnRefreshGoodsList));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Remove(EEventName.CrossDay, new Action(base.EventCheck));
	}

	// Token: 0x0601B894 RID: 112788 RVA: 0x0083AA15 File Offset: 0x00838C15
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B895 RID: 112789 RVA: 0x0083AA18 File Offset: 0x00838C18
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityRogueController>.Instance.RefreshActivityRedDot();
		return ModelBase<RoguelikeModel>.Instance.CheckRoguelikeShopRedDot();
	}

	// Token: 0x0601B896 RID: 112790 RVA: 0x0083AA2E File Offset: 0x00838C2E
	private void OnRefreshGoods(int goodsId, PayShopDefine.EPayShopTabType payShopId, int tabId)
	{
		base.EventCheck();
	}

	// Token: 0x0601B897 RID: 112791 RVA: 0x0083AA36 File Offset: 0x00838C36
	private void OnRefreshPayShop(int payShopId, bool ifItemRefresh)
	{
		base.EventCheck();
	}

	// Token: 0x0601B898 RID: 112792 RVA: 0x0083AA3E File Offset: 0x00838C3E
	private void OnRefreshAllPayShop(IEnumerable<PayShopDefine.EPayShopTabType> idList)
	{
		base.EventCheck();
	}

	// Token: 0x0601B899 RID: 112793 RVA: 0x0083AA46 File Offset: 0x00838C46
	private void OnRefreshGoodsList(IReadOnlySet<int> tabSet)
	{
		base.EventCheck();
	}
}
