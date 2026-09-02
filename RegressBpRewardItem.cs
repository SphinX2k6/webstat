using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

// Token: 0x02001538 RID: 5432
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
internal class RegressBpRewardItem : GridProxyAbstract<ActivityRegressTaskScoreRewardGridData>
{
	// Token: 0x0600984D RID: 38989 RVA: 0x0027DDC8 File Offset: 0x0027BFC8
	protected override void OnRegisterComponent()
	{
		this.ComponentRegisterInfos = new List<ValueTuple<int, Type>>
		{
			new ValueTuple<int, Type>(0, typeof(UUIText)),
			new ValueTuple<int, Type>(1, typeof(UUIItem)),
			new ValueTuple<int, Type>(2, typeof(UUIItem)),
			new ValueTuple<int, Type>(3, typeof(UUIItem))
		};
	}

	// Token: 0x0600984E RID: 38990 RVA: 0x0027DE38 File Offset: 0x0027C038
	protected override void OnStart()
	{
		SmallItemGrid smallItemGrid = new SmallItemGrid();
		SmallItemGrid smallItemGrid2 = new SmallItemGrid();
		SmallItemGrid smallItemGrid3 = new SmallItemGrid();
		smallItemGrid.Initialize(base.GetItem(1).GetOwner());
		smallItemGrid2.Initialize(base.GetItem(2).GetOwner());
		smallItemGrid3.Initialize(base.GetItem(3).GetOwner());
		this.ItemGrids = new List<SmallItemGrid>
		{
			smallItemGrid,
			smallItemGrid2,
			smallItemGrid3
		};
		for (int i = 0; i < this.ItemGrids.Count; i++)
		{
			int idx = i;
			this.ItemGrids[idx].BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			this.ItemGrids[idx].BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
			{
				this.OnExtendToggleClicked(idx);
			});
		}
	}

	// Token: 0x0600984F RID: 38991 RVA: 0x0027DF38 File Offset: 0x0027C138
	private void OnExtendToggleClicked(int index)
	{
		IRegressRewardItemInfo regressRewardItemInfo = (this.RewardDataList.Count > index) ? this.RewardDataList[index] : default(IRegressRewardItemInfo);
		if (regressRewardItemInfo.ItemInfo == null)
		{
			return;
		}
		if (regressRewardItemInfo.RewardState == ERegressRewardState.Reached)
		{
			ControllerBase<ActivityRegressController>.Instance.RequestAllTaskScoreRewards();
			return;
		}
		int id = regressRewardItemInfo.ItemInfo.Value.Id;
		ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(id, true, null);
	}

	// Token: 0x06009850 RID: 38992 RVA: 0x0027DFB8 File Offset: 0x0027C1B8
	public override void Refresh(ActivityRegressTaskScoreRewardGridData data, bool isSelected, int gridIndex)
	{
		UUIText text = base.GetText(0);
		if (text != null)
		{
			text.SetText((gridIndex + 1).ToString(), true);
		}
		int drop = data.Config.Value.Drop;
		DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(drop);
		List<IRegressRewardItemInfo> list = new List<IRegressRewardItemInfo>();
		if (dropPackage != null && dropPackage.Value.DropPreviewLength > 0)
		{
			DropPackage value = dropPackage.Value;
			for (int i = 0; i < value.DropPreviewLength; i++)
			{
				DicIntInt? dicIntInt = value.DropPreview(i);
				if (dicIntInt != null)
				{
					int key = dicIntInt.Value.Key;
					int value2 = dicIntInt.Value.Value;
					ItemInfo? config = ConfigBase<ItemConfig>.Instance.GetConfig(key);
					if (config != null)
					{
						list.Add(new IRegressRewardItemInfo
						{
							ItemInfo = new ItemInfo?(config.Value),
							ItemCount = value2,
							RewardState = data.RewardState
						});
						break;
					}
				}
			}
		}
		int payDrop = data.Config.Value.PayDrop;
		dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(payDrop);
		if (dropPackage != null && dropPackage.Value.DropPreviewLength > 0)
		{
			DropPackage value3 = dropPackage.Value;
			for (int j = 0; j < value3.DropPreviewLength; j++)
			{
				DicIntInt? dicIntInt2 = value3.DropPreview(j);
				if (dicIntInt2 != null)
				{
					int key2 = dicIntInt2.Value.Key;
					int value4 = dicIntInt2.Value.Value;
					ItemInfo? config2 = ConfigBase<ItemConfig>.Instance.GetConfig(key2);
					if (config2 != null)
					{
						list.Add(new IRegressRewardItemInfo
						{
							ItemInfo = new ItemInfo?(config2.Value),
							ItemCount = value4,
							RewardState = data.PayRewardState
						});
					}
				}
			}
		}
		for (int k = 0; k < this.ItemGrids.Count; k++)
		{
			if (list.Count > k)
			{
				ActivityRegressHelper.RefreshItemGridByData(this.ItemGrids[k], list[k]);
				this.ItemGrids[k].SetUiActive(true);
			}
			else
			{
				this.ItemGrids[k].SetUiActive(false);
			}
		}
		this.RewardDataList = list;
	}

	// Token: 0x04004688 RID: 18056
	private List<IRegressRewardItemInfo> RewardDataList = new List<IRegressRewardItemInfo>();

	// Token: 0x04004689 RID: 18057
	private List<SmallItemGrid> ItemGrids = new List<SmallItemGrid>();
}
