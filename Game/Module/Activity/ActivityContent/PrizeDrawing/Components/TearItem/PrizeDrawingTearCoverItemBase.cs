using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PrizeDrawing.Components.TearItem
{
	// Token: 0x02006571 RID: 25969
	[NullableContext(2)]
	[Nullable(0)]
	public class PrizeDrawingTearCoverItemBase : UiPanelBase
	{
		// Token: 0x06040DE6 RID: 265702 RVA: 0x010A3358 File Offset: 0x010A1558
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06040DE7 RID: 265703 RVA: 0x010A33C4 File Offset: 0x010A15C4
		[NullableContext(1)]
		public void AttachTearItemToContent(PrizeDrawingTearItemBase tearItem)
		{
			if (this.TearItem != null)
			{
				this.TearItem.Destroy(null);
			}
			this.TearItem = tearItem;
			tearItem.GetRootItem().K2_AttachTo(base.GetItem(0), default(FName), EAttachLocation.KeepRelativeOffset, true);
		}

		// Token: 0x06040DE8 RID: 265704 RVA: 0x010A340A File Offset: 0x010A160A
		public PrizeDrawingTearItemBase GetTearItem()
		{
			return this.TearItem;
		}

		// Token: 0x04024682 RID: 149122
		protected PrizeDrawingTearItemBase TearItem;
	}
}
