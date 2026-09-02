using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Item;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.ItemReward
{
	// Token: 0x02005B44 RID: 23364
	[NullableContext(1)]
	[Nullable(0)]
	public class BattlePassExtraRewardView : UiViewBase
	{
		// Token: 0x0603B184 RID: 242052 RVA: 0x00EF3C28 File Offset: 0x00EF1E28
		public BattlePassExtraRewardView(UiViewInfo info) : base(info)
		{
		}

		// Token: 0x0603B185 RID: 242053 RVA: 0x00EF3C34 File Offset: 0x00EF1E34
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIText));
			this.ComponentRegisterInfos = list;
			num2 = 2;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.OnClickRight));
			num++;
			*span2[num] = new ValueTuple<int, Delegate>(1, new Action(this.OnClickLeft));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603B186 RID: 242054 RVA: 0x00EF3DA4 File Offset: 0x00EF1FA4
		protected override UniTask OnBeforeStartAsync()
		{
			BattlePassExtraRewardView.<OnBeforeStartAsync>d__7 <OnBeforeStartAsync>d__;
			<OnBeforeStartAsync>d__.<>t__builder = AsyncUniTaskMethodBuilder.Create();
			<OnBeforeStartAsync>d__.<>4__this = this;
			<OnBeforeStartAsync>d__.<>1__state = -1;
			<OnBeforeStartAsync>d__.<>t__builder.Start<BattlePassExtraRewardView.<OnBeforeStartAsync>d__7>(ref <OnBeforeStartAsync>d__);
			return <OnBeforeStartAsync>d__.<>t__builder.Task;
		}

		// Token: 0x0603B187 RID: 242055 RVA: 0x00EF3DE8 File Offset: 0x00EF1FE8
		protected override void OnStart()
		{
			this.CommonScroll = new GenericScrollViewNew<RewardSmallItemGrid, RewardItemData>(base.GetScrollViewWithScrollbar(2), new Func<RewardSmallItemGrid>(this.OnCreateRewardItem), null, false, null);
			this.ExtraScroll = new GenericScrollViewNew<RewardSmallItemGrid, RewardItemData>(base.GetScrollViewWithScrollbar(4), new Func<RewardSmallItemGrid>(this.OnCreateRewardItem), null, false, null);
			this.Refresh();
		}

		// Token: 0x0603B188 RID: 242056 RVA: 0x00EF3E3D File Offset: 0x00EF203D
		protected override void OnBeforeDestroy()
		{
			this.SelectedItemGrid = null;
			this.CommonScroll = null;
			this.ExtraScroll = null;
		}

		// Token: 0x0603B189 RID: 242057 RVA: 0x00EF3E54 File Offset: 0x00EF2054
		private void Refresh()
		{
			RewardData<IBattlePassExtraRewardInfo> dataCache = this.DataCache;
			List<RewardItemData> list = (dataCache != null) ? dataCache.GetRewardInfo().CommonItems : null;
			if (list != null)
			{
				list.Sort(new Comparison<RewardItemData>(this.SortCompare));
				GenericScrollViewNew<RewardSmallItemGrid, RewardItemData> commonScroll = this.CommonScroll;
				if (commonScroll != null)
				{
					commonScroll.RefreshByData(list, null, false);
				}
			}
			RewardData<IBattlePassExtraRewardInfo> dataCache2 = this.DataCache;
			List<RewardItemData> list2 = (dataCache2 != null) ? dataCache2.GetRewardInfo().ExtraItems : null;
			if (list2 != null)
			{
				list2.Sort(new Comparison<RewardItemData>(this.SortCompare));
				GenericScrollViewNew<RewardSmallItemGrid, RewardItemData> extraScroll = this.ExtraScroll;
				if (extraScroll != null)
				{
					extraScroll.RefreshByData(list2, null, false);
				}
			}
			RewardData<IBattlePassExtraRewardInfo> dataCache3 = this.DataCache;
			string text = (dataCache3 != null) ? dataCache3.GetRewardInfo().TipsTextId : null;
			if (text != null)
			{
				UUIText text2 = base.GetText(6);
				if (text2 == null)
				{
					return;
				}
				text2.ShowTextNew(text);
			}
		}

		// Token: 0x0603B18A RID: 242058 RVA: 0x00EF3F10 File Offset: 0x00EF2110
		private int SortCompare(RewardItemData aRewardItem, RewardItemData bRewardItem)
		{
			EDropItemType dropItemType = aRewardItem.GetDropItemType();
			EDropItemType dropItemType2 = bRewardItem.GetDropItemType();
			if (dropItemType != dropItemType2)
			{
				return dropItemType2 - dropItemType;
			}
			int typeSortIndex = aRewardItem.GetTypeSortIndex();
			int typeSortIndex2 = bRewardItem.GetTypeSortIndex();
			if (typeSortIndex != typeSortIndex2)
			{
				return typeSortIndex2 - typeSortIndex;
			}
			int qualityId = aRewardItem.GetQualityId();
			int qualityId2 = bRewardItem.GetQualityId();
			if (qualityId != qualityId2)
			{
				return qualityId2 - qualityId;
			}
			return aRewardItem.ConfigId - bRewardItem.ConfigId;
		}

		// Token: 0x0603B18B RID: 242059 RVA: 0x00EF3F72 File Offset: 0x00EF2172
		private RewardSmallItemGrid OnCreateRewardItem()
		{
			RewardSmallItemGrid rewardSmallItemGrid = new RewardSmallItemGrid();
			rewardSmallItemGrid.BindOnCanExecuteChange((object _, bool _, EToggleState _) => false);
			rewardSmallItemGrid.BindOnExtendToggleClicked(new Action<MediumItemGridExtendCallback>(this.OnClickedRewardItem));
			return rewardSmallItemGrid;
		}

		// Token: 0x0603B18C RID: 242060 RVA: 0x00EF3FB0 File Offset: 0x00EF21B0
		private void OnClickedRewardItem(MediumItemGridExtendCallback callbackParameter)
		{
			ItemGridBase selectedItemGrid = this.SelectedItemGrid;
			if (selectedItemGrid != null)
			{
				selectedItemGrid.SetSelected(false, true);
			}
			this.SelectedItemGrid = callbackParameter.MediumItemGrid;
			RewardItemData rewardItemData = callbackParameter.Data as RewardItemData;
			int configId = rewardItemData.ConfigId;
			int uniqueId = rewardItemData.UniqueId;
			if (uniqueId > 0)
			{
				ControllerBase<ItemController>.Instance.OpenItemTipsByItemUid(uniqueId, configId, true, null);
				return;
			}
			ControllerBase<ItemController>.Instance.OpenItemTipsByItemId(configId, true, null);
		}

		// Token: 0x0603B18D RID: 242061 RVA: 0x00EF4014 File Offset: 0x00EF2214
		private void OnClickRight()
		{
			base.CloseMe(null);
			RewardData<IBattlePassExtraRewardInfo> dataCache = this.DataCache;
			if (dataCache == null)
			{
				return;
			}
			dataCache.GetRewardInfo().RightAction();
		}

		// Token: 0x0603B18E RID: 242062 RVA: 0x00EF4037 File Offset: 0x00EF2237
		private void OnClickLeft()
		{
			base.CloseMe(null);
			RewardData<IBattlePassExtraRewardInfo> dataCache = this.DataCache;
			if (dataCache == null)
			{
				return;
			}
			dataCache.GetRewardInfo().LeftAction();
		}

		// Token: 0x04021548 RID: 136520
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private RewardData<IBattlePassExtraRewardInfo> DataCache;

		// Token: 0x04021549 RID: 136521
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RewardSmallItemGrid, RewardItemData> CommonScroll;

		// Token: 0x0402154A RID: 136522
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private GenericScrollViewNew<RewardSmallItemGrid, RewardItemData> ExtraScroll;

		// Token: 0x0402154B RID: 136523
		[Nullable(2)]
		private ItemGridBase SelectedItemGrid;

		// Token: 0x0200BB2A RID: 47914
		[NullableContext(0)]
		private class EComponent
		{
			// Token: 0x04039C2E RID: 236590
			public const int RightButton = 0;

			// Token: 0x04039C2F RID: 236591
			public const int LeftButton = 1;

			// Token: 0x04039C30 RID: 236592
			public const int UpScroll = 2;

			// Token: 0x04039C31 RID: 236593
			public const int UpScrollItem = 3;

			// Token: 0x04039C32 RID: 236594
			public const int DownScroll = 4;

			// Token: 0x04039C33 RID: 236595
			public const int DownScrollItem = 5;

			// Token: 0x04039C34 RID: 236596
			public const int TxtTips = 6;
		}
	}
}
