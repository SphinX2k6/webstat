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

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200678C RID: 26508
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class FishingRewardProgressItem : GridProxyAbstract<FishingRewardProgressData>
	{
		// Token: 0x06042138 RID: 270648 RVA: 0x010F3E4C File Offset: 0x010F204C
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

		// Token: 0x06042139 RID: 270649 RVA: 0x010F3ED8 File Offset: 0x010F20D8
		protected override void OnStart()
		{
			this.RewardItemGrid = new SmallItemGrid();
			this.RewardItemGrid.Initialize(base.GetItem(2).GetOwner());
			this.RewardItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			this.RewardItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedGrid));
		}

		// Token: 0x0604213A RID: 270650 RVA: 0x010F3F48 File Offset: 0x010F2148
		public override void Refresh(FishingRewardProgressData data, bool isSelected, int gridIndex)
		{
			this.Data = data;
			FishingActivityMilestone? fishingActivityMilestone = ConfigBase<FishingConfig>.Instance.GetFishingActivityMilestone(data.Id);
			base.GetText(1).SetText(fishingActivityMilestone.Value.ItemNum.ToString(), true);
			UUIItem sprite = base.GetSprite(0);
			bool bUseChangeColor = data.IsFulfilled();
			FColor? fcolor = new FColor?(base.GetSprite(0).changeColor);
			sprite.SetChangeColor(bUseChangeColor, fcolor);
			this.RewardItem = new TItem?(ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(fishingActivityMilestone.Value.DropId)[0]);
			this.RefreshGrid();
		}

		// Token: 0x0604213B RID: 270651 RVA: 0x010F3FE8 File Offset: 0x010F21E8
		private void RefreshGrid()
		{
			bool lockBlackVisible = !this.Data.IsFulfilled();
			bool value = this.Data.IsDone();
			bool value2 = this.Data.IsReceivable();
			PropSmallItemGrid parameters = new PropSmallItemGrid
			{
				Data = this.Data,
				ItemConfigId = new int?(this.RewardItem.Value.ItemData.ItemId),
				BottomText = this.RewardItem.Value.Count.ToString(),
				IsReceivableVisible = new bool?(value2),
				IsReceivedVisible = new bool?(value),
				IsRedDotVisible = new bool?(value2)
			};
			this.RewardItemGrid.Apply<PropSmallItemGrid>(parameters);
			this.RewardItemGrid.SetLockBlackVisible(lockBlackVisible);
		}

		// Token: 0x0604213C RID: 270652 RVA: 0x010F40AC File Offset: 0x010F22AC
		private void OnClickedGrid(MediumItemGridExtendCallback callback)
		{
			if (!this.Data.IsReceivable())
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(this.RewardItem.Value.ItemData.ItemId, true, null);
				return;
			}
			Action onClickToGet = this.OnClickToGet;
			if (onClickToGet == null)
			{
				return;
			}
			onClickToGet();
		}

		// Token: 0x04024D5D RID: 150877
		private FishingRewardProgressData Data;

		// Token: 0x04024D5E RID: 150878
		[Nullable(2)]
		private SmallItemGrid RewardItemGrid;

		// Token: 0x04024D5F RID: 150879
		private TItem? RewardItem;

		// Token: 0x04024D60 RID: 150880
		[Nullable(2)]
		public Action OnClickToGet;

		// Token: 0x0200C7A9 RID: 51113
		[NullableContext(0)]
		private class EItemComponent
		{
			// Token: 0x0403D781 RID: 251777
			public const int SpriteBg = 0;

			// Token: 0x0403D782 RID: 251778
			public const int TxtGoal = 1;

			// Token: 0x0403D783 RID: 251779
			public const int RewardItem = 2;
		}
	}
}
