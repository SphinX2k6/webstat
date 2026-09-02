using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.FishingQte
{
	// Token: 0x02006E9D RID: 28317
	[NullableContext(1)]
	[Nullable(0)]
	public class FishingCabinItem : UiPanelBase
	{
		// Token: 0x06044AC4 RID: 281284 RVA: 0x011D98F4 File Offset: 0x011D7AF4
		protected unsafe override void OnRegisterComponent()
		{
			int num = 3;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIButtonComponent));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIGridLayout));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
			num2 = 1;
			List<ValueTuple<int, Delegate>> list2 = new List<ValueTuple<int, Delegate>>(num2);
			CollectionsMarshal.SetCount<ValueTuple<int, Delegate>>(list2, num2);
			Span<ValueTuple<int, Delegate>> span2 = CollectionsMarshal.AsSpan<ValueTuple<int, Delegate>>(list2);
			num = 0;
			*span2[num] = new ValueTuple<int, Delegate>(0, new Action(this.ButtonClick));
			this.BtnBindInfo = list2;
		}

		// Token: 0x06044AC5 RID: 281285 RVA: 0x011D99BB File Offset: 0x011D7BBB
		protected override void OnStart()
		{
			this.Layout = new GenericLayout<GridItem, int>(base.GetGridLayout(1), new Func<GridItem>(this.CreateItem), null, false, true);
		}

		// Token: 0x06044AC6 RID: 281286 RVA: 0x011D99DE File Offset: 0x011D7BDE
		private GridItem CreateItem()
		{
			return new GridItem();
		}

		// Token: 0x06044AC7 RID: 281287 RVA: 0x011D99E5 File Offset: 0x011D7BE5
		protected override void OnBeforeDestroy()
		{
			this.ButtonFunction = null;
		}

		// Token: 0x06044AC8 RID: 281288 RVA: 0x011D99EE File Offset: 0x011D7BEE
		private void ButtonClick()
		{
			Action buttonFunction = this.ButtonFunction;
			if (buttonFunction == null)
			{
				return;
			}
			buttonFunction();
		}

		// Token: 0x06044AC9 RID: 281289 RVA: 0x011D9A00 File Offset: 0x011D7C00
		public void SetFunction(Action buttonFunction)
		{
			this.ButtonFunction = buttonFunction;
		}

		// Token: 0x06044ACA RID: 281290 RVA: 0x011D9A0C File Offset: 0x011D7C0C
		public void RefreshCabin()
		{
			List<List<int>> backpackPosDataDoublyList = ModelBase<DockyardModel>.Instance.BackpackPosDataDoublyList;
			List<int> list = new List<int>();
			foreach (List<int> collection in backpackPosDataDoublyList)
			{
				list.AddRange(collection);
			}
			this.Layout.RefreshByData(list, null, false);
		}

		// Token: 0x040263B8 RID: 156600
		protected GenericLayout<GridItem, int> Layout;

		// Token: 0x040263B9 RID: 156601
		[Nullable(2)]
		private Action ButtonFunction;

		// Token: 0x0200CB69 RID: 52073
		[NullableContext(0)]
		private class EComponents
		{
			// Token: 0x0403E6CF RID: 255695
			public const int Button = 0;

			// Token: 0x0403E6D0 RID: 255696
			public const int LayoutGridList = 1;

			// Token: 0x0403E6D1 RID: 255697
			public const int GridItem = 2;
		}
	}
}
