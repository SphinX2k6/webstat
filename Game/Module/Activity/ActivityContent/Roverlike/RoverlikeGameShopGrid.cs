using System;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x0200641C RID: 25628
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class RoverlikeGameShopGrid : LoopScrollMediumItemGrid<IRoverlikeGameShopGridData>
	{
		// Token: 0x0604055E RID: 263518 RVA: 0x0107D457 File Offset: 0x0107B657
		public void BindOnSelect(Action<IRoverlikeGameShopGridData> cb)
		{
			this.OnSelect = cb;
		}

		// Token: 0x0604055F RID: 263519 RVA: 0x0107D460 File Offset: 0x0107B660
		protected override void OnStart()
		{
			base.SetUseFixedAsync(true);
		}

		// Token: 0x06040560 RID: 263520 RVA: 0x0107D46C File Offset: 0x0107B66C
		protected override void OnRefresh(IRoverlikeGameShopGridData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			RoverRogueItem? itemConfig = ConfigBase<RoverlikeConfig>.Instance.GetItemConfig(data.ShowItemId);
			int gold = ModelBase<RoverlikeModel>.Instance.Gold;
			MediumItemPrice itemPrice = new MediumItemPrice
			{
				CurPrice = data.FinalPrice,
				OriginalPrice = new int?(data.OriginalPrice),
				CurrencyNotEnough = new bool?(gold < data.FinalPrice)
			};
			PropMediumItemGrid parameters = new PropMediumItemGrid
			{
				Data = data,
				IconPath = itemConfig.Value.Icon,
				QualityId = new int?(itemConfig.Value.Quality),
				IsRogueFinish = new bool?(data.IsBought),
				ItemPrice = itemPrice
			};
			base.Apply<PropMediumItemGrid>(parameters);
			this.SetSelected(data.IsSelected, false);
			bool value = data.OriginalPrice > data.FinalPrice;
			base.RefreshComponent(typeof(RoverlikeGameShopDiscountTagComponent), new bool?(value), data);
		}

		// Token: 0x06040561 RID: 263521 RVA: 0x0107D566 File Offset: 0x0107B766
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			if (state == EToggleState.ETT_Checked && this.Data != null)
			{
				Action<IRoverlikeGameShopGridData> onSelect = this.OnSelect;
				if (onSelect == null)
				{
					return;
				}
				onSelect(this.Data);
			}
		}

		// Token: 0x06040562 RID: 263522 RVA: 0x0107D58A File Offset: 0x0107B78A
		public override object GetKey(IRoverlikeGameShopGridData data, int gridIndex)
		{
			return data.IncId;
		}

		// Token: 0x040240D3 RID: 147667
		[Nullable(2)]
		public new IRoverlikeGameShopGridData Data;

		// Token: 0x040240D4 RID: 147668
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<IRoverlikeGameShopGridData> OnSelect;
	}
}
