using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.SkipInterface;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Fishing
{
	// Token: 0x0200681A RID: 26650
	public class FishingHandBookRewardItem : GridProxyAbstract<int>
	{
		// Token: 0x060426BE RID: 272062 RVA: 0x011076A8 File Offset: 0x011058A8
		protected unsafe override void OnRegisterComponent()
		{
			int num = 8;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(7, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRewardBtn));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickJumpToBtn));
			this.BtnBindInfo = list2;
		}

		// Token: 0x060426BF RID: 272063 RVA: 0x01107837 File Offset: 0x01105A37
		protected override void OnStart()
		{
			base.GetItem(2).SetUIActive(false);
			this.RewardScrollView = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(6), new Func<CommonItemSmallItemGrid>(this.OnRewardLayoutUpdater), null, false, null);
		}

		// Token: 0x060426C0 RID: 272064 RVA: 0x01107867 File Offset: 0x01105A67
		[NullableContext(1)]
		private CommonItemSmallItemGrid OnRewardLayoutUpdater()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x060426C1 RID: 272065 RVA: 0x01107870 File Offset: 0x01105A70
		public override void Refresh(int data, bool isSelected, int gridIndex)
		{
			this.RewardId = data;
			IFishingReward fishingReward2;
			IFishingReward fishingReward = ModelBase<FishingModel>.Instance.FishingItemHandBookRewardMap.TryGetValue(this.RewardId, out fishingReward2) ? fishingReward2 : null;
			UUIItem item = base.GetItem(3);
			if (item != null)
			{
				item.SetUIActive(false);
			}
			UUIButtonComponent button = base.GetButton(0);
			if (button != null)
			{
				button.RootUIComp.Get().SetUIActive(false);
			}
			UUIButtonComponent button2 = base.GetButton(1);
			if (button2 != null)
			{
				button2.RootUIComp.Get().SetUIActive(false);
			}
			if (fishingReward != null && fishingReward.IsTaken)
			{
				UUIItem item2 = base.GetItem(3);
				if (item2 != null)
				{
					item2.SetUIActive(true);
				}
				base.GetItem(7).SetAlpha(0.6f);
			}
			else if (fishingReward != null && fishingReward.IsFinished)
			{
				UUIButtonComponent button3 = base.GetButton(0);
				if (button3 != null)
				{
					button3.RootUIComp.Get().SetUIActive(true);
				}
				base.GetItem(7).SetAlpha(1f);
			}
			else
			{
				UUIButtonComponent button4 = base.GetButton(1);
				if (button4 != null)
				{
					button4.RootUIComp.Get().SetUIActive(true);
				}
				base.GetItem(7).SetAlpha(1f);
			}
			UUIText text = base.GetText(5);
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
			defaultInterpolatedStringHandler.AppendFormatted<int?>((fishingReward != null) ? new int?(fishingReward.Current) : null);
			defaultInterpolatedStringHandler.AppendLiteral("/");
			defaultInterpolatedStringHandler.AppendFormatted<int?>((fishingReward != null) ? new int?(fishingReward.Target) : null);
			text.SetText(defaultInterpolatedStringHandler.ToStringAndClear(), true);
			FishingIllustratedReward fishingIllustratedRewardById = ConfigBase<FishingConfig>.Instance.GetFishingIllustratedRewardById(this.RewardId);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(4), fishingIllustratedRewardById.Desc, Array.Empty<object>());
			Dictionary<int, int> dropShowInfo = ConfigBase<AdventureGuideConfig>.Instance.GetDropShowInfo(fishingIllustratedRewardById.DropId);
			List<TItem> list = new List<TItem>();
			foreach (int num in dropShowInfo.Keys)
			{
				TItem item3 = new TItem(new InventoryDefine.GetItemData(num, 0), dropShowInfo[num]);
				list.Add(item3);
			}
			GenericScrollViewNew<CommonItemSmallItemGrid, TItem> rewardScrollView = this.RewardScrollView;
			if (rewardScrollView == null)
			{
				return;
			}
			rewardScrollView.RefreshByData(list, null, false);
		}

		// Token: 0x060426C2 RID: 272066 RVA: 0x01107AC0 File Offset: 0x01105CC0
		private void OnClickRewardBtn()
		{
			List<int> list = (from v in ModelBase<FishingModel>.Instance.FishingItemHandBookRewardMap.Values
			where v.IsFinished && !v.IsTaken
			select v.Id).ToList<int>();
			ControllerBase<FishingController>.Instance.RequestMultiFishingIllustratedRewardRequest(list.ToArray());
		}

		// Token: 0x060426C3 RID: 272067 RVA: 0x01107B3C File Offset: 0x01105D3C
		private void OnClickJumpToBtn()
		{
			SkipTaskManager.RunByConfigId(ConfigBase<FishingConfig>.Instance.GetFishingIllustratedRewardById(this.RewardId).AccessPath, null);
		}

		// Token: 0x04024FAE RID: 151470
		private const float TAKEN_ALPHA = 0.6f;

		// Token: 0x04024FAF RID: 151471
		private int RewardId;

		// Token: 0x04024FB0 RID: 151472
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScrollView;

		// Token: 0x0200C84F RID: 51279
		private class EComponentDefine
		{
			// Token: 0x0403DA46 RID: 252486
			public const int RewardBtn = 0;

			// Token: 0x0403DA47 RID: 252487
			public const int JumpToBtn = 1;

			// Token: 0x0403DA48 RID: 252488
			public const int DoingItem = 2;

			// Token: 0x0403DA49 RID: 252489
			public const int FinishItem = 3;

			// Token: 0x0403DA4A RID: 252490
			public const int TitleText = 4;

			// Token: 0x0403DA4B RID: 252491
			public const int CountText = 5;

			// Token: 0x0403DA4C RID: 252492
			public const int ItemScrollView = 6;

			// Token: 0x0403DA4D RID: 252493
			public const int EmptyItem = 7;
		}
	}
}
