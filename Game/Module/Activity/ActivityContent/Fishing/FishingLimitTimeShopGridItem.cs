using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x02006788 RID: 26504
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingLimitTimeShopGridItem : PayShopItem
	{
		// Token: 0x0604211D RID: 270621 RVA: 0x010F393B File Offset: 0x010F1B3B
		public FishingLimitTimeShopGridItem(ActivityFishingData ActivityDataBase)
		{
		}

		// Token: 0x0604211E RID: 270622 RVA: 0x010F3943 File Offset: 0x010F1B43
		protected override void OnStart()
		{
			base.OnStart();
			base.SetExtraFunction(new Action<PayShopItem, PayShopGoods>(this.ClearNewFlagState));
			base.SetRedDotState(false);
		}

		// Token: 0x0604211F RID: 270623 RVA: 0x010F3964 File Offset: 0x010F1B64
		public override void Refresh(IPayShopUnionData data, bool isSelected, int gridIndex)
		{
			PayShopGoods payShopGoods = data as PayShopGoods;
			if (payShopGoods == null)
			{
				return;
			}
			base.Refresh(data, isSelected, gridIndex);
			base.SetNewFlagState(payShopGoods.GetIfNeedRemind());
		}

		// Token: 0x06042120 RID: 270624 RVA: 0x010F3991 File Offset: 0x010F1B91
		private void ClearNewFlagState(PayShopItem item, PayShopGoods data)
		{
			base.SetNewFlagState(data.GetIfNeedRemind());
		}
	}
}
