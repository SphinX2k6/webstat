using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Pinball.View.Settlement
{
	// Token: 0x020065BF RID: 26047
	public class PinballSettleRewardView : UiPanelBase
	{
		// Token: 0x06041171 RID: 266609 RVA: 0x010B38F4 File Offset: 0x010B1AF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIScrollViewWithScrollbarComponent));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06041172 RID: 266610 RVA: 0x010B395D File Offset: 0x010B1B5D
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreateRewardItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x06041173 RID: 266611 RVA: 0x010B3964 File Offset: 0x010B1B64
		public void ShowRewardGot()
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(true);
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
			if (scrollViewWithScrollbar == null)
			{
				return;
			}
			scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(false);
		}

		// Token: 0x06041174 RID: 266612 RVA: 0x010B39A4 File Offset: 0x010B1BA4
		[NullableContext(1)]
		public void ShowRewardList(List<TItem> items)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetUIActive(false);
			}
			UUIScrollViewWithScrollbarComponent scrollViewWithScrollbar = base.GetScrollViewWithScrollbar(1);
			if (scrollViewWithScrollbar != null)
			{
				scrollViewWithScrollbar.RootUIComp.Get().SetUIActive(true);
			}
			this.RewardScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(1), new Func<CommonItemSmallItemGrid>(this.CreateRewardItem), null, false, null);
			this.RewardScroll.RefreshByData(items, null, false);
		}

		// Token: 0x0402477B RID: 149371
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> RewardScroll;

		// Token: 0x0200C5C4 RID: 50628
		private enum EComponent
		{
			// Token: 0x0403CDF5 RID: 249333
			TextRewardGot,
			// Token: 0x0403CDF6 RID: 249334
			ScrollReward
		}
	}
}
