using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;

// Token: 0x020032F2 RID: 13042
public class RedDotRoverlikeShopRewardBtn : RedDotBase
{
	// Token: 0x0601B53E RID: 111934 RVA: 0x008341B0 File Offset: 0x008323B0
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PayShopGoodsBuy, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Add<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
	}

	// Token: 0x0601B53F RID: 111935 RVA: 0x00834230 File Offset: 0x00832430
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PayShopGoodsBuy, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int, bool>(EEventName.RefreshPayShop, new Action<int, bool>(this.OnRefreshPayShop));
		Singleton<EventSystem>.Instance.Remove<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.OnPlayerCurrencyChange, new Action<int>(this.OnPlayerCurrencyChange));
	}

	// Token: 0x0601B540 RID: 111936 RVA: 0x008342AD File Offset: 0x008324AD
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B541 RID: 111937 RVA: 0x008342B0 File Offset: 0x008324B0
	private void OnRefreshPayShop(int payShopId, bool ifItemRefresh)
	{
		base.EventCheck();
	}

	// Token: 0x0601B542 RID: 111938 RVA: 0x008342B8 File Offset: 0x008324B8
	[NullableContext(1)]
	private void OnRefreshAllPayShop(IEnumerable<PayShopDefine.EPayShopTabType> idList)
	{
		base.EventCheck();
	}

	// Token: 0x0601B543 RID: 111939 RVA: 0x008342C0 File Offset: 0x008324C0
	private void OnPlayerCurrencyChange(int itemId)
	{
		base.EventCheck();
	}

	// Token: 0x0601B544 RID: 111940 RVA: 0x008342C8 File Offset: 0x008324C8
	protected override bool OnCheck(int uId = 0)
	{
		RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
		RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
		return roverlikeActivityData != null && roverlikeActivityData.HasShopRedDot();
	}
}
