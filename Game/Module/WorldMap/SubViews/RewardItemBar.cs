using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Aki.Config;
using CSharpScript.Game.Module.Map.MapDefine;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews
{
	// Token: 0x02004B5A RID: 19290
	[NullableContext(1)]
	[Nullable(0)]
	public class RewardItemBar : UiPanelBase
	{
		// Token: 0x06032632 RID: 206386 RVA: 0x00C9C128 File Offset: 0x00C9A328
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032633 RID: 206387 RVA: 0x00C9C1B4 File Offset: 0x00C9A3B4
		protected override void OnStart()
		{
			this.RewardLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetGridLayout(1), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, true);
			UUIText text = base.GetText(0);
			if (text == null)
			{
				return;
			}
			text.SetText(ConfigMultiTextLang.GetLocalTextNew("PassReward", null) ?? "", true);
		}

		// Token: 0x06032634 RID: 206388 RVA: 0x00C9C208 File Offset: 0x00C9A408
		private CommonItemSmallItemGrid CreatePropItem()
		{
			return new CommonItemSmallItemGrid
			{
				ShowReceivedCallBack = ((TItem data) => this.FinishReward)
			};
		}

		// Token: 0x06032635 RID: 206389 RVA: 0x00C9C221 File Offset: 0x00C9A421
		[NullableContext(2)]
		public void RebuildRewardsByData(List<TItem> data = null)
		{
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByData(data ?? new List<TItem>(), null, false);
		}

		// Token: 0x06032636 RID: 206390 RVA: 0x00C9C23F File Offset: 0x00C9A43F
		public void RebuildRewardsByLevelRewardData(CommonLevelPlayPanelRewardData data)
		{
			this.FinishReward = data.FinishRecord;
			GenericLayout<CommonItemSmallItemGrid, TItem> rewardLayout = this.RewardLayout;
			if (rewardLayout == null)
			{
				return;
			}
			rewardLayout.RefreshByData(data.ItemList, null, false);
		}

		// Token: 0x06032637 RID: 206391 RVA: 0x00C9C265 File Offset: 0x00C9A465
		public void SetTitleNewTxt(string newTxtId)
		{
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), newTxtId, Array.Empty<object>());
		}

		// Token: 0x0401D6AA RID: 120490
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> RewardLayout;

		// Token: 0x0401D6AB RID: 120491
		private bool FinishReward;

		// Token: 0x0200AC29 RID: 44073
		[NullableContext(0)]
		public static class ERewardItemBarChildCom
		{
			// Token: 0x040358B2 RID: 219314
			public const int UiTextInstanceTitle = 0;

			// Token: 0x040358B3 RID: 219315
			public const int UiItemContainer = 1;

			// Token: 0x040358B4 RID: 219316
			public const int UiItemItem = 2;
		}
	}
}
