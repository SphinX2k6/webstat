using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x020067C3 RID: 26563
	public class DockyardShopGridItem : PayShopItem
	{
		// Token: 0x06042451 RID: 271441 RVA: 0x010FFBED File Offset: 0x010FDDED
		protected override void OnStart()
		{
			base.OnStart();
			base.SetExtraFunction(new Action<PayShopItem, PayShopGoods>(this.ClearNewFlagState));
			base.SetRedDotState(false);
		}

		// Token: 0x06042452 RID: 271442 RVA: 0x010FFC10 File Offset: 0x010FDE10
		[NullableContext(2)]
		public override void Refresh(IPayShopUnionData data, bool isSelected, int gridIndex)
		{
			PayShopGoods payShopGoods = data as PayShopGoods;
			if (payShopGoods == null)
			{
				return;
			}
			base.Refresh(payShopGoods, isSelected, gridIndex);
			base.SetNewFlagState(payShopGoods.GetIfNeedRemind());
		}

		// Token: 0x06042453 RID: 271443 RVA: 0x010FFC3D File Offset: 0x010FDE3D
		[NullableContext(1)]
		private void ClearNewFlagState(PayShopItem item, PayShopGoods data)
		{
			base.SetNewFlagState(data.GetIfNeedRemind());
		}
	}
}
