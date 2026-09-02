using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using UnrealEngine;

// Token: 0x02002D2D RID: 11565
public class WeeklyRougeShopDiscountTag : MediumItemGridComponent
{
	// Token: 0x06017585 RID: 95621 RVA: 0x00678EBF File Offset: 0x006770BF
	[NullableContext(1)]
	protected override string GetResourceId()
	{
		return "UiItem_ItemDiscountTag";
	}

	// Token: 0x06017586 RID: 95622 RVA: 0x00678EC6 File Offset: 0x006770C6
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText))
		};
	}

	// Token: 0x06017587 RID: 95623 RVA: 0x00678EEC File Offset: 0x006770EC
	[NullableContext(1)]
	protected override void OnRefresh(object data)
	{
		RogueWeeklyGoods rogueWeeklyGoods = (RogueWeeklyGoods)data;
		double num = (1.0 - (double)rogueWeeklyGoods.CurPrice / (double)rogueWeeklyGoods.SourcePrice) * 100.0;
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "RogueInfoViewShopDiscount", new <>z__ReadOnlySingleElementList<object>(num));
	}

	// Token: 0x02008FF2 RID: 36850
	private enum EWeeklyRogueShopDiscountTagDefine
	{
		// Token: 0x040304CC RID: 197836
		TxtDiscount
	}
}
