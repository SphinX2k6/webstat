using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x020012BD RID: 4797
public class CumulativeShopTaskItem : GridProxyAbstract<int>
{
	// Token: 0x060080D8 RID: 32984 RVA: 0x00220A88 File Offset: 0x0021EC88
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(1, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(0, typeof(UUIButtonComponent)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem)),
			new ValueTuple<int, Type>(4, typeof(UUIText)),
			new ValueTuple<int, Type>(5, typeof(UUIText)),
			new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent)),
			new ValueTuple<int, Type>(7, typeof(UUIItem)),
			new ValueTuple<int, Type>(8, typeof(UUIItem)),
			new ValueTuple<int, Type>(9, typeof(UUIText)),
			new ValueTuple<int, Type>(10, typeof(UUIItem)),
			new ValueTuple<int, Type>(11, typeof(UUIText))
		};
		this.BtnBindInfo = new List<ValueTuple<int, Delegate>>
		{
			new ValueTuple<int, Delegate>(1, new Action(this.OnClickGetBtn)),
			new ValueTuple<int, Delegate>(0, new Action(this.OnClickGotoBtn))
		};
	}

	// Token: 0x060080D9 RID: 32985 RVA: 0x00220BE6 File Offset: 0x0021EDE6
	protected override void OnStart()
	{
		base.GetItem(8).SetUIActive(false);
		this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
	}

	// Token: 0x060080DA RID: 32986 RVA: 0x00220C18 File Offset: 0x0021EE18
	public override void Refresh(int data, bool isSelected, int gridIndex)
	{
		this.TaskId = data;
		ConsumptiveTask? cumulativeShopTaskConfig = ConfigBase<CumulativeShopConfig>.Instance.GetCumulativeShopTaskConfig(this.TaskId);
		Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), cumulativeShopTaskConfig.Value.DesString, Array.Empty<object>());
		this.SkipId = cumulativeShopTaskConfig.Value.SkipId;
		CumulativeShopData cumulativeShopData = ControllerBase<CumulativeShopController>.Instance.GetCumulativeShopData();
		ConsumptiveTaskInfo consumptiveTaskInfo = cumulativeShopData.TaskDataMap[this.TaskId];
		int num = consumptiveTaskInfo.Process.Current;
		int target = consumptiveTaskInfo.Process.Target;
		base.GetText(5).SetText(num.ToString() + "/" + target.ToString(), true);
		int currencyId = cumulativeShopData.CurrencyId;
		List<TItem> data2 = new List<TItem>
		{
			new TItem(new InventoryDefine.GetItemData(currencyId, 0), cumulativeShopTaskConfig.Value.RewardScore)
		};
		GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
		if (rewardScrollView != null)
		{
			rewardScrollView.RefreshByData(data2, null, false);
		}
		int waitReward = consumptiveTaskInfo.Reward.WaitReward;
		int rewarded = consumptiveTaskInfo.Reward.Rewarded;
		int maxReward = consumptiveTaskInfo.Reward.MaxReward;
		if (waitReward > 0)
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(false);
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetButton(1).RootUIComp.Get().SetUIActive(true);
			base.GetItem(7).SetUIActive(true);
		}
		else if (maxReward > 0 && rewarded >= maxReward)
		{
			base.GetItem(2).SetUIActive(false);
			base.GetItem(3).SetUIActive(true);
			base.GetButton(0).RootUIComp.Get().SetUIActive(false);
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
		}
		else
		{
			bool flag = cumulativeShopTaskConfig.Value.SkipId > 0;
			base.GetItem(2).SetUIActive(!flag);
			base.GetItem(3).SetUIActive(false);
			base.GetButton(0).RootUIComp.Get().SetUIActive(flag);
			base.GetButton(1).RootUIComp.Get().SetUIActive(false);
			base.GetItem(7).SetUIActive(false);
		}
		if (cumulativeShopTaskConfig.Value.MaxFinishCount > 1)
		{
			base.GetItem(10).SetUIActive(true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(11), "LeiXiao_TaskNum", new <>z__ReadOnlyArray<object>(new object[]
			{
				rewarded,
				maxReward
			}));
			return;
		}
		base.GetItem(10).SetUIActive(false);
	}

	// Token: 0x060080DB RID: 32987 RVA: 0x00220EED File Offset: 0x0021F0ED
	[NullableContext(1)]
	private CommonItemSmallItemGrid CreatePropItem()
	{
		return new CommonItemSmallItemGrid();
	}

	// Token: 0x060080DC RID: 32988 RVA: 0x00220EF4 File Offset: 0x0021F0F4
	private void OnClickGetBtn()
	{
		ConsumptiveTask? cumulativeShopTaskConfig = ConfigBase<CumulativeShopConfig>.Instance.GetCumulativeShopTaskConfig(this.TaskId);
		if (cumulativeShopTaskConfig == null)
		{
			return;
		}
		ControllerBase<CumulativeShopController>.Instance.ConsumptiveRewardRequest(cumulativeShopTaskConfig.Value.TaskTab);
	}

	// Token: 0x060080DD RID: 32989 RVA: 0x00220F35 File Offset: 0x0021F135
	private void OnClickGotoBtn()
	{
		if (this.SkipId <= 0)
		{
			return;
		}
		SkipTaskManager.RunByConfigId(this.SkipId, null);
	}

	// Token: 0x04003D81 RID: 15745
	private int TaskId;

	// Token: 0x04003D82 RID: 15746
	private int SkipId;

	// Token: 0x04003D83 RID: 15747
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;
}
