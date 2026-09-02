using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x02006330 RID: 25392
	[NullableContext(2)]
	[Nullable(0)]
	public class GiftItem : GridProxyAbstract<int>
	{
		// Token: 0x0603FCA0 RID: 261280 RVA: 0x0105B2B0 File Offset: 0x010594B0
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603FCA1 RID: 261281 RVA: 0x0105B33C File Offset: 0x0105953C
		protected override void OnStart()
		{
			this.ItemGridGrid = new SmallItemGrid();
			this.ItemGridGrid.Initialize(base.GetItem(2).GetOwner());
			this.ItemGridGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			this.ItemGridGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
		}

		// Token: 0x0603FCA2 RID: 261282 RVA: 0x0105B3AC File Offset: 0x010595AC
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.ConfigId = data;
			SpringFestivalScoreReward? scoreRewardConfigById = ConfigBase<SpringManorConfig>.Instance.GetScoreRewardConfigById(data);
			base.GetText(1).SetText(scoreRewardConfigById.Value.Score.ToString(), true);
			bool uiactive = ModelBase<SpringManorModel>.Instance.ActivityData.GetCurrentMilestone() >= scoreRewardConfigById.Value.Score;
			base.GetSprite(0).SetUIActive(uiactive);
			List<TItem> dropPackagePreviewItemList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(scoreRewardConfigById.Value.DropId);
			this.ItemGrid = new TItem?(dropPackagePreviewItemList[0]);
			this.RefreshGrid(scoreRewardConfigById.Value);
		}

		// Token: 0x0603FCA3 RID: 261283 RVA: 0x0105B45C File Offset: 0x0105965C
		private void RefreshGrid(SpringFestivalScoreReward config)
		{
			SpringManorData activityData = ModelBase<SpringManorModel>.Instance.ActivityData;
			bool flag = activityData.IsScoreRewardCanReceived(config.Id);
			bool flag2 = activityData.IsScoreRewardReceived(config.Id);
			bool lockBlackVisible = !flag && !flag2;
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = config,
				ItemConfigId = new int?(this.ItemGrid.Value.ItemData.ItemId),
				BottomText = this.ItemGrid.Value.Count.ToString(),
				IsReceivableVisible = new bool?(flag),
				IsReceivedVisible = new bool?(flag2),
				IsRedDotVisible = new bool?(flag)
			};
			this.ItemGridGrid.Apply<PropSmallItemGrid>(parameters);
			this.ItemGridGrid.SetLockBlackVisible(lockBlackVisible);
		}

		// Token: 0x0603FCA4 RID: 261284 RVA: 0x0105B528 File Offset: 0x01059728
		[NullableContext(1)]
		private void OnClickedGrid(MediumItemGridExtendCallback _)
		{
			SpringFestivalScoreReward? scoreRewardConfigById = ConfigBase<SpringManorConfig>.Instance.GetScoreRewardConfigById(this.ConfigId);
			if (!ModelBase<SpringManorModel>.Instance.ActivityData.IsScoreRewardCanReceived(scoreRewardConfigById.Value.Id))
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.ItemGrid.Value.ItemData.ItemId, true, null);
				return;
			}
			SpringManorController instance = ControllerBase<SpringManorController>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.RequestScoreRewardReceive(this.ReceiveCallback);
		}

		// Token: 0x04023D1F RID: 146719
		private int ConfigId;

		// Token: 0x04023D20 RID: 146720
		private SmallItemGrid ItemGridGrid;

		// Token: 0x04023D21 RID: 146721
		private TItem? ItemGrid;

		// Token: 0x04023D22 RID: 146722
		public Action ReceiveCallback;
	}
}
