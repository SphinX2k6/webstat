using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.InstanceDungeon
{
	// Token: 0x02005BBD RID: 23485
	public class InstanceDungeonEntranceTowerDefenceItem : UiPanelBase
	{
		// Token: 0x0603B709 RID: 243465 RVA: 0x00F10B0C File Offset: 0x00F0ED0C
		protected unsafe override void OnRegisterComponent()
		{
			int num = 6;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIScrollViewWithScrollbarComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(4, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(5, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603B70A RID: 243466 RVA: 0x00F10BFC File Offset: 0x00F0EDFC
		protected override void OnStart()
		{
			this.PhantomScroll = new GenericScrollViewNew<CommonItemSmallItemGrid, TItem>(base.GetScrollViewWithScrollbar(0), new Func<CommonItemSmallItemGrid>(this.CreatePropItem), null, false, null);
			base.GetItem(3).SetUIActive(false);
			base.GetItem(5).SetUIActive(false);
			base.SetButtonUiActive(1, false);
			if (this.ItemDataHandle != null)
			{
				this.RefreshItem(this.ItemDataHandle.Data);
			}
			Singleton<LguiUtil>.Instance.SetLocalTextNew(base.GetText(2), "TowerDefence_Vison", Array.Empty<object>());
		}

		// Token: 0x0603B70B RID: 243467 RVA: 0x00F10C80 File Offset: 0x00F0EE80
		[NullableContext(1)]
		private CommonItemSmallItemGrid CreatePropItem()
		{
			return new CommonItemSmallItemGrid();
		}

		// Token: 0x0603B70C RID: 243468 RVA: 0x00F10C87 File Offset: 0x00F0EE87
		[NullableContext(1)]
		public void RefreshItem(List<TItem> data)
		{
			if (base.InAsyncLoading())
			{
				this.ItemDataHandle = new InstanceDungeonEntranceTowerDefenceItemData
				{
					Data = data
				};
				return;
			}
			this.PhantomScroll.RefreshByData(data, delegate
			{
				foreach (CommonItemSmallItemGrid commonItemSmallItemGrid in this.PhantomScroll.GetScrollItemList())
				{
					commonItemSmallItemGrid.SetQuality(null);
					commonItemSmallItemGrid.SetAllowClickBack(false);
				}
			}, false);
		}

		// Token: 0x040217E7 RID: 137191
		[Nullable(2)]
		private InstanceDungeonEntranceTowerDefenceItemData ItemDataHandle;

		// Token: 0x040217E8 RID: 137192
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericScrollViewNew<CommonItemSmallItemGrid, TItem> PhantomScroll;

		// Token: 0x0200BC11 RID: 48145
		private enum EComponent
		{
			// Token: 0x0403A02D RID: 237613
			PhantomScroll,
			// Token: 0x0403A02E RID: 237614
			HelpButton,
			// Token: 0x0403A02F RID: 237615
			TitleText,
			// Token: 0x0403A030 RID: 237616
			SubTitleItem,
			// Token: 0x0403A031 RID: 237617
			SubTitleNumText,
			// Token: 0x0403A032 RID: 237618
			UpItem
		}
	}
}
