using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using UnrealEngine;

namespace CSharpScript.Game.Module.TrapDefense
{
	// Token: 0x02004E4E RID: 20046
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class TrapDefenseShopGoodsItem : LoopScrollMediumItemGrid<ITrapDefenseShopGoods>
	{
		// Token: 0x06033CE5 RID: 212197 RVA: 0x00CF396E File Offset: 0x00CF1B6E
		protected override void OnStart()
		{
			base.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.AddOnSelectGoodsDelegate(new Action<ITrapDefenseShopGoods>(this.OnSelectGoods));
		}

		// Token: 0x06033CE6 RID: 212198 RVA: 0x00CF399D File Offset: 0x00CF1B9D
		protected override void OnBeforeDestroy()
		{
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.RemoveOnSelectGoodsDelegate(new Action<ITrapDefenseShopGoods>(this.OnSelectGoods));
		}

		// Token: 0x06033CE7 RID: 212199 RVA: 0x00CF39BA File Offset: 0x00CF1BBA
		protected override void OnRefresh(ITrapDefenseShopGoods data, bool isSelected, int gridIndex)
		{
			this.GoodsData = data;
			base.Apply<PropMediumItemGrid>(data.GetItemGridParam());
		}

		// Token: 0x06033CE8 RID: 212200 RVA: 0x00CF39D4 File Offset: 0x00CF1BD4
		private void OnClickedGrid(MediumItemGridExtendCallback _)
		{
			if (this.GoodsData == null)
			{
				return;
			}
			if (this.IsSelected)
			{
				return;
			}
			ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectGoods(this.GoodsData);
		}

		// Token: 0x06033CE9 RID: 212201 RVA: 0x00CF3A00 File Offset: 0x00CF1C00
		protected override void OnExtendToggleStateChanged(EToggleState state)
		{
			UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
			if (state == EToggleState.ETT_UnChecked && this.IsSelected)
			{
				itemGridExtendToggle.SetToggleStateForce(EToggleState.ETT_Checked, false, false, false);
			}
			if (state == EToggleState.ETT_Checked && !this.IsSelected)
			{
				ModelBase<TrapDefenseModel>.Instance.ViewModelShop.SelectGoods(this.GoodsData);
			}
		}

		// Token: 0x06033CEA RID: 212202 RVA: 0x00CF3A4C File Offset: 0x00CF1C4C
		private void OnSelectGoods(ITrapDefenseShopGoods goods)
		{
			UUIExtendToggle itemGridExtendToggle = this.GetItemGridExtendToggle();
			if (goods == this.GoodsData && itemGridExtendToggle.GetToggleState() != EToggleState.ETT_Checked)
			{
				this.IsSelected = true;
				itemGridExtendToggle.SetToggleState(EToggleState.ETT_Checked, false, false, false);
			}
			if (goods != this.GoodsData && itemGridExtendToggle.GetToggleState() != EToggleState.ETT_UnChecked)
			{
				this.IsSelected = false;
				itemGridExtendToggle.SetToggleStateForce(EToggleState.ETT_UnChecked, false, false, false);
			}
		}

		// Token: 0x0401DF9F RID: 122783
		private ITrapDefenseShopGoods GoodsData;
	}
}
