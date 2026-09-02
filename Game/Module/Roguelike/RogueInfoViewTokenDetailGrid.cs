using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Roguelike
{
	// Token: 0x0200517A RID: 20858
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RogueInfoViewTokenDetailGrid : LoopScrollMediumItemGrid<RogueGainEntry>
	{
		// Token: 0x06035AB3 RID: 219827 RVA: 0x00D7B1B6 File Offset: 0x00D793B6
		protected override void OnStart()
		{
			base.SetUseFixedAsync(true);
			base.BindOnExtendToggleStateChanged(new Action<MediumItemGridExtendCallback>(this.OnStageChanged));
		}

		// Token: 0x06035AB4 RID: 219828 RVA: 0x00D7B1D4 File Offset: 0x00D793D4
		protected override void OnRefresh(RogueGainEntry data, bool isSelected, int gridIndex)
		{
			this.GridData = data;
			RogueBuffPool? rogueBuffConfig = ConfigBase<RoguelikeConfig>.Instance.GetRogueBuffConfig(data.ConfigId);
			InventoryModel instance = ModelBase<InventoryModel>.Instance;
			int num = (instance != null) ? instance.GetItemCountByConfigId(data.ShopItemCoinId, 0) : 0;
			IMediumItemPrice itemPrice = null;
			if (data.OriginalPrice != 0)
			{
				MediumItemPrice mediumItemPrice = new MediumItemPrice();
				mediumItemPrice.CurPrice = data.CurrentPrice.Value;
				mediumItemPrice.OriginalPrice = new int?(data.OriginalPrice);
				int num2 = num;
				int? currentPrice = data.CurrentPrice;
				mediumItemPrice.CurrencyNotEnough = new bool?(num2 < currentPrice.GetValueOrDefault() & currentPrice != null);
				itemPrice = mediumItemPrice;
			}
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				IconPath = rogueBuffConfig.Value.BuffIcon,
				QualityId = new int?(rogueBuffConfig.Value.Quality),
				QualityType = new CommonDefine.EQualityIconType?(CommonDefine.EQualityIconType.MediumItemGridQualitySpritePath),
				IsRogueFinish = data.IsSell,
				ItemPrice = itemPrice
			};
			base.Apply<PropMediumItemGrid>(parameters);
			this.SetSelected(isSelected, false);
			if (isSelected)
			{
				this.OnSelected(true);
			}
			ItemGridComponent component = base.RefreshComponent(typeof(RogueInfoViewTokenElement), new bool?(true), data);
			base.SetComponentVisible(component, data.OriginalPrice != 0);
			ItemGridComponent component2 = base.RefreshComponent(typeof(RogueInfoViewTokenDetailGridBottom), new bool?(true), data);
			base.SetComponentVisible(component2, data.OriginalPrice == 0);
			ItemGridComponent component3 = base.RefreshComponent(typeof(RogueInfoViewShopDiscountTag), new bool?(true), data);
			base.SetComponentVisible(component3, data.IsDiscounted());
		}

		// Token: 0x06035AB5 RID: 219829 RVA: 0x00D7B35A File Offset: 0x00D7955A
		public void OnStageChanged(MediumItemGridExtendCallback callbackParameter)
		{
			if (callbackParameter.State == EToggleState.ETT_Checked)
			{
				this.OnSelected(true);
			}
		}

		// Token: 0x06035AB6 RID: 219830 RVA: 0x00D7B36C File Offset: 0x00D7956C
		public override void OnSelected(bool fireEvent)
		{
			if (this.IsSelected)
			{
				return;
			}
			this.SetSelected(true, fireEvent);
			if (fireEvent)
			{
				Singleton<EventSystem>.Instance.Emit<RogueGainEntry, int>(EEventName.RoguelikeInfoSelectedToken, this.GridData, base.GridIndex);
			}
		}

		// Token: 0x06035AB7 RID: 219831 RVA: 0x00D7B39E File Offset: 0x00D7959E
		public override void OnDeselected(bool fireEvent)
		{
			this.SetSelected(false, false);
		}

		// Token: 0x0401ECF1 RID: 126193
		[Nullable(2)]
		public RogueGainEntry GridData;
	}
}
