using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

// Token: 0x02002D3F RID: 11583
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
public class WeeklyRogueTokenGrid : LoopScrollMediumItemGrid<RogueWeeklyEntry>
{
	// Token: 0x17001EC2 RID: 7874
	// (get) Token: 0x060175DF RID: 95711 RVA: 0x0067AC0F File Offset: 0x00678E0F
	public new RogueWeeklyEntry Data
	{
		get
		{
			return this.Data as RogueWeeklyEntry;
		}
	}

	// Token: 0x060175E0 RID: 95712 RVA: 0x0067AC1C File Offset: 0x00678E1C
	protected override void OnStart()
	{
		base.SetUseFixedAsync(true);
	}

	// Token: 0x060175E1 RID: 95713 RVA: 0x0067AC28 File Offset: 0x00678E28
	[NullableContext(1)]
	protected override void OnRefresh(RogueWeeklyEntry data, bool isSelected, int gridIndex)
	{
		this.Data = data;
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(data.ConfigId);
		if (rogueWeeklyBuffPool == null)
		{
			return;
		}
		RogueWeeklyGoods rogueWeeklyGoods = data.RogueWeeklyGoods;
		if (rogueWeeklyGoods == null)
		{
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				IconPath = rogueWeeklyBuffPool.Value.BuffIcon,
				QualityId = new int?(rogueWeeklyBuffPool.Value.Quality),
				QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath)
			};
			base.Apply<PropMediumItemGrid>(parameters);
			return;
		}
		int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(80100000, 0);
		bool bVisible = rogueWeeklyGoods.CurPrice != rogueWeeklyGoods.SourcePrice;
		IMediumItemPrice itemPrice = new MediumItemPrice
		{
			CurPrice = rogueWeeklyGoods.CurPrice,
			OriginalPrice = new int?(rogueWeeklyGoods.SourcePrice),
			CurrencyNotEnough = new bool?(itemCountByConfigId < rogueWeeklyGoods.CurPrice)
		};
		PropMediumItemGrid parameters2 = new PropMediumItemGrid
		{
			Data = data,
			IconPath = rogueWeeklyBuffPool.Value.BuffIcon,
			QualityId = new int?(rogueWeeklyBuffPool.Value.Quality),
			QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath),
			IsRogueFinish = new bool?(rogueWeeklyGoods.IsSell),
			ItemPrice = itemPrice
		};
		base.Apply<PropMediumItemGrid>(parameters2);
		ItemGridComponent component = base.RefreshComponent(typeof(WeeklyRougeShopDiscountTag), new bool?(true), rogueWeeklyGoods);
		base.SetComponentVisible(component, bVisible);
	}

	// Token: 0x060175E2 RID: 95714 RVA: 0x0067AD9E File Offset: 0x00678F9E
	protected override void OnExtendToggleStateChanged(EToggleState state)
	{
		if (state == EToggleState.ETT_Checked)
		{
			this.OnSelected(true);
		}
	}

	// Token: 0x060175E3 RID: 95715 RVA: 0x0067ADAC File Offset: 0x00678FAC
	public override void OnSelected(bool fireEvent)
	{
		this.SetSelected(true, false);
		ModelBase<WeeklyRogueModel>.Instance.SelectEntry = this.Data;
		if (fireEvent)
		{
			Singleton<EventSystem>.Instance.Emit<int, RogueWeeklyEntry>(EEventName.WeeklyRogueShopSelect, base.GridIndex, this.Data);
		}
		ControllerBase<UiNavigationNewController>.Instance.SetNavigationFocusForView(this.GetItemGridExtendToggle().RootUIComp, false, false, false);
	}

	// Token: 0x060175E4 RID: 95716 RVA: 0x0067AE0E File Offset: 0x0067900E
	public override void OnDeselected(bool fireEvent)
	{
		this.SetSelected(false, false);
		ModelBase<WeeklyRogueModel>.Instance.SelectEntry = null;
	}
}
