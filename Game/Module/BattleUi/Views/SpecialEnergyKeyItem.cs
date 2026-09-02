using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.BattleUi.Views
{
	// Token: 0x0200604A RID: 24650
	[NullableContext(2)]
	[Nullable(0)]
	public class SpecialEnergyKeyItem : LongPressKeyItemBase
	{
		// Token: 0x0603E2F1 RID: 254705 RVA: 0x00FE06FC File Offset: 0x00FDE8FC
		protected unsafe override void OnRegisterComponent()
		{
			int num = 4;
			List<ValueTuple<int, Type>> list = new List<ValueTuple<int, Type>>(num);
			CollectionsMarshal.SetCount<ValueTuple<int, Type>>(list, num);
			Span<ValueTuple<int, Type>> span = CollectionsMarshal.AsSpan<ValueTuple<int, Type>>(list);
			int num2 = 0;
			*span[num2] = new ValueTuple<int, Type>(0, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(1, typeof(UUIItem));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(2, typeof(UUITexture));
			num2++;
			*span[num2] = new ValueTuple<int, Type>(3, typeof(UUIText));
			this.ComponentRegisterInfos = list;
		}

		// Token: 0x0603E2F2 RID: 254706 RVA: 0x00FE07A7 File Offset: 0x00FDE9A7
		protected override UUIText GetKeyText()
		{
			return base.GetText(3);
		}

		// Token: 0x0603E2F3 RID: 254707 RVA: 0x00FE07B0 File Offset: 0x00FDE9B0
		protected override UUITexture GetKeyTexture()
		{
			return base.GetTexture(0);
		}

		// Token: 0x0603E2F4 RID: 254708 RVA: 0x00FE07B9 File Offset: 0x00FDE9B9
		protected override UUITexture GetLongPressTexture()
		{
			return base.GetTexture(2);
		}

		// Token: 0x0603E2F5 RID: 254709 RVA: 0x00FE07C2 File Offset: 0x00FDE9C2
		protected override UUIItem GetLongPressItem()
		{
			return base.GetItem(1);
		}

		// Token: 0x0200C10A RID: 49418
		[NullableContext(0)]
		private enum EChildType
		{
			// Token: 0x0403B71C RID: 243484
			KeyTexture,
			// Token: 0x0403B71D RID: 243485
			LongPressItem,
			// Token: 0x0403B71E RID: 243486
			LongPressTexture,
			// Token: 0x0403B71F RID: 243487
			KeyText
		}
	}
}
