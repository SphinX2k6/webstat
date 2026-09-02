using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using UnrealEngine;

namespace CSharpScript.Game.Module.BossPiling.View
{
	// Token: 0x02005F01 RID: 24321
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class BossPilingRewardItem : GridProxyAbstract<ActivityRewardData>
	{
		// Token: 0x0603D18C RID: 250252 RVA: 0x00F848D4 File Offset: 0x00F82AD4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 7;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIHorizontalLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(6, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(4, new Action(this.OnClickButton));
			this.BtnBindInfo = list2;
		}

		// Token: 0x0603D18D RID: 250253 RVA: 0x00F84A1F File Offset: 0x00F82C1F
		protected override void OnStart()
		{
			this.ItemLayout = new GenericLayout<CommonItemSmallItemGrid, TItem>(base.GetHorizontalLayout(2), new Func<CommonItemSmallItemGrid>(this.InitGridItem), null, false, true);
		}

		// Token: 0x0603D18E RID: 250254 RVA: 0x00F84A42 File Offset: 0x00F82C42
		private CommonItemSmallItemGrid InitGridItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603D18F RID: 250255 RVA: 0x00F84A4C File Offset: 0x00F82C4C
		public override void Refresh(ActivityRewardData data, bool isSelected, int gridIndex)
		{
			this.RewardData = data;
			base.GetText(1).SetText(data.NameTextArgs[0] + "/" + data.NameTextArgs[1], true);
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(0), "BossPilingActivity_Reward08", new <>z__ReadOnlySingleElementList<object>(data.NameTextArgs[1]));
			base.GetButton(4).RootUIComp.Get().SetUIActive(data.RewardState == EActivityRewardState.Enable);
			UUIItem item = base.GetItem(5);
			if (item != null)
			{
				item.SetUIActive(data.RewardState == EActivityRewardState.Disabled);
			}
			UUIItem item2 = base.GetItem(6);
			if (item2 != null)
			{
				item2.SetUIActive(data.RewardState == EActivityRewardState.Claimed);
			}
			GenericLayout<CommonItemSmallItemGrid, TItem> itemLayout = this.ItemLayout;
			if (itemLayout == null)
			{
				return;
			}
			itemLayout.RefreshByData(data.RewardList ?? Array.Empty<TItem>(), null, false);
		}

		// Token: 0x0603D190 RID: 250256 RVA: 0x00F84B23 File Offset: 0x00F82D23
		private void OnClickButton()
		{
			ActivityRewardData rewardData = this.RewardData;
			if (rewardData == null)
			{
				return;
			}
			Action clickFunction = rewardData.ClickFunction;
			if (clickFunction == null)
			{
				return;
			}
			clickFunction();
		}

		// Token: 0x04022446 RID: 140358
		[Nullable(2)]
		private ActivityRewardData RewardData;

		// Token: 0x04022447 RID: 140359
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayout<CommonItemSmallItemGrid, TItem> ItemLayout;

		// Token: 0x0200BF03 RID: 48899
		[NullableContext(0)]
		private enum EReward
		{
			// Token: 0x0403AC9D RID: 240797
			NameText,
			// Token: 0x0403AC9E RID: 240798
			NumText,
			// Token: 0x0403AC9F RID: 240799
			RewardLayout,
			// Token: 0x0403ACA0 RID: 240800
			RewardItem,
			// Token: 0x0403ACA1 RID: 240801
			Button,
			// Token: 0x0403ACA2 RID: 240802
			DoingItem,
			// Token: 0x0403ACA3 RID: 240803
			ClaimedItem
		}
	}
}
