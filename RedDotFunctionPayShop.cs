using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;

// Token: 0x0200333F RID: 13119
public class RedDotFunctionPayShop : RedDotBase
{
	// Token: 0x0601B697 RID: 112279 RVA: 0x00836B67 File Offset: 0x00834D67
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewMenu);
	}

	// Token: 0x0601B698 RID: 112280 RVA: 0x00836B70 File Offset: 0x00834D70
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnFunctionViewShow, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshPayShopEntranceRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B699 RID: 112281 RVA: 0x00836BD4 File Offset: 0x00834DD4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionViewShow, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<IEnumerable<PayShopDefine.EPayShopTabType>>(EEventName.RefreshAllPayShop, new Action<IEnumerable<PayShopDefine.EPayShopTabType>>(this.OnRefreshAllPayShop));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshPayShopEntranceRedDot, new Action(base.EventCheck));
	}

	// Token: 0x0601B69A RID: 112282 RVA: 0x00836C35 File Offset: 0x00834E35
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PayShopModel>.Instance.CheckPayShopEntranceHasRedDot();
	}

	// Token: 0x0601B69B RID: 112283 RVA: 0x00836C41 File Offset: 0x00834E41
	[NullableContext(1)]
	private void OnRefreshAllPayShop(IEnumerable<PayShopDefine.EPayShopTabType> idList)
	{
		base.EventCheck();
	}
}
