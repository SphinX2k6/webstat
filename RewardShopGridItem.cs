using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.PayShop;

// Token: 0x02001414 RID: 5140
[NullableContext(1)]
[Nullable(0)]
public class RewardShopGridItem : PayShopItem
{
	// Token: 0x06008E76 RID: 36470 RVA: 0x00256BC8 File Offset: 0x00254DC8
	protected override void OnStart()
	{
		base.OnStart();
		base.SetExtraFunction(new Action<PayShopItem, PayShopGoods>(this.ClearNewFlagState));
	}

	// Token: 0x06008E77 RID: 36471 RVA: 0x00256BE4 File Offset: 0x00254DE4
	public override void Refresh(IPayShopUnionData data, bool isSelected, int gridIndex)
	{
		PayShopGoods payShopGoods = data as PayShopGoods;
		if (payShopGoods == null)
		{
			return;
		}
		base.Refresh(payShopGoods, isSelected, gridIndex);
		bool newFlagState = ModelBase<MoonChasingRewardModel>.Instance.CheckShopItemRedDotState(payShopGoods);
		base.SetNewFlagState(newFlagState);
	}

	// Token: 0x06008E78 RID: 36472 RVA: 0x00256C18 File Offset: 0x00254E18
	private void ClearNewFlagState(PayShopItem item, PayShopGoods data)
	{
		if (ModelBase<MoonChasingRewardModel>.Instance.ReadShopItemUnlockFlag(data))
		{
			base.SetNewFlagState(false);
		}
	}
}
