using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002ACF RID: 10959
public class SurvivorsRogueCardCostItem : SurvivorsRogueCardComponent
{
	// Token: 0x06015EAA RID: 89770 RVA: 0x006169B5 File Offset: 0x00614BB5
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUITexture)),
			new ValueTuple<int, Type>(1, typeof(UUIText))
		};
	}

	// Token: 0x06015EAB RID: 89771 RVA: 0x006169EE File Offset: 0x00614BEE
	[NullableContext(2)]
	protected override string OnGetResourceId()
	{
		return "UiItem_SurvivorsCardCost";
	}

	// Token: 0x06015EAC RID: 89772 RVA: 0x006169F5 File Offset: 0x00614BF5
	public override ECardMountPos GetLayoutLevel()
	{
		return ECardMountPos.Bottom;
	}

	// Token: 0x06015EAD RID: 89773 RVA: 0x006169F8 File Offset: 0x00614BF8
	protected override void OnRefresh([Nullable(new byte[]
	{
		1,
		2
	})] params object[] params_)
	{
		int? num = (params_.Length != 0 && params_[0] != null) ? ((int?)params_[0]) : null;
		bool flag = params_.Length > 1 && params_[1] != null && (bool)params_[1];
		if (num == null)
		{
			this.SetActive(false);
			return;
		}
		int currencyCount = ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetCurrencyCount();
		this.SetCost(num.Value, flag && currencyCount < num.Value);
		this.SetActive(true);
	}

	// Token: 0x06015EAE RID: 89774 RVA: 0x00616A80 File Offset: 0x00614C80
	public void SetCostItem(int costItemId)
	{
		base.SetItemIcon(base.GetTexture(0), costItemId, null, null);
	}

	// Token: 0x06015EAF RID: 89775 RVA: 0x00616AA8 File Offset: 0x00614CA8
	public void SetCost(int cost, bool useChangeColor)
	{
		UUIText text = base.GetText(1);
		text.SetText(cost.ToString(), true);
		UUIItem uuiitem = text;
		FColor? fcolor = new FColor?(text.changeColor);
		uuiitem.SetChangeColor(useChangeColor, fcolor);
	}
}
