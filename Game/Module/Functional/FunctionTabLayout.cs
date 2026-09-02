using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Module.Util.Layout;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Functional
{
	// Token: 0x02005D1F RID: 23839
	public class FunctionTabLayout : UiPanelBase
	{
		// Token: 0x0603C1C8 RID: 246216 RVA: 0x00F3E2F9 File Offset: 0x00F3C4F9
		[NullableContext(1)]
		public FunctionTabLayout(UUIItem uiItem)
		{
			base.CreateThenShowByActor(uiItem.GetOwner(), null);
		}

		// Token: 0x0603C1C9 RID: 246217 RVA: 0x00F3E318 File Offset: 0x00F3C518
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUILayoutBase));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603C1CA RID: 246218 RVA: 0x00F3E381 File Offset: 0x00F3C581
		protected override void OnStart()
		{
			this.TabLayout = new GenericLayoutNew<FunctionTabItem>(base.GetLayoutBase(0), new CSharpScript.Game.Module.Util.Layout.TLayoutRefresh<FunctionTabItem>(this.InitTabItem), base.GetItem(1));
		}

		// Token: 0x0603C1CB RID: 246219 RVA: 0x00F3E3A8 File Offset: 0x00F3C5A8
		[NullableContext(1)]
		private ILayoutItem<FunctionTabItem> InitTabItem(object data, UUIItem uiItem, int index)
		{
			FunctionTabItem value = new FunctionTabItem(uiItem);
			return new LayoutItem<FunctionTabItem>
			{
				Key = index,
				Value = value
			};
		}

		// Token: 0x0603C1CC RID: 246220 RVA: 0x00F3E3D4 File Offset: 0x00F3C5D4
		protected override void OnBeforeDestroy()
		{
			this.TabLayout.ClearChildren();
		}

		// Token: 0x0603C1CD RID: 246221 RVA: 0x00F3E3E1 File Offset: 0x00F3C5E1
		public void RefreshTab(int showNum)
		{
			this.ShowNum = showNum;
			if (showNum > 1)
			{
				this.SetActive(true);
				this.TabLayout.RebuildLayoutByDataNew<FunctionTabItem>(null, new int?(showNum));
				return;
			}
			this.SetActive(false);
		}

		// Token: 0x0603C1CE RID: 246222 RVA: 0x00F3E410 File Offset: 0x00F3C610
		public void SetToggleSelectByIndex(int index)
		{
			if (this.ShowNum <= 1)
			{
				return;
			}
			if (this.CurrentSelect == index)
			{
				return;
			}
			if (this.CurrentSelect != -1)
			{
				this.TabLayout.GetLayoutItemByKey(this.CurrentSelect).SetToggleState(false);
			}
			this.TabLayout.GetLayoutItemByKey(index).SetToggleState(true);
			this.CurrentSelect = index;
		}

		// Token: 0x04021BEC RID: 138220
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private GenericLayoutNew<FunctionTabItem> TabLayout;

		// Token: 0x04021BED RID: 138221
		private int CurrentSelect = -1;

		// Token: 0x04021BEE RID: 138222
		private int ShowNum;

		// Token: 0x0200BD90 RID: 48528
		private class EFunctionTabLayoutDefine
		{
			// Token: 0x0403A616 RID: 239126
			public const int TabRoot = 0;

			// Token: 0x0403A617 RID: 239127
			public const int TabItem = 1;
		}
	}
}
