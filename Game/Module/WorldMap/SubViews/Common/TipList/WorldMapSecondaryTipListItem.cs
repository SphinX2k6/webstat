using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using CSharpScript.Game.Module.Util;
using CSharpScript.Game.Ui;
using UnrealEngine;

namespace CSharpScript.Game.Module.WorldMap.SubViews.Common.TipList
{
	// Token: 0x02004BD4 RID: 19412
	public class WorldMapSecondaryTipListItem : UiPanelBase, IGridProxy<IWorldMapSecondaryTipItemParam>
	{
		// Token: 0x17008701 RID: 34561
		// (get) Token: 0x06032A7D RID: 207485 RVA: 0x00CB00EC File Offset: 0x00CAE2EC
		// (set) Token: 0x06032A7E RID: 207486 RVA: 0x00CB00F4 File Offset: 0x00CAE2F4
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		public IScrollViewDelegate<IGridProxy<IWorldMapSecondaryTipItemParam>, IWorldMapSecondaryTipItemParam> ScrollViewDelegate { [return: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] get; [param: Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})] set; }

		// Token: 0x17008702 RID: 34562
		// (get) Token: 0x06032A7F RID: 207487 RVA: 0x00CB00FD File Offset: 0x00CAE2FD
		// (set) Token: 0x06032A80 RID: 207488 RVA: 0x00CB0105 File Offset: 0x00CAE305
		public int GridIndex { get; set; }

		// Token: 0x17008703 RID: 34563
		// (get) Token: 0x06032A81 RID: 207489 RVA: 0x00CB010E File Offset: 0x00CAE30E
		// (set) Token: 0x06032A82 RID: 207490 RVA: 0x00CB0116 File Offset: 0x00CAE316
		public int DisplayIndex { get; set; }

		// Token: 0x06032A83 RID: 207491 RVA: 0x00CB0120 File Offset: 0x00CAE320
		protected unsafe override void OnRegisterComponent()
		{
			int num = 2;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUIText));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x06032A84 RID: 207492 RVA: 0x00CB0189 File Offset: 0x00CAE389
		[NullableContext(1)]
		public void Refresh(IWorldMapSecondaryTipItemParam data, bool isSelected, int gridIndex)
		{
			UUIText text = base.GetText(0);
			if (text != null)
			{
				text.SetText(data.Name, true);
			}
			UUIText text2 = base.GetText(1);
			if (text2 == null)
			{
				return;
			}
			text2.SetText(data.Desc, true);
		}

		// Token: 0x06032A85 RID: 207493 RVA: 0x00CB01BC File Offset: 0x00CAE3BC
		public void Clear()
		{
		}

		// Token: 0x06032A86 RID: 207494 RVA: 0x00CB01BE File Offset: 0x00CAE3BE
		public void OnSelected(bool fireEvent)
		{
		}

		// Token: 0x06032A87 RID: 207495 RVA: 0x00CB01C0 File Offset: 0x00CAE3C0
		public void OnDeselected(bool fireEvent)
		{
		}

		// Token: 0x06032A88 RID: 207496 RVA: 0x00CB01C2 File Offset: 0x00CAE3C2
		[NullableContext(1)]
		public object GetKey(IWorldMapSecondaryTipItemParam data, int gridIndex)
		{
			return this.GridIndex;
		}

		// Token: 0x06032A89 RID: 207497 RVA: 0x00CB01CF File Offset: 0x00CAE3CF
		[NullableContext(2)]
		protected UUIText GetNameTxt()
		{
			return base.GetText(0);
		}

		// Token: 0x06032A8A RID: 207498 RVA: 0x00CB01D8 File Offset: 0x00CAE3D8
		[NullableContext(2)]
		protected UUIText GetDescTxt()
		{
			return base.GetText(1);
		}

		// Token: 0x0200ACB9 RID: 44217
		private static class EComponents
		{
			// Token: 0x04035A7D RID: 219773
			public const int TxtItemName = 0;

			// Token: 0x04035A7E RID: 219774
			public const int TxtItemDesc = 1;
		}
	}
}
