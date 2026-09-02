using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Common.MediumItemGrid;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.NewbieMain
{
	// Token: 0x0200664C RID: 26188
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class NewbieMainRewardItem : GridProxyAbstract<NewbieMainRewardItemData>
	{
		// Token: 0x06041635 RID: 267829 RVA: 0x010C5F68 File Offset: 0x010C4168
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUISprite));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041636 RID: 267830 RVA: 0x010C6014 File Offset: 0x010C4214
		protected override void OnStart()
		{
			this.RewardGrid = new SmallItemGrid();
			this.RewardGrid.BindOnExtendToggleClicked(delegate(MediumItemGridExtendCallback _)
			{
				this.OnClickGrid();
			});
			this.RewardGrid.BindOnCanExecuteChange((object _1, bool _2, EToggleState _3) => false);
			this.RewardGrid.CreateThenShowByActor(base.GetItem(2).GetOwner(), null);
		}

		// Token: 0x06041637 RID: 267831 RVA: 0x010C6085 File Offset: 0x010C4285
		public void SetClickCallback(Action<NewbieMainRewardItemData> callback)
		{
			this.ClickCallback = callback;
		}

		// Token: 0x06041638 RID: 267832 RVA: 0x010C6090 File Offset: 0x010C4290
		public override void Refresh(NewbieMainRewardItemData data, bool isSelected, int gridIndex)
		{
			this.RewardData = data;
			UUIText text = base.GetText(3);
			if (text != null)
			{
				text.SetText(data.Score.ToString(), true);
			}
			this.RefreshRewardGrid(data);
			float fillAmount = (data.State == ENewbieScoreRewardState.UnAchieved) ? 0f : 1f;
			UUISprite sprite = base.GetSprite(1);
			if (sprite == null)
			{
				return;
			}
			sprite.SetFillAmount(fillAmount);
		}

		// Token: 0x06041639 RID: 267833 RVA: 0x010C60F0 File Offset: 0x010C42F0
		private void RefreshRewardGrid(NewbieMainRewardItemData data)
		{
			if (this.RewardGrid == null || data.PreviewReward == null)
			{
				return;
			}
			TItem value = data.PreviewReward.Value;
			bool value2 = data.State == ENewbieScoreRewardState.Claimable;
			bool value3 = data.State == ENewbieScoreRewardState.Claimed;
			PropSmallItemGrid propSmallItemGrid = new PropSmallItemGrid();
			propSmallItemGrid.Data = value;
			propSmallItemGrid.ItemConfigId = new int?(value.ItemData.ItemId);
			string bottomText;
			if (value.Count <= 0)
			{
				bottomText = "";
			}
			else
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
				defaultInterpolatedStringHandler.AppendFormatted<int>(value.Count);
				bottomText = defaultInterpolatedStringHandler.ToStringAndClear();
			}
			propSmallItemGrid.BottomText = bottomText;
			propSmallItemGrid.IsReceivableVisible = new bool?(value2);
			propSmallItemGrid.IsReceivedVisible = new bool?(value3);
			propSmallItemGrid.IsRedDotVisible = new bool?(value2);
			PropSmallItemGrid parameters = propSmallItemGrid;
			this.RewardGrid.ApplyPropSmallItemGrid(parameters);
		}

		// Token: 0x0604163A RID: 267834 RVA: 0x010C61BE File Offset: 0x010C43BE
		private void OnClickGrid()
		{
			if (this.RewardData != null)
			{
				Action<NewbieMainRewardItemData> clickCallback = this.ClickCallback;
				if (clickCallback == null)
				{
					return;
				}
				clickCallback(this.RewardData);
			}
		}

		// Token: 0x0402491C RID: 149788
		[Nullable(2)]
		private NewbieMainRewardItemData RewardData;

		// Token: 0x0402491D RID: 149789
		[Nullable(2)]
		private SmallItemGrid RewardGrid;

		// Token: 0x0402491E RID: 149790
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private Action<NewbieMainRewardItemData> ClickCallback;

		// Token: 0x0200C667 RID: 50791
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403D149 RID: 250185
			public const int BarItem = 0;

			// Token: 0x0403D14A RID: 250186
			public const int BarSprite = 1;

			// Token: 0x0403D14B RID: 250187
			public const int RewardGridItem = 2;

			// Token: 0x0403D14C RID: 250188
			public const int NeedCountText = 3;
		}
	}
}
