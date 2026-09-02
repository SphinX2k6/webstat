using System;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Ui;

// Token: 0x02002AF1 RID: 10993
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsRogueCommandShop : SurvivorsRogueCommandBase
{
	// Token: 0x06015FB3 RID: 90035 RVA: 0x00619EED File Offset: 0x006180ED
	public SurvivorsRogueCommandShop(ESurvivorsRogueCommandType type) : base(type)
	{
	}

	// Token: 0x06015FB4 RID: 90036 RVA: 0x00619EF8 File Offset: 0x006180F8
	public override string ToString()
	{
		SurvivorsOption shopData = this.GetShopData();
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 2);
		defaultInterpolatedStringHandler.AppendLiteral("[Shop] Count: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(shopData.GoodsDetails.Count);
		defaultInterpolatedStringHandler.AppendLiteral(" RefreshCost: ");
		defaultInterpolatedStringHandler.AppendFormatted<int>(shopData.RefreshCost);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06015FB5 RID: 90037 RVA: 0x00619F54 File Offset: 0x00618154
	private SurvivorsOption GetShopData()
	{
		return this.Data.ShopView.SurvivorsOption;
	}

	// Token: 0x06015FB6 RID: 90038 RVA: 0x00619F66 File Offset: 0x00618166
	protected override void Back2Fore()
	{
		if (this.ViewProxy == null)
		{
			base.OpenView(EUiViewName.SurvivorsRogueShopView, false);
		}
	}

	// Token: 0x06015FB7 RID: 90039 RVA: 0x00619F7C File Offset: 0x0061817C
	protected override void Fore2Back()
	{
	}

	// Token: 0x06015FB8 RID: 90040 RVA: 0x00619F7E File Offset: 0x0061817E
	protected override void OnStartExecute()
	{
		base.OpenView(EUiViewName.SurvivorsRogueShopView, false);
	}

	// Token: 0x06015FB9 RID: 90041 RVA: 0x00619F8C File Offset: 0x0061818C
	protected override void OnExecute()
	{
	}

	// Token: 0x06015FBA RID: 90042 RVA: 0x00619F8E File Offset: 0x0061818E
	protected override void OnFinish()
	{
		base.RequestCommand(new int[]
		{
			-2
		}, null);
	}

	// Token: 0x06015FBB RID: 90043 RVA: 0x00619FA2 File Offset: 0x006181A2
	protected override void OnDelete()
	{
	}

	// Token: 0x06015FBC RID: 90044 RVA: 0x00619FA4 File Offset: 0x006181A4
	[NullableContext(2)]
	public void RequestLock(int dataIncId, bool isLock, Action<bool> callback = null)
	{
		if (!this.InForeground)
		{
			return;
		}
		if (base.IsFinished)
		{
			return;
		}
		ControllerBase<SurvivorsRogueController>.Instance.RequestDataLock(this.IncId, dataIncId, isLock, delegate(bool success)
		{
			Action<bool> callback2 = callback;
			if (callback2 != null)
			{
				callback2(success);
			}
			if (!success)
			{
				return;
			}
			if (isLock)
			{
				ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsCard_LockTips", Array.Empty<object>());
				return;
			}
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByTextId("SurvivorsCard_UnLockTips", Array.Empty<object>());
		});
	}

	// Token: 0x06015FBD RID: 90045 RVA: 0x00619FFC File Offset: 0x006181FC
	[NullableContext(2)]
	public ISurvivorsShopViewInfo GetViewInfo()
	{
		SurvivorsOption shopData = this.GetShopData();
		return new SurvivorsShopViewInfo
		{
			DataList = shopData.GoodsDetails.ToList<GoodsDetail>(),
			RefreshItemId = shopData.RefreshItem,
			RefreshCost = shopData.RefreshCost
		};
	}

	// Token: 0x06015FBE RID: 90046 RVA: 0x0061A040 File Offset: 0x00618240
	public bool IsShopPurchaseAvailable()
	{
		int currencyCount = ModelBase<SurvivorsRogueModel>.Instance.BattleData.GetCurrencyCount();
		foreach (GoodsDetail goodsDetail in this.GetShopData().GoodsDetails)
		{
			if (!goodsDetail.IsSell && goodsDetail.CurPrice <= currencyCount)
			{
				return true;
			}
		}
		return false;
	}
}
