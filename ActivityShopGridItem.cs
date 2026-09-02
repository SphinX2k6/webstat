using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x020012A1 RID: 4769
[NullableContext(1)]
[Nullable(0)]
public class ActivityShopGridItem : ActivityGrid
{
	// Token: 0x06007FE0 RID: 32736 RVA: 0x0021C9BF File Offset: 0x0021ABBF
	protected override void OnStart()
	{
		base.OnStart();
		base.SetExtraFunction(new Action<PayShopItem, PayShopGoods>(this.ClearNewFlagState));
		base.SetRedDotState(false);
	}

	// Token: 0x06007FE1 RID: 32737 RVA: 0x0021C9E0 File Offset: 0x0021ABE0
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

	// Token: 0x06007FE2 RID: 32738 RVA: 0x0021CA0D File Offset: 0x0021AC0D
	private void ClearNewFlagState(PayShopItem item, PayShopGoods data)
	{
		base.SetNewFlagState(data.GetIfNeedRemind());
	}
}
